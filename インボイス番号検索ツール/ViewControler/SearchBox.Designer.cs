namespace インボイス番号検索ツール.ViewControler
{
    partial class SearchBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBox));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            clrDlg = new System.Windows.Forms.ColorDialog();
            btnAdmin = new System.Windows.Forms.Button();
            btnSetting = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuInvoice = new System.Windows.Forms.ToolStripMenuItem();
            menuObic = new System.Windows.Forms.ToolStripMenuItem();
            pnlHead = new System.Windows.Forms.Panel();
            lblVersion = new System.Windows.Forms.Label();
            txtInvoice = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtAddress = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            cmbStatus = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cmbPersonality = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            cmbDomestic = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            lblRowCount = new System.Windows.Forms.Label();
            btnReset = new System.Windows.Forms.Button();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            linkLabel2 = new System.Windows.Forms.LinkLabel();
            dgvMain = new System.Windows.Forms.DataGridView();
            pnlInvoice = new System.Windows.Forms.Panel();
            pnlObic = new System.Windows.Forms.Panel();
            txtObicDeptName = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            txtObicDeptCode = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtObicCompanyCode = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            txtObicKanaName = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            txtObicName = new System.Windows.Forms.TextBox();
            label13 = new System.Windows.Forms.Label();
            txtObicCode = new System.Windows.Forms.TextBox();
            menuStrip1.SuspendLayout();
            pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            pnlInvoice.SuspendLayout();
            pnlObic.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdmin
            // 
            btnAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAdmin.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnAdmin.Location = new System.Drawing.Point(1002, 5);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new System.Drawing.Size(39, 26);
            btnAdmin.TabIndex = 102;
            btnAdmin.Text = "管理";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += BtnAdmin_Click;
            // 
            // btnSetting
            // 
            btnSetting.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSetting.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnSetting.Image = (System.Drawing.Image)resources.GetObject("btnSetting.Image");
            btnSetting.Location = new System.Drawing.Point(969, 5);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new System.Drawing.Size(28, 26);
            btnSetting.TabIndex = 101;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += BtnSetting_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuInvoice, menuObic });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1055, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuInvoice
            // 
            menuInvoice.Name = "menuInvoice";
            menuInvoice.Size = new System.Drawing.Size(81, 31);
            menuInvoice.Text = "国税庁データ";
            menuInvoice.Click += MenuInvoice_Click;
            // 
            // menuObic
            // 
            menuObic.Name = "menuObic";
            menuObic.Size = new System.Drawing.Size(71, 31);
            menuObic.Text = "OBICデータ";
            menuObic.Click += MenuObic_Click;
            // 
            // pnlHead
            // 
            pnlHead.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHead.BackColor = System.Drawing.SystemColors.Window;
            pnlHead.Controls.Add(btnSetting);
            pnlHead.Controls.Add(btnAdmin);
            pnlHead.Controls.Add(menuStrip1);
            pnlHead.Location = new System.Drawing.Point(0, 0);
            pnlHead.Name = "pnlHead";
            pnlHead.Size = new System.Drawing.Size(1055, 35);
            pnlHead.TabIndex = 101;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblVersion.AutoSize = true;
            lblVersion.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblVersion.Location = new System.Drawing.Point(991, 528);
            lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(45, 15);
            lblVersion.TabIndex = 19;
            lblVersion.Text = "Version";
            // 
            // txtInvoice
            // 
            txtInvoice.BackColor = System.Drawing.SystemColors.ControlLight;
            txtInvoice.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtInvoice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtInvoice.Location = new System.Drawing.Point(99, 12);
            txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            txtInvoice.Name = "txtInvoice";
            txtInvoice.Size = new System.Drawing.Size(121, 23);
            txtInvoice.TabIndex = 1;
            txtInvoice.KeyPress += TxtInvoice_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(23, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 15);
            label1.TabIndex = 2;
            label1.Text = "登録番号";
            // 
            // txtName
            // 
            txtName.BackColor = System.Drawing.SystemColors.ControlLight;
            txtName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtName.Location = new System.Drawing.Point(99, 43);
            txtName.Margin = new System.Windows.Forms.Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(310, 23);
            txtName.TabIndex = 3;
            txtName.KeyPress += TxtName_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(23, 47);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "名称";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            txtAddress.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtAddress.Location = new System.Drawing.Point(99, 74);
            txtAddress.Margin = new System.Windows.Forms.Padding(4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(310, 23);
            txtAddress.TabIndex = 5;
            txtAddress.KeyPress += TxtAddress_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(23, 78);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(31, 15);
            label3.TabIndex = 6;
            label3.Text = "住所";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new System.Drawing.Point(568, 13);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new System.Drawing.Size(121, 23);
            cmbStatus.TabIndex = 7;
            cmbStatus.SelectionChangeCommitted += CmbStatus_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(460, 17);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 15);
            label4.TabIndex = 8;
            label4.Text = "事業者処理区分";
            // 
            // cmbPersonality
            // 
            cmbPersonality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPersonality.FormattingEnabled = true;
            cmbPersonality.Location = new System.Drawing.Point(568, 43);
            cmbPersonality.Name = "cmbPersonality";
            cmbPersonality.Size = new System.Drawing.Size(121, 23);
            cmbPersonality.TabIndex = 9;
            cmbPersonality.SelectionChangeCommitted += CmbPersonality_SelectionChangeCommitted;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(459, 46);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(55, 15);
            label5.TabIndex = 10;
            label5.Text = "人格区分";
            // 
            // cmbDomestic
            // 
            cmbDomestic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDomestic.FormattingEnabled = true;
            cmbDomestic.Location = new System.Drawing.Point(568, 74);
            cmbDomestic.Name = "cmbDomestic";
            cmbDomestic.Size = new System.Drawing.Size(121, 23);
            cmbDomestic.TabIndex = 11;
            cmbDomestic.SelectionChangeCommitted += CmbDomestic_SelectionChangeCommitted;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(460, 78);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 15);
            label6.TabIndex = 12;
            label6.Text = "国内外区分";
            // 
            // lblRowCount
            // 
            lblRowCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRowCount.AutoSize = true;
            lblRowCount.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRowCount.Location = new System.Drawing.Point(14, 528);
            lblRowCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRowCount.Name = "lblRowCount";
            lblRowCount.Size = new System.Drawing.Size(31, 15);
            lblRowCount.TabIndex = 13;
            lblRowCount.Text = "件数";
            // 
            // btnReset
            // 
            btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReset.Location = new System.Drawing.Point(960, 115);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(81, 27);
            btnReset.TabIndex = 99;
            btnReset.Text = "検索リセット";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(931, 60);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(107, 15);
            linkLabel1.TabIndex = 97;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "国税庁公表データDL";
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new System.Drawing.Point(936, 86);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new System.Drawing.Size(102, 15);
            linkLabel2.TabIndex = 98;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "公表データ定義PDF";
            linkLabel2.LinkClicked += LinkLabel2_LinkClicked;
            // 
            // dgvMain
            // 
            dgvMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMain.Location = new System.Drawing.Point(11, 149);
            dgvMain.Margin = new System.Windows.Forms.Padding(4);
            dgvMain.Name = "dgvMain";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMain.RowTemplate.Height = 21;
            dgvMain.Size = new System.Drawing.Size(1027, 370);
            dgvMain.TabIndex = 100;
            dgvMain.CellDoubleClick += DgvMain_CellDoubleClick;
            // 
            // pnlInvoice
            // 
            pnlInvoice.Controls.Add(label6);
            pnlInvoice.Controls.Add(cmbDomestic);
            pnlInvoice.Controls.Add(label5);
            pnlInvoice.Controls.Add(cmbPersonality);
            pnlInvoice.Controls.Add(label4);
            pnlInvoice.Controls.Add(cmbStatus);
            pnlInvoice.Controls.Add(label3);
            pnlInvoice.Controls.Add(txtAddress);
            pnlInvoice.Controls.Add(label2);
            pnlInvoice.Controls.Add(txtName);
            pnlInvoice.Controls.Add(label1);
            pnlInvoice.Controls.Add(txtInvoice);
            pnlInvoice.Location = new System.Drawing.Point(1, 35);
            pnlInvoice.Name = "pnlInvoice";
            pnlInvoice.Size = new System.Drawing.Size(931, 113);
            pnlInvoice.TabIndex = 20;
            pnlInvoice.Tag = "active";
            // 
            // pnlObic
            // 
            pnlObic.Controls.Add(txtObicDeptName);
            pnlObic.Controls.Add(label7);
            pnlObic.Controls.Add(txtObicDeptCode);
            pnlObic.Controls.Add(label8);
            pnlObic.Controls.Add(txtObicCompanyCode);
            pnlObic.Controls.Add(label10);
            pnlObic.Controls.Add(label11);
            pnlObic.Controls.Add(txtObicKanaName);
            pnlObic.Controls.Add(label12);
            pnlObic.Controls.Add(txtObicName);
            pnlObic.Controls.Add(label13);
            pnlObic.Controls.Add(txtObicCode);
            pnlObic.Location = new System.Drawing.Point(1, 149);
            pnlObic.Name = "pnlObic";
            pnlObic.Size = new System.Drawing.Size(931, 113);
            pnlObic.TabIndex = 21;
            pnlObic.Tag = "passive";
            pnlObic.Visible = false;
            // 
            // txtObicDeptName
            // 
            txtObicDeptName.BackColor = System.Drawing.SystemColors.ControlLight;
            txtObicDeptName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtObicDeptName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            txtObicDeptName.Location = new System.Drawing.Point(568, 43);
            txtObicDeptName.Margin = new System.Windows.Forms.Padding(4);
            txtObicDeptName.Name = "txtObicDeptName";
            txtObicDeptName.Size = new System.Drawing.Size(121, 23);
            txtObicDeptName.TabIndex = 7;
            txtObicDeptName.KeyPress += TxtObicDeptName_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(460, 47);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(67, 15);
            label7.TabIndex = 12;
            label7.Text = "担当部署名";
            // 
            // txtObicDeptCode
            // 
            txtObicDeptCode.BackColor = System.Drawing.SystemColors.ControlLight;
            txtObicDeptCode.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtObicDeptCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtObicDeptCode.Location = new System.Drawing.Point(568, 13);
            txtObicDeptCode.Margin = new System.Windows.Forms.Padding(4);
            txtObicDeptCode.Name = "txtObicDeptCode";
            txtObicDeptCode.Size = new System.Drawing.Size(121, 23);
            txtObicDeptCode.TabIndex = 6;
            txtObicDeptCode.KeyPress += TxtObicDeptCode_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(460, 78);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(55, 15);
            label8.TabIndex = 10;
            label8.Text = "法人コード";
            // 
            // txtObicCompanyCode
            // 
            txtObicCompanyCode.BackColor = System.Drawing.SystemColors.ControlLight;
            txtObicCompanyCode.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtObicCompanyCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtObicCompanyCode.Location = new System.Drawing.Point(568, 74);
            txtObicCompanyCode.Margin = new System.Windows.Forms.Padding(4);
            txtObicCompanyCode.Name = "txtObicCompanyCode";
            txtObicCompanyCode.Size = new System.Drawing.Size(121, 23);
            txtObicCompanyCode.TabIndex = 8;
            txtObicCompanyCode.KeyPress += TxtObicCompanyCode_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(460, 16);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(79, 15);
            label10.TabIndex = 8;
            label10.Text = "担当部署コード";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(23, 78);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(73, 15);
            label11.TabIndex = 6;
            label11.Text = "取引先カナ名";
            // 
            // txtObicKanaName
            // 
            txtObicKanaName.BackColor = System.Drawing.SystemColors.ControlLight;
            txtObicKanaName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtObicKanaName.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            txtObicKanaName.Location = new System.Drawing.Point(99, 74);
            txtObicKanaName.Margin = new System.Windows.Forms.Padding(4);
            txtObicKanaName.Name = "txtObicKanaName";
            txtObicKanaName.Size = new System.Drawing.Size(310, 23);
            txtObicKanaName.TabIndex = 5;
            txtObicKanaName.KeyPress += TxtObicKanaName_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(23, 47);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(55, 15);
            label12.TabIndex = 4;
            label12.Text = "取引先名";
            // 
            // txtObicName
            // 
            txtObicName.BackColor = System.Drawing.SystemColors.ControlLight;
            txtObicName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtObicName.Location = new System.Drawing.Point(99, 43);
            txtObicName.Margin = new System.Windows.Forms.Padding(4);
            txtObicName.Name = "txtObicName";
            txtObicName.Size = new System.Drawing.Size(310, 23);
            txtObicName.TabIndex = 3;
            txtObicName.KeyPress += TxtObicName_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(23, 16);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(67, 15);
            label13.TabIndex = 2;
            label13.Text = "取引先コード";
            // 
            // txtObicCode
            // 
            txtObicCode.BackColor = System.Drawing.SystemColors.ControlLight;
            txtObicCode.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtObicCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtObicCode.Location = new System.Drawing.Point(99, 12);
            txtObicCode.Margin = new System.Windows.Forms.Padding(4);
            txtObicCode.Name = "txtObicCode";
            txtObicCode.Size = new System.Drawing.Size(121, 23);
            txtObicCode.TabIndex = 1;
            txtObicCode.KeyPress += TxtObicCode_KeyPress;
            // 
            // SearchBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(1055, 552);
            Controls.Add(pnlObic);
            Controls.Add(pnlInvoice);
            Controls.Add(lblVersion);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(btnReset);
            Controls.Add(lblRowCount);
            Controls.Add(dgvMain);
            Controls.Add(pnlHead);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(851, 459);
            Name = "SearchBox";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "インボイス番号検索";
            Load += SearchBox_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            pnlInvoice.ResumeLayout(false);
            pnlInvoice.PerformLayout();
            pnlObic.ResumeLayout(false);
            pnlObic.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ColorDialog clrDlg;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.ToolStripMenuItem menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem menuObic;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPersonality;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDomestic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Panel pnlObic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObicCompanyCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObicKanaName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtObicName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtObicCode;
        private System.Windows.Forms.TextBox txtObicDeptName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObicDeptCode;
    }
}