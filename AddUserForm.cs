using PREMIER.core;
using PREMIER.data;
using System;
using System.Collections;
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
    public partial class AddUserForm : Form
    {

        public AddUserForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private  void button2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {




                UserModel userModel = new UserModel()
                {

                    UserName = textBox1.Text.Trim(),
                    LoginName = textBox2.Text.Trim(),
                    Password = textBox3.Text.Trim(),
                    UserAdd = checkBox1.Checked,
                    UserEdit = checkBox2.Checked,
                    UserDelete = checkBox3.Checked,
                    StoreAdd = checkBox6.Checked,
                    StoreEdit = checkBox5.Checked,
                    StoreDelete = checkBox4.Checked,
                    ProductAdd = checkBox9.Checked,
                    ProductEdit = checkBox8.Checked,
                    ProductDelete = checkBox7.Checked,
                    ProductOpen = checkBox12.Checked,
                    ProductOpenCancel = checkBox11.Checked,
                    ProductResetStock = checkBox10.Checked,
                    StoreTransferBalance = checkBox13.Checked,
                    SupplierAdd = checkBox23.Checked,
                    SupplierEdit = checkBox22.Checked,
                    SupplierDelete = checkBox21.Checked,
                    SupplierAddMoney = checkBox20.Checked,
                    SupplierDeleteMoney = checkBox19.Checked,
                    BuyInvoice = checkBox16.Checked,
                    BuyInvoiceCancel = checkBox15.Checked,
                    BuyDiscard = checkBox14.Checked,
                    EmpAdd = checkBox39.Checked,
                    EmpEdit = checkBox38.Checked,
                    EmpDelete = checkBox37.Checked,
                    EmpComm = checkBox36.Checked,
                    EmpCancelComm = checkBox35.Checked,
                    EmpPunish = checkBox34.Checked,
                    EmpCancelPunish = checkBox33.Checked,
                    EmpDebit = checkBox32.Checked,
                    EmpSalary = checkBox31.Checked,
                    CustomerAdd = checkBox29.Checked,
                    CustomerEdit = checkBox28.Checked,
                    CustomerDelete = checkBox27.Checked,
                    CustomerAddMoney = checkBox26.Checked,
                    CustomerCancelMoney = checkBox25.Checked,
                    SalesInvoice = checkBox24.Checked,
                    SalesDiscount = checkBox17.Checked,
                    SalesInvoiceCancel = checkBox18.Checked,
                    SalesDiscard = checkBox30.Checked,
                    SalesManSummaryReport = checkBox44.Checked,
                    SalesPointDepositWithdrow = checkBox42.Checked,
                    SalesPointTransferMoney = checkBox41.Checked,
                    SalesPointReport = checkBox43.Checked,
                    AdditionalCost = checkBox40.Checked,
                    ReportProductMove = checkBox53.Checked,
                    ReportStoreStock = checkBox52.Checked,
                    ReportSupplierBuys = checkBox51.Checked,
                    ReportCustomerSales = checkBox50.Checked,
                    ReportSalesManSales = checkBox49.Checked,
                    ReportAddCost = checkBox54.Checked,
                    ReportProfitLose = checkBox48.Checked,
                    ReportTotalMoneyInfo = checkBox47.Checked,
                    SystemSettings = checkBox60.Checked,
                    AddSalesPoint = checkBox55.Checked,
                    EditSalesPoint = checkBox46.Checked,
                    DeleteSalesPoint = checkBox45.Checked,
                    AddBranch = checkBox59.Checked,
                    EditBranch = checkBox58.Checked,
                    DeleteBranch = checkBox57.Checked,
                    AccessActivitiesRecord = checkBox62.Checked,
                    AccessStoreNotifications = checkBox61.Checked,
                    AccessSalesPointNotifications = checkBox56.Checked

                };

                if (!checkBox1.Checked &&
             !checkBox2.Checked &&
             !checkBox3.Checked &&
             !checkBox4.Checked &&
             !checkBox5.Checked &&
             !checkBox6.Checked &&
             !checkBox7.Checked &&
             !checkBox8.Checked &&
             !checkBox9.Checked &&
             !checkBox10.Checked &&
             !checkBox11.Checked &&
             !checkBox12.Checked &&
             !checkBox13.Checked &&
             !checkBox14.Checked &&
             !checkBox15.Checked &&
             !checkBox16.Checked &&
             !checkBox17.Checked &&
             !checkBox18.Checked &&
             !checkBox19.Checked &&
             !checkBox20.Checked &&
             !checkBox21.Checked &&
             !checkBox22.Checked &&
             !checkBox23.Checked &&
             !checkBox24.Checked &&
             !checkBox25.Checked &&
             !checkBox26.Checked &&
             !checkBox27.Checked &&
             !checkBox28.Checked &&
             !checkBox29.Checked &&
             !checkBox30.Checked &&
             !checkBox31.Checked &&
             !checkBox32.Checked &&
             !checkBox33.Checked &&
             !checkBox34.Checked &&
             !checkBox35.Checked &&
             !checkBox36.Checked &&
             !checkBox37.Checked &&
             !checkBox38.Checked &&
             !checkBox39.Checked &&
             !checkBox40.Checked &&
             !checkBox41.Checked &&
             !checkBox42.Checked &&
             !checkBox43.Checked &&
             !checkBox44.Checked &&
             !checkBox45.Checked &&
             !checkBox46.Checked &&
             !checkBox47.Checked &&
             !checkBox48.Checked &&
             !checkBox49.Checked &&
             !checkBox50.Checked &&
             !checkBox51.Checked &&
             !checkBox52.Checked &&
             !checkBox53.Checked &&
             !checkBox54.Checked &&
             !checkBox55.Checked &&
             !checkBox56.Checked &&
             !checkBox57.Checked &&
             !checkBox58.Checked &&
             !checkBox59.Checked &&
             !checkBox60.Checked &&
             !checkBox61.Checked &&
             !checkBox62.Checked




             )
                {
                    string errMsg = "من فضلك يجب اختيار صلاحيات للمستخدم ";
                    MessageBox.Show(this, errMsg, "رسالة تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
                else
                {

                    AddUserResult result =  AddUser(userModel);


                    if (result.Status)
                    {

                        if (MessageBox.Show(this, result.Message, "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.OK)
                        {
                            this.MdiParent.ActiveMdiChild.Hide();
                            UsersForm usersForm = new UsersForm();
                            usersForm.MdiParent = this.MdiParent;
                            usersForm.Dock = DockStyle.Fill;
                            usersForm.Show();
                        }

                    }
                    else
                    {
                        MessageBox.Show(this, result.Message, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }

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
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    string errMsg = "الحقل مطلوب";
                    errorProvider1.SetError(textBox3, errMsg);
                }





            }



        }



        /// <summary>
        ///    this method will add new user to the system
        /// </summary>
        /// <param name="">no parameters required</param>
        /// <returns>returns Task<Result></returns>
        private AddUserResult AddUser(UserModel userModel)
        {
            UserRepository userRepository = new UserRepository();
            AddUserResult addUserResult = new AddUserResult();
            if (userRepository.GetLoginNameToValidate(userModel.LoginName).Cast<UserModel>().Count() > 0)
            {
                addUserResult.Status = false;

                addUserResult.Message = "اسم الدخول الذى ادخلته موجود حاليا موجود بالفعل  من فضلك قم باختيار  اسم دخول أخر ";


            }

            else if (userRepository.GetUserNameToValidate(userModel.UserName).Cast<UserModel>().Count() > 0)
            {
                addUserResult.Status = false;

                addUserResult.Message = "اسم المستخدم الذى ادخلته موجود حاليا  من فضلك قم باختيار  اسم مستخدم أخر ";
            }
            else
            {


                if (userRepository.AddUser(userModel))
                {
                    addUserResult.Status = true;
                    addUserResult.Message = " تم تسجيل المستخدم بنجاح هذا المستخدم يمكنه استخدام البرنامج  فى اطار الصلاحيات المتاحة";
                }
                else
                {
                    addUserResult.Status = false;
                    addUserResult.Message = "شئ ما خاطئ يرجى المحاولة مرة اخرى ";
                }

            }

            return addUserResult;


        }






    }
   public  class AddUserResult
    {
        public bool Status { get; set; }

        public string Message { get; set; }
    }
}
