namespace EncryptVideo
{
    partial class EncryptVideoForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.txtEncrytedPath = new System.Windows.Forms.TextBox();
            this.btnVideoPath = new System.Windows.Forms.Button();
            this.btnEncryptedPath = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fbVideoDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fbEncrytedDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoPath.Location = new System.Drawing.Point(110, 33);
            this.txtVideoPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.Size = new System.Drawing.Size(317, 22);
            this.txtVideoPath.TabIndex = 0;
            // 
            // txtEncrytedPath
            // 
            this.txtEncrytedPath.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncrytedPath.Location = new System.Drawing.Point(110, 63);
            this.txtEncrytedPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEncrytedPath.Name = "txtEncrytedPath";
            this.txtEncrytedPath.Size = new System.Drawing.Size(317, 22);
            this.txtEncrytedPath.TabIndex = 1;
            // 
            // btnVideoPath
            // 
            this.btnVideoPath.Location = new System.Drawing.Point(433, 33);
            this.btnVideoPath.Name = "btnVideoPath";
            this.btnVideoPath.Size = new System.Drawing.Size(75, 23);
            this.btnVideoPath.TabIndex = 2;
            this.btnVideoPath.Text = "Browse...";
            this.btnVideoPath.UseVisualStyleBackColor = true;
            this.btnVideoPath.Click += new System.EventHandler(this.btnVideoPath_Click);
            // 
            // btnEncryptedPath
            // 
            this.btnEncryptedPath.Location = new System.Drawing.Point(433, 63);
            this.btnEncryptedPath.Name = "btnEncryptedPath";
            this.btnEncryptedPath.Size = new System.Drawing.Size(75, 23);
            this.btnEncryptedPath.TabIndex = 3;
            this.btnEncryptedPath.Text = "Browse...";
            this.btnEncryptedPath.UseVisualStyleBackColor = true;
            this.btnEncryptedPath.Click += new System.EventHandler(this.btnEncryptedPath_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(205, 103);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(110, 31);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Video Files Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Encrypted Path";
            // 
            // fbVideoDialog
            // 
            this.fbVideoDialog.Description = "Chọn đường dẫn tới thư mục chứa video.";
            this.fbVideoDialog.ShowNewFolderButton = false;
            // 
            // fbEncrytedDialog
            // 
            this.fbEncrytedDialog.Description = "Chọn đường dẫn tới thư mục để lưu encrypted videos.";
            // 
            // EncryptVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 146);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnEncryptedPath);
            this.Controls.Add(this.btnVideoPath);
            this.Controls.Add(this.txtEncrytedPath);
            this.Controls.Add(this.txtVideoPath);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptVideoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encrypt Video";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVideoPath;
        private System.Windows.Forms.TextBox txtEncrytedPath;
        private System.Windows.Forms.Button btnVideoPath;
        private System.Windows.Forms.Button btnEncryptedPath;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog fbVideoDialog;
        private System.Windows.Forms.FolderBrowserDialog fbEncrytedDialog;
    }
}

