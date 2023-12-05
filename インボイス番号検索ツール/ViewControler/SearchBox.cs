using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace インボイス番号検索ツール.ViewControler
{
    internal partial class SearchBox : Form
    {
        private string _msgTitle = "インボイス番号検索ツール";
        public SearchBox()
        {
            InitializeComponent();

            Dictionary<int, string> dicStatus = new()
            {
                { -1, string.Empty }, { 1, "新規"}, { 2, "変更"}, { 3, "失効"}, { 4, "取消"}, { 99, "削除"}
            };
            Dictionary<int, string> dicPersonal = new()
            {
                { -1, string.Empty }, { 1, "個人"}, { 2, "法人"}
            };
            Dictionary<int, string> dicDomestic = new()
            {
                { -1, string.Empty }, { 1, "国内事業者"}, { 2, "特定国外事業者"}, {3, "その他の国外事業者"}
            };

            cmbStatus.DataSource = dicStatus.ToList();
            cmbStatus.ValueMember = "Key";
            cmbStatus.DisplayMember = "Value";

            cmbPersonality.DataSource = dicPersonal.ToList();
            cmbPersonality.ValueMember = "Key";
            cmbPersonality.DisplayMember = "Value";

            cmbDomestic.DataSource = dicDomestic.ToList();
            cmbDomestic.ValueMember = "Key";
            cmbDomestic.DisplayMember = "Value";

            Model.Common.Tools.SetUpDataGridView(dgvMain);

            System.Drawing.Color c;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ThemeColor))
            {
                c = System.Drawing.Color.FromArgb(int.Parse(Properties.Settings.Default.ThemeColor));
            }
            else
            {
                c = Model.Common.Defs.DefaultThemeColor;
            }

            pnlHead.BackColor = c;
            menuStrip1.BackColor = c;
            SetMenuStripForeColor(c);
            Model.Common.Tools.SetColorDialogCustomColors(clrDlg);

            // 検索窓の調整
            pnlInvoice.BringToFront();

            // バージョン情報表示
            lblVersion.Text = $@"Ver.{Model.Common.Defs.Version}";
            ResetSearch();
        }

        private void SearchBox_Load(object sender, EventArgs e)
        {
            if (!Model.Common.Tools.UserIsAdmin())
            {
                btnAdmin.Visible = false;
                btnSetting.Location = btnAdmin.Location;
            }
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            //Form frmDlg = new Password(this);
            //if (frmDlg.ShowDialog() == DialogResult.OK)
            //{
            //    Form frm = new UnZipper();
            //    frm.ShowDialog();
            //}
            if (Model.Common.Tools.UserIsAdmin())
            {
                Form frm = new UnZipper();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("この先は管理者ユーザのみアクセスが許可されています。", _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetSearch();
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            // カラーパレットを表示してRichTextBoxの選択文字色を変更
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                pnlHead.BackColor = clrDlg.Color;
                menuStrip1.BackColor = clrDlg.Color;
                Properties.Settings.Default.ThemeColor = clrDlg.Color.ToArgb().ToString();
                Properties.Settings.Default.Save();

                Model.Common.Tools.SaveColorDialogCustomColors(clrDlg);
                SetMenuStripForeColor(clrDlg.Color);
            }
        }

        private void CmbStatus_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            SearchIRN();
        }

        private void CmbPersonality_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            SearchIRN();
        }

        private void CmbDomestic_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            SearchIRN();
        }

        private void DgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string targetCode;
            if (e.RowIndex >= 0)
            {
                targetCode = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (pnlInvoice.Tag != null && pnlInvoice.Tag.ToString() == "active")
                {
                    Form frmDlg = new DgvViewer(targetCode);
                    frmDlg.ShowDialog();
                }
                else if (pnlObic.Tag != null && pnlObic.Tag.ToString() == "active")
                {
                    Form frmDlg = new ObicDetail(targetCode);
                    frmDlg.ShowDialog();
                }
                else
                {
                    return;
                }
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "https://www.invoice-kohyo.nta.go.jp/download/index.html"
                    ,
                    UseShellExecute = true
                });
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "https://www.invoice-kohyo.nta.go.jp/files/k-resource-dl.pdf"
                    ,
                    UseShellExecute = true
                });
        }

        private void TxtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchIRN();
            }
        }

        private void TxtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchIRN();
            }
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchIRN();
            }
        }

        private void TxtObicCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchObic();
            }
        }

        private void TxtObicName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchObic();
            }
        }

        private void TxtObicKanaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchObic();
            }
        }

        private void TxtObicCompanyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchObic();
            }
        }

        private void TxtObicDeptCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchObic();
            }
        }

        private void TxtObicDeptName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchObic();
            }
        }

        private void MenuInvoice_Click(object sender, EventArgs e)
        {
            ResetSearch();
            SwitchVisibleLocation(pnlInvoice, pnlObic);
            linkLabel1.Visible = true;
            linkLabel2.Visible = true;
            txtInvoice.Focus();
            this.Text = "インボイス番号検索";
        }

        private void MenuObic_Click(object sender, EventArgs e)
        {
            ResetSearch();
            SwitchVisibleLocation(pnlObic, pnlInvoice);
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;
            txtObicCode.Focus();
            this.Text = "OBICマスタ検索";
        }

        private void ResetSearch()
        {
            // pnlInvoice内のリセット
            txtInvoice.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            cmbStatus.SelectedIndex = 0;
            cmbPersonality.SelectedIndex = 0;
            cmbDomestic.SelectedIndex = 0;

            // pnlObic内のリセット
            txtObicCode.Text = string.Empty;
            txtObicName.Text = string.Empty;
            txtObicKanaName.Text = string.Empty;
            txtObicCompanyCode.Text = string.Empty;

            dgvMain.DataSource = new DataTable();
            lblRowCount.Text = string.Empty;
            GC.Collect();
        }

        private void SetMenuStripForeColor(Color c)
        {
            menuStrip1.ForeColor = Model.Common.Tools.GetForeColorBasedOnWCAG(c);
        }

        private void SearchIRN()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                dgvMain.Enabled = false;

                // 入力文字列の調整
                string txtBuf = txtInvoice.Text.ToUpper().Replace("T", string.Empty).Insert(0, "T");
                txtInvoice.Text = System.Text.RegularExpressions.Regex.Replace(txtBuf, "[^T0-9]", string.Empty);

                // データ取得
                DataTable dt = Model.DB.SqlManager.SelectInvoiceRegisterNumber(
                    regNum: txtInvoice.Text
                    , name: txtName.Text
                    , address: txtAddress.Text
                    , status: int.Parse(cmbStatus.SelectedValue?.ToString() ?? "-1")
                    , personality: int.Parse(cmbPersonality.SelectedValue?.ToString() ?? "-1")
                    , domesticOrOverseas: int.Parse(cmbDomestic.SelectedValue?.ToString() ?? "-1")
                    );
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("該当するデータがありません", _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMain.DataSource = new DataTable();
                    return;
                }
                // ソースセット
                dgvMain.DataSource = dt;
                lblRowCount.Text = $@"{(dt.Rows.Count == 1000 ? "上位" : string.Empty)} {dt.Rows.Count}件";
                GC.Collect();

                // 列非表示
                if (dgvMain.Columns["訂正区分"] != null) { dgvMain.Columns["訂正区分"].Visible = false; }
                if (dgvMain.Columns["最新履歴"] != null) { dgvMain.Columns["最新履歴"].Visible = false; }

                // 列固定
                if (dgvMain.Columns["登録番号"] != null && dgvMain.Columns["登録番号"].Index == 0) { dgvMain.Columns["登録番号"].Frozen = true; }
                dgvMain.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SearchObic()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                dgvMain.Enabled = false;
                // 入力文字列の調整
                string txtBuf = txtObicCode.Text.ToUpper();
                txtObicCode.Text = System.Text.RegularExpressions.Regex.Replace(txtBuf, "[^A-Z0-9]", string.Empty);
                txtBuf = string.Empty;
                txtBuf = txtObicDeptCode.Text.ToUpper();
                txtObicDeptCode.Text = System.Text.RegularExpressions.Regex.Replace(txtBuf, "[^A-Z0-9-]", string.Empty);
                txtBuf = string.Empty;
                txtBuf = txtObicCompanyCode.Text.ToUpper();
                txtObicCompanyCode.Text = System.Text.RegularExpressions.Regex.Replace(txtBuf, "[^A-Z0-9]", string.Empty);

                DataTable dt = Model.DB.SqlManager.SelectObicMaster(
                    kana: txtObicKanaName.Text
                    , officialName: txtObicName.Text
                    , domesticName: txtObicName.Text
                    , code: txtObicCode.Text
                    , comCode: txtObicCompanyCode.Text
                    , deptCode: txtObicDeptCode.Text
                    , deptName: txtObicDeptName.Text
                    );
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("該当するデータがありません", _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMain.DataSource = new DataTable();
                    return;
                }
                DataTable newDt = new();
                newDt.Columns.Add("取引先コード", typeof(string));
                newDt.Columns.Add("取引先正式名", typeof(string));
                newDt.Columns.Add("取引先名", typeof(string));
                newDt.Columns.Add("取引先カナ名", typeof(string));
                newDt.Columns.Add("出金支払先コード（入金請求先コード）", typeof(string));
                newDt.Columns.Add("代表事業所コード", typeof(string));
                newDt.Columns.Add("事業所名", typeof(string));
                newDt.Columns.Add("部署コード", typeof(string));
                newDt.Columns.Add("部署名", typeof(string));
                newDt.Columns.Add("法人コード", typeof(string));
                //newDt.Columns.Add("担当者名", typeof(string));
                newDt.Columns.Add("会計用取引先コード", typeof(string));
                newDt.Columns.Add("インボイス番号", typeof(string));

                newDt = dt.AsEnumerable()
                    .GroupBy(grp => new
                    {
                        Code = grp.Field<string>("CODE"),
                        Name = grp.Field<string>("取引正式名"),
                        InName = grp.Field<string>("取引名"),
                        KanaName = grp.Field<string>("取引カナ名"),
                        SCode = grp.Field<string>("出金支払先コード"),
                        DCode = grp.Field<string>("代表事業所コード"),
                        DName = grp.Field<string>("事業所名"),
                        BCode = grp.Field<string>("部署コード"),
                        BName = grp.Field<string>("部署名"),
                        HCode = grp.Field<string>("法人コード"),
                        //TName = grp.Field<string>("担当者名1"),
                        KCode = grp.Field<string>("会計用取引先コード"),
                        INum = grp.Field<string>("インボイス番号")
                    })
                    .Select(s =>
                    {
                        DataRow dr = newDt.NewRow();
                        dr["取引先コード"] = s.Key.Code;
                        dr["取引先正式名"] = s.Key.Name;
                        dr["取引先名"] = s.Key.InName;
                        dr["取引先カナ名"] = s.Key.KanaName;
                        dr["出金支払先コード（入金請求先コード）"] = s.Key.SCode;
                        dr["代表事業所コード"] = s.Key.DCode;
                        dr["事業所名"] = s.Key.DName;
                        dr["部署コード"] = s.Key.BCode;
                        dr["部署名"] = s.Key.BName;
                        dr["法人コード"] = s.Key.HCode;
                        //dr["担当者名"] = s.Key.TName;
                        dr["会計用取引先コード"] = s.Key.KCode;
                        dr["インボイス番号"] = s.Key.INum;
                        return dr;
                    })
                    .CopyToDataTable();
                dgvMain.DataSource = newDt;
                lblRowCount.Text = $@"{(dt.Rows.Count == 1000 ? "上位" : string.Empty)} {dt.Rows.Count}件";
                GC.Collect();

                // 列固定
                if (dgvMain.Columns["取引先コード"] != null && dgvMain.Columns["取引先コード"].Index == 0) { dgvMain.Columns["取引先コード"].Frozen = true; }
                dgvMain.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static void SwitchVisibleLocation(
            Control active,
            Control passive)
        {
            if (active.Tag != null && active.Tag.ToString() == "active") return;
            active.BringToFront();
            active.Visible = true;
            passive.Visible = false;
            Point pPast = active.Location;
            Point pDest = passive.Location;
            active.Location = pDest;
            passive.Location = pPast;
            active.Tag = "active";
            passive.Tag = "passive";
        }
    }
}
