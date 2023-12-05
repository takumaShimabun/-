using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
//using インボイス番号検索ツール.Model.Sys;
//using インボイス番号検索ツール.ViewControler;

namespace インボイス番号検索ツール
{
    internal static class Program
    {
        private static string _msgTitle = "インボイス番号検索ツール";
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 更新情報の確認 - アプリケーションの起動 ========================
            //AutoUpdater autoUpdator = new();
            //bool thereIsNoUpdateOrUpdateCompleted = autoUpdator.ExecuteAutoUpdate();

            //if (thereIsNoUpdateOrUpdateCompleted)
            //{
            //    Application.Run(new SearchBox());
            //}
            //else
            //{
            //    Application.Run();
            //}
            // 更新情報の確認 - アプリケーションの起動 ========================

            // ログイン処理（ユーザ登録の有無確認）
            if (!Model.Common.Tools.UserIsActive())
            {
                MessageBox.Show("ご利用のユーザはアクティベートされていません。管理者へ利用申請してください。", _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Model.Common.Tools.UserCanUseThisAppVersion())
            {
                if (Model.Common.Tools.LoginApp())
                {
                    Application.Run(new ViewControler.SearchBox());
                }
                else
                {
                    MessageBox.Show("ログイン処理に失敗しました。管理者へ連絡してください。", _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("ご利用のユーザはこのバージョンを利用許可されていません。管理者へ利用申請してください。", _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
