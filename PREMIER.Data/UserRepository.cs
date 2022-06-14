using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PREMIER.core;
using PREMIER.dbhelper;

namespace PREMIER.data
{
    public class UserRepository
    {
        DBConnect db;

        //:TODO  create new user to use the system  in UserModule . (APPLET)
        public bool AddUser(UserModel userModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", userModel.UserName);
                parameters.Add("@LoginName", userModel.LoginName);
                parameters.Add("@Pass", userModel.Password);
                parameters.Add("@StoreAdd", userModel.StoreAdd);
                parameters.Add("@StoreEdit", userModel.StoreEdit);
                parameters.Add("@StoreDelete", userModel.StoreDelete);
                parameters.Add("@StoreTransferBalance", userModel.StoreTransferBalance);
                parameters.Add("@ProductAdd", userModel.ProductAdd);
                parameters.Add("@ProductEdit", userModel.ProductEdit);
                parameters.Add("@ProductDelete", userModel.ProductDelete);
                parameters.Add("@ProductOpen", userModel.ProductEdit);
                parameters.Add("@ProductOpenCancel", userModel.ProductOpenCancel);
                parameters.Add("@ProductResetStock", userModel.ProductResetStock);
                parameters.Add("@SupplierAdd", userModel.SupplierAdd);
                parameters.Add("@SupplierEdit", userModel.SupplierEdit);
                parameters.Add("@SupplierDelete", userModel.SupplierDelete);
                parameters.Add("@SupplierAddMoney", userModel.SupplierAddMoney);
                parameters.Add("@SupplierDeleteMoney", userModel.SupplierDeleteMoney);
                parameters.Add("@BuyInvoice", userModel.BuyInvoice);
                parameters.Add("@BuyInvoiceCancel", userModel.BuyInvoiceCancel);
                parameters.Add("@BuyDiscard", userModel.BuyDiscard);
                parameters.Add("@EmpAdd", userModel.EmpAdd);
                parameters.Add("@EmpEdit", userModel.EmpEdit);
                parameters.Add("@EmpDelete", userModel.EmpDelete);
                parameters.Add("@EmpComm", userModel.EmpComm);
                parameters.Add("@EmpCancelComm", userModel.EmpCancelComm);
                parameters.Add("@EmpPunish", userModel.EmpPunish);
                parameters.Add("@EmpCancelPunish", userModel.EmpCancelPunish);
                parameters.Add("@EmpDebit", userModel.EmpDebit);
                parameters.Add("@EmpSalary", userModel.EmpSalary);
                parameters.Add("@CustomerAdd", userModel.CustomerAdd);
                parameters.Add("@CustomerEdit", userModel.CustomerEdit);
                parameters.Add("@CustomerDelete", userModel.CustomerDelete);
                parameters.Add("@CustomerAddMoney", userModel.CustomerAddMoney);
                parameters.Add("@CustomerCancelMoney", userModel.CustomerCancelMoney);
                parameters.Add("@SalesInvoice", userModel.SalesInvoice);
                parameters.Add("@SalesDiscount", userModel.SalesDiscount);
                parameters.Add("@SalesInvoiceCancel", userModel.SalesInvoiceCancel);
                parameters.Add("@SalesDiscard", userModel.SalesDiscard);
                parameters.Add("@SalesManSummaryReport", userModel.SalesManSummaryReport);
                parameters.Add("@SalesPointDepositWithdrow", userModel.SalesPointDepositWithdrow);
                parameters.Add("@SalesPointTransferMoney", userModel.SalesPointTransferMoney);
                parameters.Add("@SalesPointReport", userModel.SalesPointReport);
                parameters.Add("@ReportProductMove", userModel.ReportProductMove);
                parameters.Add("@ReportStoreStock", userModel.ReportStoreStock);
                parameters.Add("@ReportSupplierBuys", userModel.ReportSupplierBuys);
                parameters.Add("@ReportCustomerSales", userModel.ReportCustomerSales);
                parameters.Add("@ReportSalesManSales", userModel.ReportSalesManSales);
                parameters.Add("@UserAdd", userModel.UserAdd);
                parameters.Add("@UserEdit", userModel.UserEdit);
                parameters.Add("@UserDelete", userModel.UserDelete);
                parameters.Add("@SystemSettings", userModel.SystemSettings);
                parameters.Add("@AdditionalCost", userModel.AdditionalCost);
                parameters.Add("@ReportAddCost", userModel.ReportAddCost);
                parameters.Add("@ReportProfitLose", userModel.ReportProfitLose);
                parameters.Add("@ReportTotalMoneyInfo", userModel.ReportTotalMoneyInfo);
                parameters.Add("@AddBranch", userModel.AddBranch);
                parameters.Add("@EditBranch", userModel.EditBranch);
                parameters.Add("@DeleteBranch", userModel.DeleteBranch);
                parameters.Add("@AddSalesPoint", userModel.AddSalesPoint);
                parameters.Add("@EditSalesPoint", userModel.EditSalesPoint);
                parameters.Add("@DeleteSalesPoint", userModel.DeleteSalesPoint);
                parameters.Add("@AccessActivitiesRecord", userModel.AccessActivitiesRecord);
                parameters.Add("@AccessStoreNotifications", userModel.AccessStoreNotifications);
                parameters.Add("@AccessSalesPointNotifications", userModel.AccessSalesPointNotifications);


                db.ExecuteStoredProcedure("User_AddNewUser", parameters); // TODO: Call DBConnect Method and add user detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>" ;
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return false;
            }
        }
        public bool UpdateUserExisting(UserModel userModel)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userModel.UserId);
                parameters.Add("@Statuse", userModel.Existing);
                db.ExecuteStoredProcedure("User_UpdateUserExisting", parameters); // TODO: Call DBConnect Method and add user detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return false;
            }
        }

        //:TODO  get specific user for deleting or updting operations in UserModule . (APPLET)
        public IEnumerable GetUserById(int userId)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userId);
                return db.ExecuteStoredProcedure<UserModel>("User_SelectUserByID", parameters);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        public IEnumerable GetUserByName(string Name)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@LoginName", Name);
                return db.ExecuteStoredProcedure<UserModel>("User_SelectUserByLoginName", parameters);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        //:TODO  check if login name is existed when add new user in  the system  in UserModule . (APPLET)
        public IEnumerable GetLoginNameToValidate(string name)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@Name", name);
                return db.ExecuteStoredProcedure<UserModel>("User_SelectLoginNameToValidate", parameters);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        //:TODO  check if User Name is existed when add new user in  the system  in UserModule . (APPLET)
        public IEnumerable GetUserNameToValidate(string name)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@Name", name);
                return db.ExecuteStoredProcedure<UserModel>("User_SelectNameToValidate", parameters);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        //:TODO  get all users using the system and list them in UserModule . (APPLET)
        public IList<IEnumerable> GetAllUser() 
        {
            try
            {
                db = new DBConnect();
                IList<Type> userList = new List<Type>();
                userList.Add(typeof(UserModel));
                return db.ExecuteStoredProcedureMultiple("User_SelectAllUsers", userList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        //:TODO  update specific  user permissions for using the system  in UserModule . (APPLET)
        public bool EditUser(UserModel userModel) 
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userModel.UserId);
                parameters.Add("@StoreAdd", userModel.StoreAdd);
                parameters.Add("@StoreEdit", userModel.StoreEdit);
                parameters.Add("@StoreDelete", userModel.StoreDelete);
                parameters.Add("@StoreTransferBalance", userModel.StoreTransferBalance);
                parameters.Add("@ProductAdd", userModel.ProductAdd);
                parameters.Add("@ProductEdit", userModel.ProductEdit);
                parameters.Add("@ProductDelete", userModel.ProductDelete);
                parameters.Add("@ProductOpen", userModel.ProductEdit);
                parameters.Add("@ProductOpenCancel", userModel.ProductOpenCancel);
                parameters.Add("@ProductResetStock", userModel.ProductResetStock);
                parameters.Add("@SupplierAdd", userModel.SupplierAdd);
                parameters.Add("@SupplierEdit", userModel.SupplierEdit);
                parameters.Add("@SupplierDelete", userModel.SupplierDelete);
                parameters.Add("@SupplierAddMoney", userModel.SupplierAddMoney);
                parameters.Add("@SupplierDeleteMoney", userModel.SupplierDeleteMoney);
                parameters.Add("@BuyInvoice", userModel.BuyInvoice);
                parameters.Add("@BuyInvoiceCancel", userModel.BuyInvoiceCancel);
                parameters.Add("@BuyDiscard", userModel.BuyDiscard);
                parameters.Add("@EmpAdd", userModel.EmpAdd);
                parameters.Add("@EmpEdit", userModel.EmpEdit);
                parameters.Add("@EmpDelete", userModel.EmpDelete);
                parameters.Add("@EmpComm", userModel.EmpComm);
                parameters.Add("@EmpCancelComm", userModel.EmpCancelComm);
                parameters.Add("@EmpPunish", userModel.EmpPunish);
                parameters.Add("@EmpCancelPunish", userModel.EmpCancelPunish);
                parameters.Add("@EmpDebit", userModel.EmpDebit);
                parameters.Add("@EmpSalary", userModel.EmpSalary);
                parameters.Add("@CustomerAdd", userModel.CustomerAdd);
                parameters.Add("@CustomerEdit", userModel.CustomerEdit);
                parameters.Add("@CustomerDelete", userModel.CustomerDelete);
                parameters.Add("@CustomerAddMoney", userModel.CustomerAddMoney);
                parameters.Add("@CustomerCancelMoney", userModel.CustomerCancelMoney);
                parameters.Add("@SalesInvoice", userModel.SalesInvoice);
                parameters.Add("@SalesDiscount", userModel.SalesDiscount);
                parameters.Add("@SalesInvoiceCancel", userModel.SalesInvoiceCancel);
                parameters.Add("@SalesDiscard", userModel.SalesDiscard);
                parameters.Add("@SalesManSummaryReport", userModel.SalesManSummaryReport);
                parameters.Add("@SalesPointDepositWithdrow", userModel.SalesPointDepositWithdrow);
                parameters.Add("@SalesPointTransferMoney", userModel.SalesPointTransferMoney);
                parameters.Add("@SalesPointReport", userModel.SalesPointReport);
                parameters.Add("@ReportProductMove", userModel.ReportProductMove);
                parameters.Add("@ReportStoreStock", userModel.ReportStoreStock);
                parameters.Add("@ReportSupplierBuys", userModel.ReportSupplierBuys);
                parameters.Add("@ReportCustomerSales", userModel.ReportCustomerSales);
                parameters.Add("@ReportSalesManSales", userModel.ReportSalesManSales);
                parameters.Add("@UserAdd", userModel.UserAdd);
                parameters.Add("@UserEdit", userModel.UserEdit);
                parameters.Add("@UserDelete", userModel.UserDelete);
                parameters.Add("@SystemSettings", userModel.SystemSettings);
                parameters.Add("@AdditionalCost", userModel.AdditionalCost);
                parameters.Add("@ReportAddCost", userModel.ReportAddCost);
                parameters.Add("@ReportProfitLose", userModel.ReportProfitLose);
                parameters.Add("@ReportTotalMoneyInfo", userModel.ReportTotalMoneyInfo);
                parameters.Add("@AddBranch", userModel.AddBranch);
                parameters.Add("@EditBranch", userModel.EditBranch);
                parameters.Add("@DeleteBranch", userModel.DeleteBranch);
                parameters.Add("@AddSalesPoint", userModel.AddSalesPoint);
                parameters.Add("@EditSalesPoint", userModel.EditSalesPoint);
                parameters.Add("@DeleteSalesPoint", userModel.DeleteSalesPoint);
                parameters.Add("@AccessActivitiesRecord", userModel.AccessActivitiesRecord);
                parameters.Add("@AccessStoreNotifications", userModel.AccessStoreNotifications);
                parameters.Add("@AccessSalesPointNotifications", userModel.AccessSalesPointNotifications);

                db.ExecuteStoredProcedure("User_EditUser", parameters); // TODO: Call DBConnect Method and add user detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return false;
            }
        }

        //:TODO update basic information of current loggedin  user in  the system  in UserModule . (APPLET)
        public bool UpdateUserBasics(UserModel userModel) 
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userModel.UserId);
                parameters.Add("@Name", userModel.UserName);
                parameters.Add("@LoginName", userModel.LoginName);
                parameters.Add("@Pass", userModel.Password);

                db.ExecuteStoredProcedure("User_EditUserBasics", parameters); // TODO: Call DBConnect Method and add user detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return false;
            }
        }

        //:TODO  delete specific  user from using the system  in UserModule . (APPLET)
        public bool DeleteUser(UserModel userModel) 
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();                
                parameters.Add("@UserID", userModel.UserId);
                db.ExecuteStoredProcedure("User_DeleteUser", parameters); // TODO: Call DBConnect Method and add user detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return false;
            }
        }
    }
}
