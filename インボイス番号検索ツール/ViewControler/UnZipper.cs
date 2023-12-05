using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using インボイス番号検索ツール.Model.DB;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace インボイス番号検索ツール.ViewControler
{
    internal partial class UnZipper : Form
    {
        private readonly string _zip = ".zip";
        private readonly string _csv = ".csv";
        private string _destDirectoryPath = string.Empty;
        private readonly Model.DB.OdbcManager _om = new Model.DB.OdbcManager().Connect();
        private readonly string _msgTitle = "インボイス番号検索ツール";
        private readonly string _msgTextErrorNoCsv = "展開したzipファイル内のCSVファイルの出力先が指定されなかったため実行されません";
        private readonly string _msgTextErrorOnlyZip = "ドロップできるのはzipファイルのみです";
        private readonly string _msgTextSuccessUnzip = "展開完了";
        private readonly string _msgTextSuccessDelete = "削除完了";
        private readonly string _msgTextSuccessInsert = "取込完了";
        private readonly string _msgTextSuccessUpdate = "更新完了";
        private readonly string _msgDescFolderBrowser = "DBサーバ（DEV001）上のCSV出力先フォルダを指定してください。";

        public UnZipper()
        {
            InitializeComponent();
        }

        private void PnlDropArea_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PnlDropArea_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                if (!string.IsNullOrEmpty(file))
                {
                    if (Path.GetExtension(file) != _zip)
                    {
                        MessageBox.Show(_msgTextErrorOnlyZip, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            FolderBrowserDialog dlg = new()
            {
                Description = _msgDescFolderBrowser,
                SelectedPath = Properties.Settings.Default.UnZipperDefaultPath,
            };
            DialogResult dlgr = dlg.ShowDialog(this);
            if (dlgr == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.SelectedPath))
                {
                    _destDirectoryPath = dlg.SelectedPath;
                }
            }
            else if (dlgr == DialogResult.Cancel)
            {
                return;
            }
            ExtractZipFiles(files);
            MessageBox.Show(_msgTextSuccessUnzip, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteWk_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_destDirectoryPath))
            {
                Model.DB.SqlManager.DeleteWk();
                MessageBox.Show(_msgTextSuccessDelete, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(_msgTextErrorNoCsv, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInsertWk_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_destDirectoryPath))
            {
                Model.DB.SqlManager.BulkInsert(_destDirectoryPath);
                MessageBox.Show(_msgTextSuccessInsert, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(_msgTextErrorNoCsv, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_destDirectoryPath))
            {
                Model.DB.SqlManager.InsertMaster();
                Model.DB.SqlManager.UpdateMaster();
                MessageBox.Show(_msgTextSuccessUpdate, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(_msgTextErrorNoCsv, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExtractZipFiles(string[] files)
        {
            foreach (string file in files)
            {
                if (File.Exists(file) && Path.GetExtension(file).ToLower() == _zip)
                {
                    string fileName = Path.GetFileName(file).Replace(_zip, string.Empty);
                    string dir = Path.GetDirectoryName(file);
                    string destination = Path.Combine(dir, fileName);

                    try
                    {
                        System.IO.Compression.ZipFile.ExtractToDirectory(
                            file,
                            destination,
                            System.Text.Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        if (ex is IOException)
                        {
                            // 展開先のフォルダにすでにファイルがある場合、何もしない
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string[] chldFiles = Directory.GetFiles(destination);
                    CsvDataReplaceToCrLf(chldFiles);
                }
            }
        }

        public void CsvDataReplaceToCrLf(string[] files)
        {
            foreach (string file in files)
            {
                if (File.Exists(file) && Path.GetExtension(file) == _csv)
                {
                    string t = File.ReadAllText(file).Replace("\n", "\r\n").Replace("\r\r", "\r").Replace("\r", "\r\n").Replace("\n\n", "\n");
                    File.WriteAllText(file, t, encoding: System.Text.Encoding.UTF8);
                    CopyToDest(file);
                }
            }
        }

        public void CopyToDest(string file)
        {
            if (!string.IsNullOrEmpty(_destDirectoryPath))
            {
                string fileName = Path.GetFileName(file);
                string destFilePath = Path.Combine(_destDirectoryPath, fileName);
                File.Copy(file, destFilePath, true);
            }
        }
    }
}
