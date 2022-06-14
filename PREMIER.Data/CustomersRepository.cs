using Dapper;
using PREMIER.core;
using PREMIER.dbhelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.data
{
    public class CustomersRepository
    {
        DBConnect db;
        public bool AddCustomer(AddCustomerModel addCustomerModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", addCustomerModel.Name);
                parameters.Add("@Mob1", addCustomerModel.Mob1);
                parameters.Add("@Mob2", addCustomerModel.Mob2);
                parameters.Add("@CatID",addCustomerModel.CatID);


                db.ExecuteStoredProcedure("Customer_AddCustomr", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);

                return false;

            }
        }


        public bool CustomerNameToValidate(string CustomerName)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", CustomerName);

                var result = db.ExecuteStoredProcedure<AddCustomerModel>("Customer_Select_CustomerNameToValidate", parameters); // TODO: Call DBConnect Method and add Store detail.

                if (result.Cast<AddCustomerModel>().Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return false;
            }
        }

        public IList<IEnumerable> GetAllCustomers()
        {
            try
            {
                db = new DBConnect();
                IList<Type> customersList = new List<Type>();
                customersList.Add(typeof(ListCustomersModel));
                return db.ExecuteStoredProcedureMultiple("Customer_SelectAll_CustomersInSearch", customersList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public bool DeleteCustomer(ListCustomersModel listCustomersModel)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@ID", listCustomersModel.CustomerID);

                db.ExecuteStoredProcedure("Customer_DeleteCustomer", parameters); // TODO: Call DBConnect Method and add user detail.
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
        public bool EditCustomer(EditCustomerModel editCustomerModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", editCustomerModel.CustomerID);
                parameters.Add("@Name", editCustomerModel.Name);
                parameters.Add("@Mob1", editCustomerModel.Mob1);
                parameters.Add("@Mob2", editCustomerModel.Mob2);
                parameters.Add("@CatID", editCustomerModel.CatID);


                db.ExecuteStoredProcedure("Customer_EditCustomerBasics", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool AddCustomerRebateAction(AddCustomerRebateActionModel addCustomerRebateActionModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", addCustomerRebateActionModel.CustomerID);
                parameters.Add("@UserID", addCustomerRebateActionModel.UserID);
                parameters.Add("@EmpID", addCustomerRebateActionModel.EmpID);
                parameters.Add("@SalesPointID", addCustomerRebateActionModel.SalesPointID);
                parameters.Add("@ReasonID", addCustomerRebateActionModel.ReasonID);
                parameters.Add("@MoneyValue", addCustomerRebateActionModel.MoneyValue);
                parameters.Add("@Details", addCustomerRebateActionModel.Details);
                parameters.Add("@DateSubmit", addCustomerRebateActionModel.DateSubmit);
                db.ExecuteStoredProcedure("Customer_AddTanzelAction", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool AddCustomerPostBalanceAction(AddCustomerPostBalanceModel addCustomerPostBalanceModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", addCustomerPostBalanceModel.CustomerID);
                parameters.Add("@UserID", addCustomerPostBalanceModel.UserID);
                parameters.Add("@EmpID", addCustomerPostBalanceModel.EmpID);
                parameters.Add("@SalesPointID", addCustomerPostBalanceModel.SalesPointID);
                parameters.Add("@ReasonID", addCustomerPostBalanceModel.ReasonID);
                parameters.Add("@MoneyValue", addCustomerPostBalanceModel.MoneyValue);
                parameters.Add("@Details", addCustomerPostBalanceModel.Details);
                parameters.Add("@DateSubmit", addCustomerPostBalanceModel.DateSubmit);
                db.ExecuteStoredProcedure("Customer_AddPostBalance", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool AddCustomerCheckRebateAction(AddCustomerCheckRebateActionModel addCustomerCheckRebateActionModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", addCustomerCheckRebateActionModel.CustomerID);
                parameters.Add("@EmpID", addCustomerCheckRebateActionModel.EmpID);
                parameters.Add("@MoneyValue", addCustomerCheckRebateActionModel.MoneyValue);
                parameters.Add("@ReasonID", addCustomerCheckRebateActionModel.ReasonID);
                parameters.Add("@DateSubmit", addCustomerCheckRebateActionModel.DateSubmit);
                parameters.Add("@UserID", addCustomerCheckRebateActionModel.UserID);
                parameters.Add("@SalesPointID", 1);
                parameters.Add("@Details", addCustomerCheckRebateActionModel.Details);
                parameters.Add("@BankID", addCustomerCheckRebateActionModel.BankID);

                parameters.Add("@ChequeNum", addCustomerCheckRebateActionModel.ChequeNum);

                parameters.Add("@DueDate", addCustomerCheckRebateActionModel.DueDate);


                db.ExecuteStoredProcedure("Customer_Add_ChequeTanzel_Action", parameters); // TODO: Call DBConnect Method and add Store detail.
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
        public IList<IEnumerable> GetAllCustomerMoneyDetails(int CustomerID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneydetailsList = new List<Type>();
                moneydetailsList.Add(typeof(ListCustomerMoneyDetailsModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", CustomerID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectMoneyDetailsINSearch", dynamicParameters, moneydetailsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        public IList<IEnumerable> GetCustomerTotalMoneyCommunications(int CustomerID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> totalCommunicationsList = new List<Type>();
                totalCommunicationsList.Add(typeof(CustomerTotalCommunicationSummaryModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", CustomerID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectTotalCommunicationSummary", dynamicParameters, totalCommunicationsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        public bool AddCustomerCancelMoneyAction(AddCustomerCancelMoneyAction addCustomerCancelMoneyAction)
        {
            try
            {

                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", addCustomerCancelMoneyAction.CustomerID);
                parameters.Add("@EmpID", addCustomerCancelMoneyAction.EmpID);
                parameters.Add("@MoneyValue", addCustomerCancelMoneyAction.MoneyValue);
                parameters.Add("@ReasonID", addCustomerCancelMoneyAction.ReasonID);
                parameters.Add("@DateSubmit", addCustomerCancelMoneyAction.DateSubmit);
                parameters.Add("@UserID", addCustomerCancelMoneyAction.UserID);
                parameters.Add("@SalesPointID", addCustomerCancelMoneyAction.SalesPointID);
                parameters.Add("@PayID", addCustomerCancelMoneyAction.PayID);

                db.ExecuteStoredProcedure("Customer_CancelMoneyAction", parameters); // TODO: Call DBConnect Method and add Store detail.
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
        public IList<IEnumerable> GetCustomerMonyActionDetails(int PayID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneyDatailsList = new List<Type>();
                moneyDatailsList.Add(typeof(CustomerMoneyActionDetails));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@PayID", PayID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectMoneyDetails", dynamicParameters, moneyDatailsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        public IList<IEnumerable> GetAllCustomerCanceledMoneyAction(int CustomerID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneydetailsList = new List<Type>();
                moneydetailsList.Add(typeof(ListCustomerCanceldMoneyDetailsModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", CustomerID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectAll_CanceledMoneyDetails", dynamicParameters, moneydetailsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllCustomerMoneyDetailsAdvancePayments(int CustomerID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneydetailsList = new List<Type>();
                moneydetailsList.Add(typeof(ListCustomerMoneyDetailsModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", CustomerID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectPaymentsMoneyDetailsINSearch", dynamicParameters, moneydetailsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


    }
}
