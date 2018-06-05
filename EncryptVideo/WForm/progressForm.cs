using EncryptVideo.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EncryptVideo.WForm
{
    public partial class progressForm : Form
    {
        private Stream _InputStream;
        private Stream _OutputStream;
        private bool _AllowClose = false;

        private bool _cancelled = false;
        public bool Cancelled
        {
            get
            {
                return _cancelled;
            }
        }

        public progressForm(Stream InputStream,string fileName, Stream OutputStream)
        {
            InitializeComponent();

            lbFileName.Text = fileName;
            _InputStream = InputStream;
            _OutputStream = OutputStream;

            bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_InputStream.Length == 0)
                return;

            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            using (BinaryWriter Writer = new BinaryWriter(_OutputStream))
            {
                byte[] Buf = new byte[VDCSDK.App.ChunkSize];

                List<int> SourceChunkSizeList = new List<int>();
                List<int> EncryptedChunkSizeList = new List<int>();

                int ReadBytes;
                long nTotalReadBytes = 0;
                while ((ReadBytes = _InputStream.Read(Buf, 0, Buf.Length)) > 0)
                {
                    if (bgWorker.CancellationPending)
                        break;

                    byte[] EncryptedData = VDCSDK.App.EncryptVideo(Buf, KeyGen.Key,KeyGen.IV, ReadBytes);
                    _OutputStream.Write(EncryptedData, 0, EncryptedData.Length);

                    SourceChunkSizeList.Add(ReadBytes);
                    EncryptedChunkSizeList.Add(EncryptedData.Length);

                    nTotalReadBytes += ReadBytes;
                    bgWorker.ReportProgress((int)(nTotalReadBytes * 100 / _InputStream.Length));
                }

                foreach (int SourceChunkSize in SourceChunkSizeList)
                {
                    Writer.Write(SourceChunkSize);
                }

                foreach (int EncryptedChunkSize in EncryptedChunkSizeList)
                {
                    Writer.Write(EncryptedChunkSize);
                }

                Writer.Write((int)EncryptedChunkSizeList.Count);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _AllowClose = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            _cancelled = true;
            bgWorker.CancelAsync();
        }

        private void progressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_AllowClose)
                e.Cancel = true;
        }
    }
}
