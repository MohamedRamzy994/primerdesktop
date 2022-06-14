
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PREMIER.core;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PREMIER.data;
using System.Collections.Generic;

namespace PREMIER
{
    public partial class LoginForm : Form
    {
  
        
        public LoginForm()
        {
            InitializeComponent();


        }
            bool flag = false ;
        private void LoginForm_Load(object sender, EventArgs e)
        {




        }


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Splash splash = new Splash();
            splash.Close();
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("متأكد أنك تريد إغلاق البرنامج؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

    
    

        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text)&& !string.IsNullOrEmpty(textBox2.Text))
            {

                OAuthModel oAuthModel = new OAuthModel()
                {
                    LogInName = textBox1.Text.Trim(),
                    Password=textBox2.Text.Trim()

                };

                 bool result=  AuthenticateUser(oAuthModel);
                if (result==true)
                {
                    
                    string  message = "  تم تسجيل الدخول بنجاح يمكنك الان استخدام البرنامج بكل الصلاحيات المتوفرة لك يرجى الانتظار ";

                    notifyIcon1.BalloonTipText= message;
                    notifyIcon1.ShowBalloonTip(1000);
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();

                }
                else
                {
                  string  message = "اسم الدخول او كلمة المرور غير صحيحة من فضلك قم بادخال بياناتك الصحيحة والمحاولة مرة اخرى ";

                    MessageBox.Show(this,message, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);


                }


            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    string errMsg = "الحقل مطلوب";
                    errorProvider1.SetError(textBox1, errMsg);
                }
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    string errMsg = "الحقل مطلوب";
                    errorProvider1.SetError(textBox2, errMsg);
                }

            }

        }


        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("يمكنك زيارة موقعنا الإلكترونى للرد على كل استفساراتك شكرا !");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {



            Form mainFormOpens = Application.OpenForms["MainForm"];


            if (mainFormOpens != null)
            {


                mainFormOpens.Show();
                mainFormOpens.BringToFront();


            }
            else
            {
                Application.Restart();
            }












        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000);
        }


        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

            Form mainFormOpens = Application.OpenForms["MainForm"];


            if (mainFormOpens != null)
            {


                mainFormOpens.Show();
                mainFormOpens.BringToFront();


            }
            else
            {
                Application.Restart();
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "هل تريد غلق البرنامج ؟", "رسالة تحذيرية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {


                this.Close();
            }
            {

            }
        }
       

        /// <summary>
        ///    this method will Authnicate UserInformation connect to the Api service and redirect the user to the main form
        /// </summary>
        /// <param name="oAuthModel">this model which contains the User Information</param>
        /// <returns>returns task</returns>
        private bool AuthenticateUser(OAuthModel oAuthModel)
        {
          
            OAuthRepository oAuthRepository = new OAuthRepository();
            bool Result = oAuthRepository.Login(oAuthModel);
           
            if (Result == true)
            {


                IEnumerable UserInfo = oAuthRepository.GetAuthenticatedUserInfo(oAuthModel);

                if (UserInfo.Cast<UserModel>().ToList().Count > 0)
                {

                    UserModel currentUser = UserInfo.Cast<UserModel>().Take(1).SingleOrDefault();

                    CurrentUserConfigurations._authenticatedUserInfo = currentUser;


                    


                   

                    
                }

            }
         
           
            return Result;

        }

        

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.flag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag== true)
            {

                this.Location = Cursor.Position;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.flag = true;
        }
    }
}
