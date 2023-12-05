using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace インボイス番号検索ツール.ViewControler
{
    public partial class DgvViewer : Form
    {
        private readonly string _msgTitle = "インボイス番号検索ツール";
        private readonly string _invoiceNum = string.Empty;
        public DgvViewer(string invoiceNum = "")
        {
            InitializeComponent();
            Model.Common.Tools.SetUpDataGridView(dgvMain);
            _invoiceNum = invoiceNum.Replace("T", string.Empty);
        }

        private void DgvViewer_Load(object sender, EventArgs e)
        {
            DataTable dt = Model.DB.SqlManager.SelectObicMaster(invoiceNum: _invoiceNum);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("このインボイス番号が紐づけられたOBICマスタは存在しません。", _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
        }

        private void DgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            string obicCode = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
            Form dlg = new ObicDetail(obicCode);
            dlg.ShowDialog();
        }
    }
}