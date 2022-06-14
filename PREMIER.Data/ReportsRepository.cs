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
    public class ReportsRepository
    {
        private DBConnect db;
        public IList<IEnumerable> ProductMoveMentReport()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListProductMoveMentReportModel));
                return db.ExecuteStoredProcedureMultiple("Product_ProductMoveMentReport", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> SupplierProductsInStoreReport( int StoreID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListSupplierProductsInStoreModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@StoreID", StoreID);
                return db.ExecuteStoredProcedureMultiple("Product_SelectAllSupplierProducts_InStore",dynamicParameters, banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IEnumerable ProductBuySelectTotalCommunicationReport(int SupplierID)
        {

            db = new DBConnect();
            ProductBuySelectTotalCommunicationReportModel productBuySelectTotalCommunicationReportModel = new ProductBuySelectTotalCommunicationReportModel();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SupplierID", SupplierID);
            return db.ExecuteStoredProcedure<ProductBuySelectTotalCommunicationReportModel>("ProductBuy_SelectTotalCommunicationReport",dynamicParameters);


        }

        public IEnumerable CustomerSelectTotalCommunicationReport(int CustomerID)
        {

            db = new DBConnect();
            CustomerSelectTotalCommunicationReportModel productBuySelectTotalCommunicationReportModel = new CustomerSelectTotalCommunicationReportModel();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerID", CustomerID);
            return db.ExecuteStoredProcedure<CustomerSelectTotalCommunicationReportModel>("Customer_SelectTotalCommunicationReport", dynamicParameters);


        }

        public IList<IEnumerable> CustomerMainInvoicesSalesReportDelegates()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListProductSaleSelectMainInvoicesToReport));
                return db.ExecuteStoredProcedureMultiple("Customer_Select_AllMainInvoicesINSearchToReport", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IEnumerable EmployeeSelectTotalCommunicationReport(int EmpID)
        {

            db = new DBConnect();
            CustomerSelectTotalCommunicationReportModel productBuySelectTotalCommunicationReportModel = new CustomerSelectTotalCommunicationReportModel();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EmpID", EmpID);
            return db.ExecuteStoredProcedure<CustomerSelectTotalCommunicationReportModel>("Emp_SelectTotalCommunicationReport", dynamicParameters);


        }

        public IList<IEnumerable> AdditionalCostEventToReport()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListSelectAdditionalCostEventToReport));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_SelectAdditionalCostEventToReport", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> WithdrawDepositEventToReport()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListSelectAdditionalCostEventToReport));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_SelectWithdrawDepositEventToReport", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GivedMoneyToReport()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListGivedMoneyToReport));
                return db.ExecuteStoredProcedureMultiple("SalesPoint_SelectGivedMoneyToReport", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> SupplierSelectProductSalesReport(int SupplierID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListSupplierSelectProductSalesReport));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SupplierID", SupplierID);
                return db.ExecuteStoredProcedureMultiple("Supplier_SelectProductSales_Report", dynamicParameters, banksList );
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IEnumerable CreateProfitLoseReport()
        {

            db = new DBConnect();
            DynamicParameters dynamicParameters = new DynamicParameters();
            return db.ExecuteStoredProcedure<SystemCreateProfitLoseReport>("System_CreateProfitLoseReport", dynamicParameters);


        }
        public IEnumerable CreateTotalInformationMoneyReport()
        {

            db = new DBConnect();
            DynamicParameters dynamicParameters = new DynamicParameters();
            return db.ExecuteStoredProcedure<SystemCreateTotalInformationMoneyReport>("System_CreateTotalInformationMoneyReport", dynamicParameters);


        }


    }
}
