using PREMIER.core;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PREMIER
{
    public partial class UserInfoForm : Form
    {

        private UserModel SelectedUser;
        public UserInfoForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBox1.Text = CurrentUserConfigurations._authenticatedUserInfo.UserName;
            textBox2.Text = CurrentUserConfigurations._authenticatedUserInfo.LoginName;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private async void button2_Click(object sender, EventArgs e)
        //{


        //    if (!string.IsNullOrEmpty(textBox1.Text)&& !string.IsNullOrEmpty(textBox2.Text) 
        //        && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
        //    {
        //        UserModel userModel = new UserModel();
        //        userModel.UserId = CurrentUserConfigurations._authenticatedUserInfo.UserId;
        //        userModel.UserName = textBox1.Text.Trim();
        //        userModel.LoginName = textBox2.Text.Trim();
        //        if (textBox3.Text == textBox4.Text)
        //        {
        //            userModel.Password = textBox4.Text;
        //        }
        //        else
        //        {
        //            errorProvider1.SetError(textBox4, "كلمة السر يجب ان تكون متطابقة ");
        //        }
        //        Result Deleted;
        //        Deleted = await UpdatExistingUser(userModel);
        //        if (Deleted.Status)
        //        {
        //            MessageBox.Show(this, Deleted.Message, "رسالة تأكيد نجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);


        //        }
        //        else
        //        {
        //            MessageBox.Show(this, Deleted.Message, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

        //        }



        //    }


        //    if (string.IsNullOrEmpty(textBox1.Text))
        //    {
        //        string errorMsg = "الحقل مطلوب";
        //        this.errorProvider1.SetError(textBox1, errorMsg);
        //    }
        //    if (string.IsNullOrEmpty(textBox2.Text))
        //    {
        //        string errorMsg = "الحقل مطلوب";
        //        this.errorProvider1.SetError(textBox2, errorMsg);

        //    }
        //    if (string.IsNullOrEmpty(textBox3.Text))
        //    {
        //        string errorMsg = "الحقل مطلوب";
        //        this.errorProvider1.SetError(textBox3, errorMsg);

        //    }
        //    if (string.IsNullOrEmpty(textBox4.Text))
        //    {
        //        string errorMsg = "الحقل مطلوب";
        //        this.errorProvider1.SetError(textBox4, errorMsg);

        //    }

            
         
        //}



        /// <summary>
        ///    this method will Delete  the selected User from the datagridview
        /// </summary>
        /// <param name="UserId">userModel is required</param>
        /// <returns>returns Task<Result></returns>
        //private async Task<Result> UpdatExistingUser(UserModel userModel)
        //{
        //    using (var client = new HttpClient())
        //    {

        //        client.BaseAddress = new Uri(CurrentUserConfigurations._baseWebApiUri);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage responseGetUserId;
        //        HttpResponseMessage responseUpdatedUser;
        //        Result resultUpdatedUser;
        //        Result resultGetUserId;


        //        responseGetUserId = await client.GetAsync($"api/UserApi/GetUserById?userId={userModel.UserId}");


        //        if (responseGetUserId.IsSuccessStatusCode)
        //        {

        //            resultGetUserId = await responseGetUserId.Content.ReadAsAsync<Result>();

        //            if (resultGetUserId.Status)
        //            {
        //                SelectedUser = resultGetUserId.UserList[0];

        //                responseUpdatedUser = await client.PostAsJsonAsync("api/UserApi/UpdateUserBasics/", userModel);
        //                if (responseUpdatedUser.IsSuccessStatusCode)
        //                {

        //                    resultUpdatedUser = await responseUpdatedUser.Content.ReadAsAsync<Result>();
        //                    if (resultUpdatedUser.Status)
        //                    {


        //                        return resultUpdatedUser;

        //                    }
        //                    else
        //                    {
        //                        return resultUpdatedUser;
        //                    }




        //                }


        //            }
        //            else
        //            {
                      

        //                return resultGetUserId;
        //            }

        //            return resultGetUserId;
        //        }
        //        else
        //        {
                   

        //            resultGetUserId = new Result();

        //            return resultGetUserId;
        //        }



        //    }

        //}
    }
}
