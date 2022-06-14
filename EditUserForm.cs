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
    public partial class EditUserForm : Form
    {
        public UserModel _userModel;
        private UserModel SelectedUser;

        public EditUserForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        protected  override void OnLoad(EventArgs e)
        {


            SelectedUser =  GetUserById(UsersForm.selectedRowIndex);



            this._userModel = SelectedUser;
            checkBox1.Checked = _userModel.UserAdd;
            checkBox2.Checked = _userModel.UserEdit;
            checkBox3.Checked = _userModel.UserDelete;
            checkBox6.Checked = _userModel.StoreAdd;
            checkBox5.Checked = _userModel.StoreEdit;
            checkBox4.Checked = _userModel.StoreDelete;
            checkBox9.Checked = _userModel.ProductAdd;
            checkBox8.Checked = _userModel.ProductEdit;
            checkBox7.Checked = _userModel.ProductDelete;
            checkBox12.Checked = _userModel.ProductOpen;
            checkBox11.Checked = _userModel.ProductOpenCancel;
            checkBox10.Checked = _userModel.ProductResetStock;
            checkBox13.Checked = _userModel.StoreTransferBalance;
            checkBox23.Checked = _userModel.SupplierAdd;
            checkBox22.Checked = _userModel.SupplierEdit;
            checkBox21.Checked = _userModel.SupplierDelete;
            checkBox20.Checked = _userModel.SupplierAddMoney;
            checkBox19.Checked = _userModel.SupplierDeleteMoney;
            checkBox16.Checked = _userModel.BuyInvoice;
            checkBox15.Checked = _userModel.BuyInvoiceCancel;
            checkBox14.Checked = _userModel.BuyDiscard;
            checkBox39.Checked = _userModel.EmpAdd;
            checkBox38.Checked = _userModel.EmpEdit;
            checkBox37.Checked = _userModel.EmpDelete;
            checkBox36.Checked = _userModel.EmpComm;
            checkBox35.Checked = _userModel.EmpCancelComm;
            checkBox34.Checked = _userModel.EmpPunish;
            checkBox33.Checked = _userModel.EmpCancelPunish;
            checkBox32.Checked = _userModel.EmpDebit;
            checkBox31.Checked = _userModel.EmpSalary;
            checkBox29.Checked = _userModel.CustomerAdd;
            checkBox28.Checked = _userModel.CustomerEdit;
            checkBox27.Checked = _userModel.CustomerDelete;
            checkBox26.Checked = _userModel.CustomerAddMoney;
            checkBox25.Checked = _userModel.CustomerCancelMoney;
            checkBox24.Checked = _userModel.SalesInvoice;
            checkBox17.Checked = _userModel.SalesDiscount;
            checkBox18.Checked = _userModel.SalesInvoiceCancel;
            checkBox30.Checked = _userModel.SalesDiscard;
            checkBox44.Checked = _userModel.SalesManSummaryReport;
            checkBox42.Checked = _userModel.SalesPointDepositWithdrow;
            checkBox41.Checked = _userModel.SalesPointTransferMoney;
            checkBox43.Checked = _userModel.SalesPointReport;
            checkBox40.Checked = _userModel.AdditionalCost;
            checkBox53.Checked = _userModel.ReportProductMove;
            checkBox52.Checked = _userModel.ReportStoreStock;
            checkBox51.Checked = _userModel.ReportSupplierBuys;
            checkBox50.Checked = _userModel.ReportCustomerSales;
            checkBox49.Checked = _userModel.ReportSalesManSales;
            checkBox54.Checked = _userModel.ReportAddCost;
            checkBox48.Checked = _userModel.ReportProfitLose;
            checkBox47.Checked = _userModel.ReportTotalMoneyInfo;
            checkBox60.Checked = _userModel.SystemSettings;
            checkBox55.Checked = _userModel.AddSalesPoint;
            checkBox46.Checked = _userModel.EditSalesPoint;
            checkBox45.Checked = _userModel.DeleteSalesPoint;
            checkBox59.Checked = _userModel.AddBranch;
            checkBox58.Checked = _userModel.EditBranch;
            checkBox57.Checked = _userModel.DeleteBranch;
            checkBox62.Checked = _userModel.AccessActivitiesRecord;
            checkBox61.Checked = _userModel.AccessStoreNotifications;
            checkBox56.Checked = _userModel.AccessSalesPointNotifications;




        }

        private  void button2_Click(object sender, EventArgs e)
        {

            UserModel userModel = new UserModel()
            {
                UserId = this._userModel.UserId,
                UserName = this._userModel.UserName,
                LoginName = this._userModel.LoginName,
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

                AddUserResult result =  EditUser(userModel);


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

            }



        }



        /// <summary>
        ///    this method will Delete  the selected User from the datagridview
        /// </summary>
        /// <param name="UserId">userModel is required</param>
        /// <returns>returns Task<Result></returns>
        private UserModel GetUserById(int UserId)
        {

            UserRepository userRepository = new UserRepository();
            UserModel userModel = new UserModel();
            IEnumerable Result = userRepository.GetUserById(UserId);
            if (Result != null)
            {
                if (Result.Cast<UserModel>().ToList().Count() > 0)
                {
                    
                    userModel = Result.Cast<UserModel>().ToList()[0];

                    return userModel;
               
                }
                else
                {
                  
                }
            }
        
            return userModel;

        }



        /// <summary>
        ///    this method will edit the user to the system
        /// </summary>
        /// <param name="userModel">userModel is required</param>
        /// <returns>returns Task<Result></returns>
        private  AddUserResult EditUser(UserModel userModel)
        {
            UserRepository userRepository = new UserRepository();
            AddUserResult result = new AddUserResult();
            if (userRepository.EditUser(userModel))
            {
                result.Status = true;
                result.Message = "تم تعديل صلاحيات هذا المستخدم  بنجاح  وسيتم تحديث البرنامج  بالصلاحيات المتاحة ";
            }
            else
            {
                result.Status = false;
                result.Message = "شئ ما خاطئ يرجى المحاولة مرة اخرى ";
            }
            return result;


        }



    }
   
}
