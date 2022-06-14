using Dapper;
using PREMIER.core;
using PREMIER.dbhelper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PREMIER.data
{
    public  class SalesPointRepository
    {

        private DBConnect db;

        public IList<IEnumerable> GetAllActiveSalesPoints()
        {
            try
            {
                db = new DBConnect();
                IList<Type> salespointsList = new List<Type>();
                salespointsList.Add(typeof(ListSalesPointsModel));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_SelectAllActive", salespointsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllSalesPoints()
        {
            try
            {
                db = new DBConnect();
                IList<Type> salespointsList = new List<Type>();
                salespointsList.Add(typeof(ListSalesPointsModel));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_SelectAll", salespointsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public bool AddAdditionalCostEvent(AddAdditionalCostEventModel addAdditionalCostEventModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@MoneyValue", addAdditionalCostEventModel.MoneyValue);
                parameters.Add("@Details", addAdditionalCostEventModel.Details);
                parameters.Add("@UserID", addAdditionalCostEventModel.UserID);
                parameters.Add("@DateSubmit", addAdditionalCostEventModel.DateSubmit);
                parameters.Add("@SalesPointID", addAdditionalCostEventModel.SalesPointID);
                parameters.Add("@SelectedReasonID", addAdditionalCostEventModel.SelectedReasonID);
                db.ExecuteStoredProcedure("SalesPoint_AddAdditionalCostEvent", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);


            }
        }

        public bool AddWithdrawEvent(AddAdditionalCostEventModel addAdditionalCostEventModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@MoneyValue", addAdditionalCostEventModel.MoneyValue);
                parameters.Add("@Details", addAdditionalCostEventModel.Details);
                parameters.Add("@UserID", addAdditionalCostEventModel.UserID);
                parameters.Add("@DateSubmit", addAdditionalCostEventModel.DateSubmit);
                parameters.Add("@SalesPointID", addAdditionalCostEventModel.SalesPointID);
                parameters.Add("@SelectedReasonID", addAdditionalCostEventModel.SelectedReasonID);
                db.ExecuteStoredProcedure("SalesPoint_AddWithdrawEvent", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);
                                         

            }
        }

        public bool AddDepositEvent(AddAdditionalCostEventModel addAdditionalCostEventModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@MoneyValue", addAdditionalCostEventModel.MoneyValue);
                parameters.Add("@Details", addAdditionalCostEventModel.Details);
                parameters.Add("@UserID", addAdditionalCostEventModel.UserID);
                parameters.Add("@DateSubmit", addAdditionalCostEventModel.DateSubmit);
                parameters.Add("@SalesPointID", addAdditionalCostEventModel.SalesPointID);
                parameters.Add("@SelectedReasonID", addAdditionalCostEventModel.SelectedReasonID);
                db.ExecuteStoredProcedure("SalesPoint_AddDepositEvent", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);


            }
        }

        public IList<IEnumerable> GetAllWithdrawDepositReason()
        {
            try
            {
                db = new DBConnect();
                IList<Type> salespointsList = new List<Type>();
                salespointsList.Add(typeof(ListWithdrawDepositReasonModel));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_SelectAllWithdrawDepositReason", salespointsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public bool AddTransferMoneyEvent(AddTransferMoneyEventModel addTransferMoneyEventModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@MoneyValue", addTransferMoneyEventModel.MoneyValue);
                parameters.Add("@UserID", addTransferMoneyEventModel.UserID);
                parameters.Add("@DateSubmit", addTransferMoneyEventModel.DateSubmit);
                parameters.Add("@SalesPointIDFrom", addTransferMoneyEventModel.SalesPointIDFrom);
                parameters.Add("@SalesPointIDTo", addTransferMoneyEventModel.SalesPointIDTo);
                db.ExecuteStoredProcedure("SalesPoint_AddTransferMoneyEvent", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);


            }
        }

        public IList<IEnumerable> GetStartBalance(int SalesPointID , DateTime DateFrom , DateTime DateTo)
        {
            try
            {
                db = new DBConnect();
                IList<Type> salespointsList = new List<Type>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SalesPointID", SalesPointID);
                parameters.Add("@DateFrom", DateFrom);
                parameters.Add("@DateTo", DateTo);

                salespointsList.Add(typeof(ListGetStartBalanceModel));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_GetStartBalance", parameters , salespointsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public bool AddWithdrawDepositReason(string Reason)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Reason", Reason);
                db.ExecuteStoredProcedure("SalesPoint_AddWithdrawDepositReason", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);


            }
        }

        public bool DeleteWithdrawDepositReason(int ReasonID)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@ReasonID", ReasonID);

                db.ExecuteStoredProcedure("SalesPoint_DeleteWithdrawDepositReason", parameters); // TODO: Call DBConnect Method and add user detail.
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

        public bool EditWithdrawDepositReason(ListWithdrawDepositReasonModel listWithdrawDepositReasonModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();

                parameters.Add("@ReasonID", listWithdrawDepositReasonModel.ReasonID);
                parameters.Add("@Reason", listWithdrawDepositReasonModel.Reason);

                db.ExecuteStoredProcedure("SalesPoint_UpdateWithdrawDepositReason", parameters); // TODO: Call DBConnect Method and add user detail.
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
        public IList<IEnumerable> GetSalesPointBalance(int SalesPointID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> salespointsList = new List<Type>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", SalesPointID);
                salespointsList.Add(typeof(ListSalesPointsModel));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_SelectByID",dynamicParameters, salespointsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public bool AddSalesPoint(AddSalesPointsModel addSalesPointsModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SalesPoint", addSalesPointsModel.SalesPoint);
                parameters.Add("@SalesPointMACEthernet", addSalesPointsModel.SalesPointMACEthernet);
                parameters.Add("@SalesPointMACWireless", addSalesPointsModel.SalesPointMACWireless);

                db.ExecuteStoredProcedure("SalesPoint_AddSalesPoint", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);


            }
        }

        public bool DeletSalesPoint(int SalesPointID)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SalesPointID", SalesPointID);

                db.ExecuteStoredProcedure("SalesPoint_DeletSalesPoint", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);


            }
        }

        public bool EditSalesPoint(ListSalesPointsModel listSalesPointsModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@SalesPointID", listSalesPointsModel.SalesPointID);
                parameters.Add("@SalesPointMACEthernet", listSalesPointsModel.SalesPointMACEthernet);
                parameters.Add("@SalesPointMACWireless", listSalesPointsModel.SalesPointMACWireless);
                parameters.Add("@SalesPoint", listSalesPointsModel.SalesPoint);
                db.ExecuteStoredProcedure("SalesPoint_EditSalesPoint", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);


            }
        }




    }
}
