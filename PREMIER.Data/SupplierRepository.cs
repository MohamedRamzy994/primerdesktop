using PREMIER.core;
using PREMIER.dbhelper;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.data
{
   public class SupplierRepository
    {
        private DBConnect db;

        public IList<IEnumerable> GetAllSuppliers()
        {
            try
            {
                db = new DBConnect();
                IList<Type> suppliersList = new List<Type>();
                suppliersList.Add(typeof(SupplierModel));
                return db.ExecuteStoredProcedureMultiple("Supplier_SelectAllSuppliers", suppliersList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public bool AddSupplier(AddSupplierModel addSupplierModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", addSupplierModel.SupplierName);
                parameters.Add("@Mob1", addSupplierModel.Mobile1);
                parameters.Add("@Mob2", addSupplierModel.Mobile2);
                parameters.Add("@Mob2", addSupplierModel.Mobile2);
                parameters.Add("@Stop", addSupplierModel.Stopped);


                db.ExecuteStoredProcedure("Supplier_AddSupplier", parameters); // TODO: Call DBConnect Method and add Store detail.
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

        public bool EditSupplier(AddSupplierModel addSupplierModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SupplierID", addSupplierModel.SupplierID);
                parameters.Add("@Name", addSupplierModel.SupplierName);
                parameters.Add("@Mob1", addSupplierModel.Mobile1);
                parameters.Add("@Mob2", addSupplierModel.Mobile2);
                parameters.Add("@Mob2", addSupplierModel.Mobile2);
                parameters.Add("@Stop", addSupplierModel.Stopped);


                db.ExecuteStoredProcedure("Supplier_EditSupplierBasics", parameters); // TODO: Call DBConnect Method and add Store detail.
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




        public bool SupplierNameToValidate(string SupplierName)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", SupplierName);
          
              var result =  db.ExecuteStoredProcedure<AddSupplierModel>("Supplier_Select_SupplierNameToValidate", parameters); // TODO: Call DBConnect Method and add Store detail.

                if (result.Cast<AddSupplierModel>().Count() > 0)
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

        public bool DeleteSupplier(SupplierModel supplierModel)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@ID", supplierModel.SupplierID);

                db.ExecuteStoredProcedure("Supplier_DeleteSupplier", parameters); // TODO: Call DBConnect Method and add user detail.
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



        public bool AddRebateAction(AddRebateActionModel addRebateActionModel)
        {
            try
            {                                
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SupplierID",addRebateActionModel.SupplierID );
                parameters.Add("@MoneyValue", addRebateActionModel.MoneyValue);
                parameters.Add("@ReasonID", addRebateActionModel.ReasonID);
                parameters.Add("@DateSubmit",addRebateActionModel.DateSubmit);
                parameters.Add("@UserID", addRebateActionModel.UserID);
                parameters.Add("@SalesPointID", addRebateActionModel.SalesPointID);
                parameters.Add("@Details", addRebateActionModel.Details);

                db.ExecuteStoredProcedure("Supplier_AddTanzelAction", parameters); // TODO: Call DBConnect Method and add Store detail.
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


        public bool AddCancelMoneyAction(AddSupplierCancelMoneyAction addSupplierCancelMoneyAction)
        {
            try
            {

                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SupplierID", addSupplierCancelMoneyAction.SupplierID);
                parameters.Add("@MoneyValue", addSupplierCancelMoneyAction.MoneyValue);
                parameters.Add("@ReasonID", addSupplierCancelMoneyAction.ReasonID);
                parameters.Add("@DateSubmit", addSupplierCancelMoneyAction.DateSubmit);
                parameters.Add("@UserID", addSupplierCancelMoneyAction.UserID);
                parameters.Add("@SalesPointID", addSupplierCancelMoneyAction.SalesPointID);
                parameters.Add("@PayID", addSupplierCancelMoneyAction.PayID);

                db.ExecuteStoredProcedure("Supplier_CancelMoneyAction", parameters); // TODO: Call DBConnect Method and add Store detail.
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

        public bool AddPostBalanceAction(AddPostBalanceModel addPostBalanceModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SupplierID", addPostBalanceModel.SupplierID);
                parameters.Add("@MoneyValue", addPostBalanceModel.MoneyValue);
                parameters.Add("@ReasonID", addPostBalanceModel.ReasonID);
                parameters.Add("@DateSubmit", addPostBalanceModel.DateSubmit);
                parameters.Add("@UserID", addPostBalanceModel.UserID);
                parameters.Add("@SalesPointID", 1);
                parameters.Add("@Details", addPostBalanceModel.Details);

                db.ExecuteStoredProcedure("Supplier_AddPostBalance", parameters); // TODO: Call DBConnect Method and add Store detail.
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



        public bool AddCheckRebateAction(AddCheckRebateActionModel addCheckRebateActionModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SupplierID", addCheckRebateActionModel.SupplierID);
                parameters.Add("@MoneyValue", addCheckRebateActionModel.MoneyValue);
                parameters.Add("@ReasonID", addCheckRebateActionModel.ReasonID);
                parameters.Add("@DateSubmit", addCheckRebateActionModel.DateSubmit);
                parameters.Add("@UserID", addCheckRebateActionModel.UserID);
                parameters.Add("@SalesPointID", 1);
                parameters.Add("@Details", addCheckRebateActionModel.Details);
                parameters.Add("@BankID", addCheckRebateActionModel.BankID);

                parameters.Add("@ChequeNum", addCheckRebateActionModel.ChequeNum);

                parameters.Add("@DueDate", addCheckRebateActionModel.DueDate);


                db.ExecuteStoredProcedure("Supplier_AddChequeTanzelAction", parameters); // TODO: Call DBConnect Method and add Store detail.
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

                                
        public IList<IEnumerable> GetAllSupplierMoneyDetails(int SupplierID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneydetailsList = new List<Type>();
                moneydetailsList.Add(typeof(ListSupplierMoneyDetailsModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", SupplierID);
                return db.ExecuteStoredProcedureMultiple("Supplier_SelectAllMoneyDetails", dynamicParameters,moneydetailsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetSupplierTotalMoneyCommunications(int SupplierID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> totalCommunicationsList = new List<Type>();
                totalCommunicationsList.Add(typeof(SupplierTotalCommunicationSummaryModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", SupplierID);
                return db.ExecuteStoredProcedureMultiple("Supplier_SelectTotalCommunicationSummary", dynamicParameters, totalCommunicationsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetSupplierMonyActionDetails(int PayID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneyDatailsList = new List<Type>();
                moneyDatailsList.Add(typeof(SupplierMoneyActionDetails));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@PayID", PayID);
                return db.ExecuteStoredProcedureMultiple("Supplier_SelectMoneyDetails", dynamicParameters, moneyDatailsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllSupplierMoneyDetailsAdvancePayments(int SupplierID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneydetailsList = new List<Type>();
                moneydetailsList.Add(typeof(ListSupplierMoneyDetailsModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", SupplierID);
                return db.ExecuteStoredProcedureMultiple("Supplier_SelectAdvancePayments", dynamicParameters, moneydetailsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllSupplierCanceledMoneyAction(int SupplierID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> moneydetailsList = new List<Type>();
                moneydetailsList.Add(typeof(ListSupplierCanceldMoneyDetailsModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", SupplierID);
                return db.ExecuteStoredProcedureMultiple("Supplier_SelectAll_CanceledMoneyDetails", dynamicParameters, moneydetailsList);
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
