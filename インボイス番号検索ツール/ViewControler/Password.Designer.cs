namespace インボイス番号検索ツール.ViewControler
{
    partial class Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
            label1 = new System.Windows.Forms.Label();
            txtPass = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(49, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(113, 15);
            label1.TabIndex = 0;
            label1.Text = "データ管理者パスワード";
            // 
            // txtPass
            // 
            txtPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtPass.BackColor = System.Drawing.SystemColors.ControlLight;
            txtPass.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtPass.Location = new System.Drawing.Point(65, 56);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.Size = new System.Drawing.Size(129, 23);
            txtPass.TabIndex = 1;
            txtPass.TextChanged += TxtPass_TextChanged;
            // 
            // FrmPassword
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(252, 114);
            Controls.Add(txtPass);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(203, 151);
            Name = "FrmPassword";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "パスワード入力";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPass;
    }
}