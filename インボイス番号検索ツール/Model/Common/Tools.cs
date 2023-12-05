using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace インボイス番号検索ツール.Model.Common
{
    internal class Tools
    {
        /// <summary>
        /// DataGridViewのアプリ内共通設定を行う。
        /// </summary>
        /// <param name="dgv">DataGridViewのポインター（参照型のため）</param>
        public static void SetUpDataGridView(DataGridView dgv)
        {
            // ※1, 2はメモリを多く消費するため動作確認入念にする

            // 1, DoubleBufferdプロパティをオンにする（描画をスムーズにする）
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);

            // 2, 全セルに対して列幅自動調整する
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            // 3, 編集不可にする
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = true;
        }

        /// <summary>
        /// カラーパレットのユーザ追加分をアプリ設定ファイルに保存
        /// </summary>
        /// <param name="clrDlg">カラーダイアログのポインター（参照型のため）</param>
        public static void SaveColorDialogCustomColors(ColorDialog clrDlg)
        {
            string strColors = "";
            if (clrDlg.CustomColors != null)
            {
                foreach (int colorNum in clrDlg.CustomColors)
                {
                    strColors += colorNum.ToString() + ",";
                }
            }
            Properties.Settings.Default.StrCustomColors = strColors;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// カラーパレットのユーザ追加分を復元
        /// </summary>
        /// <param name="clrDlg">カラーダイアログのポインター（参照型のため）</param>
        public static void SetColorDialogCustomColors(ColorDialog clrDlg)
        {
            string[] strColors = Properties.Settings.Default.StrCustomColors.Split(',');
            List<int> iColors = new();
            if (strColors.Length != 0)
            {
                foreach (string strColor in strColors)
                {
                    if (int.TryParse(strColor, out int iColor))
                    {
                        iColors.Add(iColor);
                    }
                }
                clrDlg.CustomColors = iColors.ToArray();
            }
        }

        /// <summary>
        /// 背景色に応じて文字色を変える
        /// </summary>
        /// <param name="backColor">比較対象の背景色</param>
        /// <returns>適切な文字色（白or黒）</returns>
        public static Color GetForeColorBasedOnWCAG(Color backColor)
        {
            Dictionary<double, Color> dictTextColors = new()
            {
                //{ GetRelativeLuminance(Color.Black), Color.Black },
                //{ GetRelativeLuminance(Color.DimGray), Color.DimGray },
                //{ GetRelativeLuminance(Color.Gray), Color.Gray },
                //{ GetRelativeLuminance(Color.DarkGray), Color.DarkGray },
                //{ GetRelativeLuminance(Color.Silver), Color.Silver },
                //{ GetRelativeLuminance(Color.LightGray), Color.LightGray },
                //{ GetRelativeLuminance(Color.Gainsboro), Color.Gainsboro },
                { GetRelativeLuminance(Color.WhiteSmoke), Color.WhiteSmoke },
                //{ GetRelativeLuminance(Color.White), Color.White },
            };
            dictTextColors = dictTextColors.Reverse().ToDictionary(x => x.Key, x => x.Value); // 白からループさせる
            double rlBackColor = GetRelativeLuminance(backColor);
            foreach (KeyValuePair<double, Color> kv  in dictTextColors)
            {
                double rlr = GetContrastRatio(kv.Key, rlBackColor);
                //MessageBox.Show($@"{rlr} {kv.Value.ToString()}");
                if (rlr >= 5.0) // 7.0以上が好ましい。少なくとも4.5
                {
                    return kv.Value;
                }
            }
            return SystemColors.ControlText;
        }

        /// <summary>
        /// 相対輝度を求める
        /// </summary>
        /// <param name="c">相対輝度を求めたい色</param>
        /// <returns>相対輝度</returns>
        private static double GetRelativeLuminance(Color c)
        {
            double rWeight = 0.2126;
            double gWeight = 0.7152;
            double bWeight = 0.0722;

            return rWeight * (double)c.R + gWeight * (double)c.G + bWeight * (double)c.B;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rl1"></param>
        /// <param name="rl2"></param>
        /// <returns></returns>
        private static double GetContrastRatio(double rl1, double rl2)
        {
            return (Math.Max(rl1, rl2) + 0.05) / (Math.Min(rl1, rl2) + 0.05);
            //return (Math.Max(rl1, rl2)) / (Math.Min(rl1, rl2));
        }

        public static bool UserIsAdmin()
        {
            DataTable dt = Model.DB.SqlManager.SelectUser(Environment.UserName);
            if (dt != null &&  dt.Rows.Count > 0)
            {
                if ((int)dt.Rows[0]["Authority"] == (int)Model.Common.Defs.Authority.Admin)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool UserIsActive()
        {
            DataTable dt = Model.DB.SqlManager.SelectUser(Environment.UserName);
            if (dt != null && dt.Rows.Count > 0)
            {
                switch ((int)dt.Rows[0]["Status"])
                {
                    case (int)Model.Common.Defs.Status.Active:
                        return true;
                    case (int)Model.Common.Defs.Status.Inactive:
                        return false;
                    default:
                        return false;
                }
            }
            return false;
        }

        public static bool UserCanUseThisAppVersion()
        {
            DataTable dt = Model.DB.SqlManager.SelectUser(Environment.UserName);
            string userVersion = dt.Rows[0]["ActivatedVersion"].ToString();
            string appVersion = Model.Common.Defs.Version;
            string[] userVersionArray = userVersion.Split('.');
            string[] appVersionArray = appVersion.Split(".");
            bool newerMajorVersion = false;

            try
            {
                for (int i = 0; i < userVersionArray.Length; i++)
                {
                    if (int.TryParse(userVersionArray[i], out int u))
                    {
                        if (int.TryParse(appVersionArray[i], out int a))
                        {
                            if (u > a)
                            {
                                newerMajorVersion = true;
                                continue;
                            }
                            else if (u == a)
                            {
                                continue;
                            }
                            else
                            {
                                // u < aだとしても上位のバージョン番号が上であれば問題なし。
                                if (newerMajorVersion)
                                {
                                    continue;
                                }
                                // 上位のバージョン番号が同じなら要件満たしていないのでfalse
                                return false;
                            }
                        }
                    }
                    // continueされずにここまで来てたらデータがおかしいのでfalse
                    return false;
                }
                // すべてcontinueで抜けていればバージョンは問題ないのでtrue
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                // app側で保持しているバージョン番号の桁数の方が少なかったらtrue
                return true;
            }
            catch (Exception)
            {
                // その他の例外はfalse
                return false;
            }
        }

        public static bool LoginApp()
        {
            if (Model.Common.Defs.Debug)
            {
                return true;
            }
            return Model.DB.SqlManager.InsertLogin(Environment.UserName, Model.Common.Defs.Version, Environment.MachineName);
        }
    }
}
