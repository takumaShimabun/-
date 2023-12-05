namespace インボイス番号検索ツール.ViewControler
{
    partial class UnZipper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnZipper));
            pnlDropArea = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            btnDeleteWk = new System.Windows.Forms.Button();
            btnInsertWk = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            pnlDropArea.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDropArea
            // 
            pnlDropArea.AllowDrop = true;
            pnlDropArea.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlDropArea.BackColor = System.Drawing.SystemColors.ControlDark;
            pnlDropArea.Controls.Add(label1);
            pnlDropArea.Location = new System.Drawing.Point(14, 15);
            pnlDropArea.Margin = new System.Windows.Forms.Padding(4);
            pnlDropArea.Name = "pnlDropArea";
            pnlDropArea.Size = new System.Drawing.Size(246, 263);
            pnlDropArea.TabIndex = 0;
            pnlDropArea.DragDrop += PnlDropArea_DragDrop;
            pnlDropArea.DragEnter += PnlDropArea_DragEnter;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 125);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(193, 15);
            label1.TabIndex = 0;
            label1.Text = "ここにダウンロードしたzipファイルをドロップ";
            // 
            // btnDeleteWk
            // 
            btnDeleteWk.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteWk.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDeleteWk.Location = new System.Drawing.Point(267, 15);
            btnDeleteWk.Name = "btnDeleteWk";
            btnDeleteWk.Size = new System.Drawing.Size(189, 84);
            btnDeleteWk.TabIndex = 1;
            btnDeleteWk.Text = "Delete WorkTable";
            btnDeleteWk.UseVisualStyleBackColor = true;
            btnDeleteWk.Click += BtnDeleteWk_Click;
            // 
            // btnInsertWk
            // 
            btnInsertWk.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnInsertWk.Cursor = System.Windows.Forms.Cursors.Hand;
            btnInsertWk.Location = new System.Drawing.Point(267, 105);
            btnInsertWk.Name = "btnInsertWk";
            btnInsertWk.Size = new System.Drawing.Size(189, 84);
            btnInsertWk.TabIndex = 2;
            btnInsertWk.Text = "Bulk Insert WorkTable";
            btnInsertWk.UseVisualStyleBackColor = true;
            btnInsertWk.Click += BtnInsertWk_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            btnUpdate.Location = new System.Drawing.Point(267, 195);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(189, 84);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update Master";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // FrmUnZipper
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(466, 293);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsertWk);
            Controls.Add(btnDeleteWk);
            Controls.Add(pnlDropArea);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(482, 332);
            Name = "FrmUnZipper";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "国税庁DLデータ洗替";
            pnlDropArea.ResumeLayout(false);
            pnlDropArea.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlDropArea;
        private System.Windows.Forms.Button btnDeleteWk;
        private System.Windows.Forms.Button btnInsertWk;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
    }
}