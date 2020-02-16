using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CorelDraw2019KorPatch
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResourceSave();
        }

        private void ResourceSave()
        {
            string strFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                   @"\AppData\Roaming\Corel\CorelDRAW Graphics Suite 2019\Draw\Workspace\_default.cdws";
            // _default.cdws파일이 존재하면 CorelDraw2019가 설치된걸로 간주
            FileInfo fileInfo = new FileInfo(strFolder);
            if (fileInfo.Exists)
            {
                try
                {
                    var _default = Properties.Resources._default;

                    FileStream file = new FileStream(strFolder, FileMode.Create);

                    file.Write(_default, 0, _default.Length);
                    file.Close();
                    FinalBeep("CorelDraw2019가 한글화가 되었습니다!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error Accessing Resourc!");
                }
            }
            else
            {
                FinalBeep("CorelDraw2019를 설치하고 실행하세요!");
            }
        }

            private void FinalBeep(string msg)
        {
            Console.Beep();
            btnStart.Location = new Point(30, btnStart.Location.Y);
            btnStart.Size = new Size(303, 46);
            btnStart.ForeColor = Color.Red;
            btnStart.Text = msg;
            Delay(2000);
            this.Close();
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        //private void Filecopy()
        //{
        //    string fileName = "_default.cdws";
        //    string sourcePath = Environment.CurrentDirectory;
        //    string targetPath = Environment.CurrentDirectory + @"\AA";
        //    // string targetPath = @"C:\Users\user\AppData\Roaming\Corel\CorelDRAW Graphics Suite 2019\Draw\Workspace";
        //    string sourceFile = Path.Combine(sourcePath, fileName);
        //    string destFile = Path.Combine(targetPath, fileName);

        //    Directory.CreateDirectory(targetPath);
        //    File.Copy(sourceFile, destFile, true);
        //}


    }
}
