using EncryptVideo.WForm;
using log4net;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EncryptVideo
{
    public partial class EncryptVideoForm : Form
    {
        private ILog _log;
        public EncryptVideoForm(ILog log)
        {
            InitializeComponent();
            _log = log;
        }

        private void btnVideoPath_Click(object sender, EventArgs e)
        {
            DialogResult result = fbVideoDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                txtVideoPath.Text = fbVideoDialog.SelectedPath;

                if (0 == txtEncrytedPath.Text.Length)
                {
                    // Determine whether the directory exists.
                    if (!Directory.Exists(txtVideoPath.Text + @"\Enc"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(txtVideoPath.Text + @"\Enc");
                    }
                    // Try to create the directory.
                    
                    txtEncrytedPath.Text = txtVideoPath.Text + @"\Enc";
                }     
            }
        }

        private void btnEncryptedPath_Click(object sender, EventArgs e)
        {
            if (0 != txtEncrytedPath.Text.Length) {
                fbEncrytedDialog.SelectedPath = txtEncrytedPath.Text;
            }

            DialogResult result = fbEncrytedDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtEncrytedPath.Text = fbEncrytedDialog.SelectedPath;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {   
            if(txtVideoPath.Text == "")
            {
                MessageBox.Show("Thư mục video không được phép trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtEncrytedPath.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thư mục để lưu video.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = 0;
            string[] files = Directory.GetFiles(txtVideoPath.Text);
            string[] extensions = { ".mp4",".MP4",".3gp",".3GP" };
            string outputCSV = txtEncrytedPath.Text + @"\EncryptedVideo.csv";
            try
            {
                using (var stream = File.CreateText(outputCSV))
                {
                    stream.WriteLine("File Name,Encrypted Name");

                    foreach (string file in files)
                    {
                        string extension;

                        try
                        {
                            extension = Path.GetExtension(file);
                            int pos = Array.IndexOf(extensions, extension);

                            if (pos > -1)
                            {
                                string fileName = Path.GetFileNameWithoutExtension(file);
                                string prdKeymd5 = null;

                                using (MD5 md5Hash = MD5.Create())
                                {
                                    prdKeymd5 = VDCSDK.App.GetMd5Hash(md5Hash, fileName);
                                }

                                string filePath = txtEncrytedPath.Text + @"\" + prdKeymd5;
                                if (File.Exists(filePath))
                                {
                                    if (DialogResult.No == MessageBox.Show(string.Format("The file {0} already exists.\r\nWould you like to overwrite it?", prdKeymd5), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                                        continue;
                                }

                                using (FileStream InputVideoFile = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    using (FileStream EncryptedVideoFile = new FileStream(filePath, FileMode.Create))
                                    {
                                        progressForm frm = new progressForm(InputVideoFile, fileName, EncryptedVideoFile);
                                        frm.ShowDialog();

                                        string csvRow = string.Format("{0},{1}", fileName, prdKeymd5);
                                        stream.WriteLine(csvRow);

                                        count++;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex.Message);
                        }
                    }
                }

                if (count == 0)
                {
                    MessageBox.Show("Thư mục không chứa video hoặc video không được hỗ trợ.\r\nVui lòng chọn thư mục khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _log.Info(String.Format("{0} files have encypted.", count));
                    MessageBox.Show(String.Format("{0} files have encypted.", count), "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                _log.Error(ex.Message);
                MessageBox.Show("Xảy ra lỗi khi encrypt video.\r\nVui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
