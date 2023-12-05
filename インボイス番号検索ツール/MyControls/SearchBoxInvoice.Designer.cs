namespace インボイス番号検索ツール.MyControls
{
    partial class SearchBoxInvoice
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            label7 = new System.Windows.Forms.Label();
            linkLabel2 = new System.Windows.Forms.LinkLabel();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            btnReset = new System.Windows.Forms.Button();
            lblRowCount = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            cmbDomestic = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            cmbPersonality = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cmbStatus = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            txtAddress = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtInvoice = new System.Windows.Forms.TextBox();
            dgvMain = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(994, 504);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(50, 15);
            label7.TabIndex = 37;
            label7.Text = "ver 1.0.6";
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new System.Drawing.Point(939, 62);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new System.Drawing.Size(102, 15);
            linkLabel2.TabIndex = 36;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "公表データ定義PDF";
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(934, 36);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(107, 15);
            linkLabel1.TabIndex = 35;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "国税庁公表データDL";
            // 
            // btnReset
            // 
            btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReset.Location = new System.Drawing.Point(960, 91);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(81, 27);
            btnReset.TabIndex = 34;
            btnReset.Text = "検索リセット";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // lblRowCount
            // 
            lblRowCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRowCount.AutoSize = true;
            lblRowCount.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRowCount.Location = new System.Drawing.Point(17, 504);
            lblRowCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRowCount.Name = "lblRowCount";
            lblRowCount.Size = new System.Drawing.Size(0, 15);
            lblRowCount.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(464, 94);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 15);
            label6.TabIndex = 32;
            label6.Text = "国内外区分";
            // 
            // cmbDomestic
            // 
            cmbDomestic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDomestic.FormattingEnabled = true;
            cmbDomestic.Location = new System.Drawing.Point(572, 90);
            cmbDomestic.Name = "cmbDomestic";
            cmbDomestic.Size = new System.Drawing.Size(121, 23);
            cmbDomestic.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(463, 62);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(55, 15);
            label5.TabIndex = 30;
            label5.Text = "人格区分";
            // 
            // cmbPersonality
            // 
            cmbPersonality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPersonality.FormattingEnabled = true;
            cmbPersonality.Location = new System.Drawing.Point(572, 59);
            cmbPersonality.Name = "cmbPersonality";
            cmbPersonality.Size = new System.Drawing.Size(121, 23);
            cmbPersonality.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(464, 32);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 15);
            label4.TabIndex = 28;
            label4.Text = "事業者処理区分";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new System.Drawing.Point(572, 28);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new System.Drawing.Size(121, 23);
            cmbStatus.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(27, 90);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(31, 15);
            label3.TabIndex = 26;
            label3.Text = "住所";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            txtAddress.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtAddress.Location = new System.Drawing.Point(103, 86);
            txtAddress.Margin = new System.Windows.Forms.Padding(4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(310, 23);
            txtAddress.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(27, 59);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 15);
            label2.TabIndex = 24;
            label2.Text = "名称";
            // 
            // txtName
            // 
            txtName.BackColor = System.Drawing.SystemColors.ControlLight;
            txtName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtName.Location = new System.Drawing.Point(103, 55);
            txtName.Margin = new System.Windows.Forms.Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(310, 23);
            txtName.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(27, 28);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 15);
            label1.TabIndex = 22;
            label1.Text = "登録番号";
            // 
            // txtInvoice
            // 
            txtInvoice.BackColor = System.Drawing.SystemColors.ControlLight;
            txtInvoice.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtInvoice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtInvoice.Location = new System.Drawing.Point(103, 24);
            txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            txtInvoice.Name = "txtInvoice";
            txtInvoice.Size = new System.Drawing.Size(137, 23);
            txtInvoice.TabIndex = 21;
            // 
            // dgvMain
            // 
            dgvMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Location = new System.Drawing.Point(14, 125);
            dgvMain.Margin = new System.Windows.Forms.Padding(4);
            dgvMain.Name = "dgvMain";
            dgvMain.RowTemplate.Height = 21;
            dgvMain.Size = new System.Drawing.Size(1027, 370);
            dgvMain.TabIndex = 20;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(btnReset);
            Controls.Add(lblRowCount);
            Controls.Add(label6);
            Controls.Add(cmbDomestic);
            Controls.Add(label5);
            Controls.Add(cmbPersonality);
            Controls.Add(label4);
            Controls.Add(cmbStatus);
            Controls.Add(label3);
            Controls.Add(txtAddress);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(txtInvoice);
            Controls.Add(dgvMain);
            Name = "UserControl1";
            Size = new System.Drawing.Size(1055, 537);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDomestic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPersonality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.DataGridView dgvMain;
    }
}
