using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace インボイス番号検索ツール.Model.Sys
{
    internal class AutoUpdater
    {
        public static string Version = @"1.0.0";
        private static readonly string _old = ".old";

        private static string ServerFolderPath { get; } = Properties.Settings.Default.AutoUpdaterServerFolderPath;
        private static string ProjectFileName { get; } = Properties.Settings.Default.AutoUpdaterProjectFileName;
        private static string MessageTitle { get; } = "インボイス番号検索ツールの更新";
        private static string ServerAppFullPath { get; } = $@"{ServerFolderPath}\{ProjectFileName}";
        private static string LocalAppFullPath { get; } = Application.ExecutablePath; // 実行中のファイルまでのフルパス
        private static string LocalFolderPath { get; } = Path.GetDirectoryName(LocalAppFullPath);
        private static string LocalAppFileName { get; } = Path.GetFileName(LocalAppFullPath); // 実行中のファイル名
        private string[] ResourseExtensions { get; } = new string[] { ".dll", ".json", ".pdb", ".config", ".exe", _old };

        public bool ExecuteAutoUpdate()
        {
            try
            {
                // もし更新が必要であれば更新処理を実行
                if (UpdateNeeded())
                {
                    // ③更新するかどうかの意思確認を行う。「はい」が選択された場合は以下の処理。
                    if (MessageBox.Show(
                        text: @"更新ファイルがあります。アップデートしますか？",
                        caption: MessageTitle,
                        buttons: MessageBoxButtons.YesNo,
                        icon: MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        ProcessStartInfo info = new()
                        {
                            FileName = Path.Combine(LocalFolderPath, "AutoUpdaterTool", "AutoUpdaterTool.exe"),
                            Arguments = $@"/up {Environment.ProcessId} /sfp ""{ServerFolderPath}"" /pfn ""{ProjectFileName}"" /lafp ""{LocalAppFullPath}""",
                            Verb = "RunAs",
                            UseShellExecute = true,
                        };
                        Process.Start(info);
                        ExitWithDelay(1000);
                        return false;
                        //Process.Start("AutoUpdater/AutoUpdater.exe", $@"/up {Environment.ProcessId}");
                    }
                    else
                    {
                        MessageBox.Show(
                            text: @"キャンセルしました",
                            caption: MessageTitle,
                            buttons: MessageBoxButtons.OK,
                            icon: MessageBoxIcon.Asterisk);
                    }
                }
                return true;
                //// ⑧コマンドライン引数にプロセスIDが渡されていたら終了まで待機（強制終了）
                //WaitForPastProcessExit();

                //// ①・⑨拡張子がoldのファイルがあれば削除（更新前の準備および更新後のお掃除）
                //ScanDirectory(LocalFolderPath, false, false, true, false);

                //// ②もし更新が必要であれば更新処理を実行
                //if (UpdateNeeded())
                //{
                //    // ③更新するかどうかの意思確認を行う。「はい」が選択された場合は以下の処理。
                //    if (MessageBox.Show(
                //        text: @"更新ファイルがあります。アップデートしますか？",
                //        caption: MessageTitle,
                //        buttons: MessageBoxButtons.YesNo,
                //        icon: MessageBoxIcon.Question)
                //        == DialogResult.Yes)
                //    {
                //        // ④現在の実行ファイルの拡張子を変更(.old)
                //        ScanDirectory(LocalFolderPath, false, true, false, false);

                //        // ⑤サーバ上の新しい実行ファイルをダウンロード
                //        ScanDirectory(ServerFolderPath, true, false, false, false);

                //        MessageBox.Show(
                //            text: @"最新データのダウンロードが終了しました。アプリを再起動します",
                //            caption: MessageTitle,
                //            buttons: MessageBoxButtons.OK,
                //            icon: MessageBoxIcon.Asterisk);

                //        // ⑥ダウンロードした新しい実行ファイルをキック
                //        StartNewApp();

                //        // ⑦1秒後にアプリを終了
                //        ExitWithDelay(1000);
                //        return false;
                //    }
                //    else
                //    {
                //        MessageBox.Show(
                //            text: @"キャンセルしました",
                //            caption: MessageTitle,
                //            buttons: MessageBoxButtons.OK,
                //            icon: MessageBoxIcon.Asterisk);
                //    }
                //}
                //return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // oldファイルになっていたら元に戻す
                ScanDirectory(LocalFolderPath, false, false, false, true);
                throw new Exception("ExecuteAutoUpdate Error", ex);
            }
        }

        private static bool WaitForPastProcessExit()
        {
            // コマンドライン引数をチェック
            string[] commandLineArgs;
            int pid;
            int indexPid;
            int indexStrPid = Environment.CommandLine.IndexOf(value: "/up", comparisonType: StringComparison.InvariantCultureIgnoreCase);

            // もしコマンドライン引数にupdate用の引数（process id)が渡されていたらプロセス終了まで待つ
            if (indexStrPid != -1)
            {
                try
                {
                    commandLineArgs = Environment.GetCommandLineArgs();
                    indexPid = Array.FindIndex(
                        array: commandLineArgs,
                        target => target.Equals("/up", StringComparison.InvariantCultureIgnoreCase));
                    indexPid++;

                    if (indexPid < commandLineArgs.Length)
                    {
                        pid = Convert.ToInt32(commandLineArgs[indexPid]);
                        Process pastProcess = Process.GetProcessById(pid);

                        // １０秒待ってる間にプロセス終了したらtrue
                        if (pastProcess.WaitForExit(10000))
                        {
                            return true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("WaitForPastProcessExit Error", ex);
                }
            }
            return false;
        }

        private static bool UpdateNeeded()
        {
            try
            {
                // 実行中のファイルと対象プロジェクトの実行ファイル名が同一である場合（大文字小文字の区別なし）
                if (LocalAppFileName.Equals(ProjectFileName, StringComparison.InvariantCultureIgnoreCase))
                {
                    // サーバ上のファイルが存在する場合
                    if (File.Exists(ServerAppFullPath))
                    {
                        // 実行中のファイルの更新日時がサーバ上のファイルの更新日時より古い場合は戻り値True
                        if (File.GetLastWriteTime(LocalAppFullPath) < File.GetLastWriteTime(ServerAppFullPath))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateNeeded Error", ex);
            }
        }

        private static void StartNewApp()
        {
            try
            {
                Process.Start(LocalAppFullPath, $@"/up {Environment.ProcessId}");
            }
            catch (Exception ex)
            {
                throw new Exception("StartNewApp Error", ex);
            }
        }

        static async void ExitWithDelay(int milisecond)
        {
            await Task.Delay(milisecond);
            Environment.Exit(0);
        }

        private void ScanDirectory(string targetPath, bool copyToLocal, bool moveToOld, bool deleteFileForce, bool undoMoveToOld)
        {
            string[] ds = Directory.GetDirectories(targetPath);
            if (ds.Length > 0)
            {
                foreach (string d in ds)
                {
                    ScanDirectory(d, copyToLocal, moveToOld, deleteFileForce, undoMoveToOld);
                }
            }
            string[] fs = Directory.GetFiles(targetPath);
            if (fs.Length > 0)
            {
                foreach(string f in fs)
                {
                    if (ResourseExtensions.Contains(Path.GetExtension(f) ?? string.Empty))
                    {
                        if (copyToLocal) CopyFileToLocal(f);
                        if (moveToOld) MoveToOld(f);
                        if (deleteFileForce) DeleteOldFileForce(f);
                        if (undoMoveToOld) UndoMoveToOld(f);
                    }
                }
            }
        }

        private static void CopyFileToLocal(string filePath)
        {
            try
            {
                string dir = Path.GetDirectoryName(filePath)!.Replace(ServerFolderPath, LocalFolderPath);
                string fName = Path.GetFileName(filePath);
                string dest = Path.Combine(dir, fName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (!File.Exists(dest))
                {
                    File.Copy(filePath, dest, false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CopyFileToLocal Error", ex);
            }
        }

        private static void MoveToOld(string filePath)
        {
            try
            {
                FileInfo fi = new(filePath);
                if (fi.Exists)
                {
                    // 読み取り専用になってたらNormalに変更
                    if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                }
                fi.MoveTo(filePath + _old);
            }
            catch (Exception ex)
            {
                throw new Exception("MoveToOld Error", ex);
            }
        }

        private static void UndoMoveToOld(string filePath)
        {
            try
            {
                FileInfo fi = new(filePath);
                if (fi.Exists)
                {
                    // 読み取り専用になってたらNormalに変更
                    if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                }
                if (fi.Extension == _old)
                {
                    fi.MoveTo(filePath[..^4]);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("MoveToOld Error", ex);
            }
        }

        private static void DeleteOldFileForce(string filePath)
        {
            try
            {
                FileInfo fi = new(filePath);
                if (fi.Exists)
                {
                    // 読み取り専用になってたらNormalに変更
                    if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                }
                if (fi.Extension == _old)
                {
                    fi.Delete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteOldExeFiles Error", ex);
            }
        }
    }
}
