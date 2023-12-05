using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace インボイス番号検索ツール.ViewControler
{
    public partial class ObicDetail : Form
    {
        private readonly string _obicCode = string.Empty;
        private readonly DataTable _dt = null;

        public ObicDetail(string obicCode)
        {
            InitializeComponent();
            _obicCode = obicCode;
            this.Text = _obicCode;
            _dt = Model.DB.SqlManager.SelectObicMaster(code: _obicCode);
            Model.Common.Tools.SetUpDataGridView(dgv支払方法);

            // テーマカラーをセット start =========================================
            System.Drawing.Color c;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ThemeColor))
            {
                c = System.Drawing.Color.FromArgb(int.Parse(Properties.Settings.Default.ThemeColor));
                c = System.Drawing.Color.FromArgb(50, c); // 透明度を50統一（Max 255:完全に不透明）
            }
            else
            {
                c = Model.Common.Defs.DefaultThemeColor;
                c = System.Drawing.Color.FromArgb(50, c);
            }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Label) && ctrl.Tag != null && ctrl.Tag.ToString() == "chgBack")
                {
                    ctrl.BackColor = c;
                }
                foreach (Control ctrlChild1 in ctrl.Controls)
                {
                    if (ctrlChild1.GetType() == typeof(Label) && ctrlChild1.Tag != null && ctrlChild1.ToString() == "chgBack")
                    {
                        ctrlChild1.BackColor = c;
                    }
                    foreach (Control ctrlChild2 in ctrlChild1.Controls)
                    {
                        if (ctrlChild2.GetType() == typeof(Label) && ctrlChild2.Tag != null && ctrlChild2.Tag.ToString() == "chgBack")
                        {
                            ctrlChild2.BackColor = c;
                        }
                    }
                }
            }
            // テーマカラーをセット end =========================================
        }

        private void ObicDetail_Load(object sender, EventArgs e)
        {
            RefreshObicData();
        }

        private void RefreshObicData()
        {
            // タイプの1文字目によってラベルの表示文字切替
            switch (_dt.Rows[0]["タイプ"].ToString()[..1].ToUpper())
            {
                case "U":
                    lbl取引先コード.Text = "請求先コード";
                    lbl取引先正式名.Text = "請求先正式名";
                    lbl連携取引先コード.Text = "入金請求先コード";
                    lbl連携取引先名.Text = "入金請求先名";
                    lbl担当者名2.Text = "入金部署名";
                    lbl通知書不要フラグ.Text = "請求書不要フラグ";
                    break;
                default:
                    lbl取引先コード.Text = "支払先コード";
                    lbl取引先正式名.Text = "支払先正式名";
                    lbl連携取引先コード.Text = "出金支払先コード";
                    lbl連携取引先名.Text = "出金支払先名";
                    lbl担当者名2.Text = "出金部署名";
                    lbl通知書不要フラグ.Text = "支払通知書不要フラグ";
                    break;
            }
            
            // 各値を表示 start ===============================================
            txt取引先コード.Text = _dt.Rows[0]["CODE"].ToString();
            txt法人コード.Text = _dt.Rows[0]["法人コード"].ToString();
            txt取引先正式名.Text = _dt.Rows[0]["取引正式名"].ToString();
            txt取引先名.Text = _dt.Rows[0]["取引名"].ToString();
            txt取引先カナ名.Text = _dt.Rows[0]["取引カナ名"].ToString();
            txt郵便番号1.Text = _dt.Rows[0]["郵便番号1"].ToString();
            txt郵便番号2.Text = _dt.Rows[0]["郵便番号2"].ToString();
            txt住所1.Text = _dt.Rows[0]["住所1"].ToString();
            txt住所2.Text = _dt.Rows[0]["住所2"].ToString();
            txt住所3.Text = _dt.Rows[0]["住所3"].ToString();
            txt住所4.Text = _dt.Rows[0]["住所4"].ToString();
            txt住所5.Text = _dt.Rows[0]["住所5"].ToString();
            txt電話番号1_1.Text = _dt.Rows[0]["TEL1"].ToString();
            txt電話番号1_2.Text = _dt.Rows[0]["TEL2"].ToString();
            txt電話番号1_3.Text = _dt.Rows[0]["TEL3"].ToString();
            txtFax番号1_1.Text = _dt.Rows[0]["FAX1"].ToString();
            txtFax番号1_2.Text = _dt.Rows[0]["FAX2"].ToString();
            txtFax番号1_3.Text = _dt.Rows[0]["FAX3"].ToString();
            txt電話番号海外.Text = _dt.Rows[0]["TEL"].ToString();
            txtFax番号海外.Text = _dt.Rows[0]["FAX"].ToString();
            txt連携取引先コード.Text = _dt.Rows[0]["出金支払先コード"].ToString();
            txt連携取引先名.Text = _dt.Rows[0]["入出金取引名"].ToString();
            txt担当者名2.Text = _dt.Rows[0]["担当者名1"].ToString();
            txtサイト日数.Text = _dt.Rows[0]["サイト1"].ToString();

            // 支払締日などのデータセット =====
            dgv支払方法.DataSource = _dt;
            List<string> showCol = new()
            {
                "締日"
                , "支払月"
                , "支払日"
                , "支払方法コード"
                , "支払方法名"
                , "汎用締日"
                , "汎用決済方法名"
                , "汎用表示順"
            };

            // 不要な列を非表示にする =====
            foreach (DataGridViewColumn col in dgv支払方法.Columns)
            {
                if (showCol.Contains(col.Name)) col.Visible = true;
                else col.Visible = false;
            }

            txt法人番号.Text = _dt.Rows[0]["インボイス番号"].ToString();
            txt担当者コード.Text = _dt.Rows[0]["部署コード"].ToString();
            lbl担当者名.Text = _dt.Rows[0]["部署名"].ToString();
            txt代表事業所コード.Text = _dt.Rows[0]["代表事業所コード"].ToString();
            lbl代表事業所.Text = _dt.Rows[0]["事業所名"].ToString();
            txt会計用取引先コード.Text = _dt.Rows[0]["会計用取引先コード"].ToString();
            txt消費税算出区分.Text = _dt.Rows[0]["消費税算出区分"].ToString();
            lbl消費税算出.Text = txt消費税算出区分.Text switch
            {
                "0" => "明細単位",
                "1" => "伝票単位",
                "2" => "締時一括",
                "3" => "計算しない",
                _ => string.Empty,
            };
            txt通知書不要フラグ.Text = _dt.Rows[0]["通知書不要フラグ"].ToString() == "True" ? "1" : "0";
            lbl通知書不要.Text = txt通知書不要フラグ.Text switch
            {
                "1" => "不要",
                "0" => "必要",
                _ => string.Empty,
            };
            txt銀行コード.Text = _dt.Rows[0]["銀行コード"].ToString();
            lbl銀行名.Text = _dt.Rows[0]["銀行名"].ToString();
            txt銀行支店コード.Text = _dt.Rows[0]["銀行支店コード"].ToString();
            lbl銀行支店名.Text = _dt.Rows[0]["銀行支店名"].ToString();
            txt口座種別.Text = _dt.Rows[0]["口座種別"].ToString();
            lbl口座種別.Text = txt口座種別.Text switch
            {
                "1" => "普通預金",
                "2" => "当座預金",
                _ => string.Empty,
            };
            txt口座番号.Text = _dt.Rows[0]["口座番号"].ToString();
            txt口座名義人カナ.Text = _dt.Rows[0]["口座名義人カナ"].ToString();
            txt手数料負担区分.Text = _dt.Rows[0]["手数料負担区分"].ToString();
            lbl手数料負担.Text = txt手数料負担区分.Text switch
            {
                "0" => "取引先負担",
                "1" => "自社負担",
                _ => string.Empty,
            };
            txt休日処理区分.Text = _dt.Rows[0]["休日処理区分"].ToString();
            lbl休日処理.Text = txt休日処理区分.Text switch
            {
                "0" => "前営業日",
                "1" => "当日",
                "2" => "次営業日",
                _ => string.Empty,
            };
            txt取引終了日.Text = _dt.Rows[0]["取引終了日"].ToString();
            txt手形決済口座.Text = _dt.Rows[0]["手形決済口座コード"].ToString();
            txt手形種類.Text = _dt.Rows[0]["手形種類区分"].ToString();
            lbl手形種類.Text = txt手形種類.Text switch
            {
                "1" => "約束手形",
                "3" => "為替手形",
                "6" => "電子債権（約束)",
                "7" => "電子債権（為替）",
                _ => string.Empty,
            };
            txt国内外区分.Text = _dt.Rows[0]["国内外区分"].ToString();
            lbl国内外.Text = txt国内外区分.Text switch
            {
                "0" => "国内",
                "1" => "国外",
                _ => string.Empty,
            };
            txt消費税内外区分.Text = _dt.Rows[0]["消費税内外区分"].ToString();
            lbl消費税内外.Text = txt消費税内外区分.Text switch
            {
                "0" => "外税",
                "1" => "内税",
                "2" => "非課税",
                _ => string.Empty,
            };
            txt消費税率区分.Text = _dt.Rows[0]["消費税率区分"].ToString();
            lbl消費税率.Text = _dt.Rows[0]["コード名称"].ToString();
            txt債務科目区分.Text = _dt.Rows[0]["科目区分"].ToString();
            lbl債務科目.Text = txt債務科目区分.Text switch
            {
                "1520" => "売掛金",
                "1841" => "未収入金",
                "1863" => "仮払金支店",
                "1880" => "前払費用",
                "1891" => "仮払金支店",
                "3120" => "買掛金",
                "3221" => "未払金",
                "3292" => "仮受金",
                "9999" => "源泉税預り金",
                _ => string.Empty,
            };
            // 各値を表示 end ===============================================
        }
    }
}
