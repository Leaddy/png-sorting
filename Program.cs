using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;


namespace ResimSira
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.SizeGripStyle = SizeGripStyle.Hide;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string klasorYolu = folderBrowser.SelectedPath;

                if (Directory.Exists(klasorYolu))
                {
                    string[] pngDosyaları = Directory.GetFiles(klasorYolu, "*.png");

                    var siraliPngDosyaları = pngDosyaları
                        .Select(dosyaYolu => new FileInfo(dosyaYolu))
                        .OrderBy(dosya => dosya.CreationTime)
                        .ToArray();


                    for (int i = 0; i < siraliPngDosyaları.Length; i++)
                    {
                        FileInfo dosya = siraliPngDosyaları[i];
                        string yeniIsim = (i + 1).ToString() + ".png";
                        string hedefYol = Path.Combine(klasorYolu, yeniIsim);
                        dosya.MoveTo(hedefYol);
                    }

                    MessageBox.Show("Dosyalar başarıyla yeniden adlandırıldı.");
                }
                else
                {
                    MessageBox.Show("Seçilen klasörde .png dosyaları bulunamadı.");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://linktr.ee/leaddy";
            Process.Start(url);
        }
    }
}
