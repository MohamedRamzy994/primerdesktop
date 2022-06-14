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
    public class ProductSalesRepository
    {
        DBConnect db;
        public bool AddProductSale(ProductSaleMainTableModel productSaleMainTableModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                if(productSaleMainTableModel.InvTypeID == 1)
                {
                    paramters.Add("@StoreID", productSaleMainTableModel.StoreID);
                    paramters.Add("@CustomerID", productSaleMainTableModel.CustomerID);
                    paramters.Add("@EmpID", productSaleMainTableModel.EmpID);
                    paramters.Add("@UserID", productSaleMainTableModel.UserID);
                    paramters.Add("@DateSubmit", productSaleMainTableModel.DateSubmit);
                    paramters.Add("@Total", productSaleMainTableModel.Total);
                    paramters.Add("@Addtions", productSaleMainTableModel.Addtions);
                    paramters.Add("@TotalPayed", productSaleMainTableModel.Cash);
                    paramters.Add("@Cash", productSaleMainTableModel.Cash);
                    paramters.Add("@Net", productSaleMainTableModel.Net);
                    paramters.Add("@DiscPercent", 0);
                    paramters.Add("@DiscLE", productSaleMainTableModel.DiscLE);
                    paramters.Add("@Notes", productSaleMainTableModel.Notes);
                    paramters.Add("@InvTypeID", productSaleMainTableModel.InvTypeID);
                    paramters.Add("@SalesPointID", productSaleMainTableModel.SalesPointID);

                }
                else if (productSaleMainTableModel.InvTypeID == 2)
                {
                             
                    paramters.Add("@StoreID", productSaleMainTableModel.StoreID);
                    paramters.Add("@CustomerID", productSaleMainTableModel.CustomerID);
                    paramters.Add("@EmpID", productSaleMainTableModel.EmpID);
                    paramters.Add("@UserID", productSaleMainTableModel.UserID);
                    paramters.Add("@DateSubmit", productSaleMainTableModel.DateSubmit);
                    paramters.Add("@Total", productSaleMainTableModel.Total);
                    paramters.Add("@Addtions", productSaleMainTableModel.Addtions);
                    paramters.Add("@TotalPayed", 0);
                    paramters.Add("@Cash", 0);
                    paramters.Add("@Net", productSaleMainTableModel.Net);
                    paramters.Add("@DiscPercent", 0);
                    paramters.Add("@DiscLE", productSaleMainTableModel.DiscLE);
                    paramters.Add("@Notes", productSaleMainTableModel.Notes);
                    paramters.Add("@InvTypeID", productSaleMainTableModel.InvTypeID);
                    paramters.Add("@SalesPointID", 1);


                }
                int InvoiceId = db.ExecuteStoredProcedureReturnValueInt("Customer_AddMainInvoice", paramters);
                foreach (var item in productSaleMainTableModel.SelectedProducts)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@InvoiceID", InvoiceId);
                    dynamicParameters.Add("@StoreID", productSaleMainTableModel.StoreID);

                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@Num", item.Num);
                    dynamicParameters.Add("@UnitID", item.UnitID);

                    dynamicParameters.Add("@ChangeNum", item.ChangeNum);

                    dynamicParameters.Add("@Price", item.Price);
                    dynamicParameters.Add("@TotalDisc", item.TotalDisc);
                    dynamicParameters.Add("@NetPrice", item.NetPrice);
                    dynamicParameters.Add("@SequanceID", 1);



                    db.ExecuteStoredProcedureReturnValueInt("Customer_AddInvoiceItem", dynamicParameters);


                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        public IList<IEnumerable> GetAllProductSaleMainInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> invoicesList = new List<Type>();
                invoicesList.Add(typeof(ProductSaleSelectMainInvoices));
                return db.ExecuteStoredProcedureMultiple("Customer_Select_AllMainInvoicesINSearch", invoicesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetProductSaleInvoiceMainDetails(int InvoiceID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductSaleInvoiceMainDetails));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectMainInvoiceDetails", dynamicParameters, itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }



        public IList<IEnumerable> GetProductSaleInvoiceItems(int InvoiceID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductSaleInvoiceItems));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectInvoiceItems", dynamicParameters, itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public bool AddProductSaleDiscardMainItems(ProductSaleDiscardMainModel productSaleDiscardMainModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@InvoiceID", productSaleDiscardMainModel.InvoiceID);
                paramters.Add("@DiscardValue", productSaleDiscardMainModel.DiscardValue);
                paramters.Add("@UserID", productSaleDiscardMainModel.UserID);
                paramters.Add("@DateSubmit", DateTime.Now);
                paramters.Add("@DefaultSalesPointID", 1);
                paramters.Add("@ThisSalesPointID", productSaleDiscardMainModel.ThisSalesPointID);
                paramters.Add("@GetMoneyBack", productSaleDiscardMainModel.GetMoneyBack);


                int DiscardId = db.ExecuteStoredProcedureReturnValueInt("Customer_CreateDiscardMain", paramters);

                foreach (var item in productSaleDiscardMainModel.DiscardSaleMainItems)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@InvoiceID", productSaleDiscardMainModel.InvoiceID);
                    dynamicParameters.Add("@DiscardID ", DiscardId);

                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@DiscNum", item.DiscNum);
                    dynamicParameters.Add("@UnitID", item.UnitID);

                    dynamicParameters.Add("@DiscChangeNum", item.DiscChangeNum);

                    dynamicParameters.Add("@Price", item.Price);


                    dynamicParameters.Add("@StoreID", productSaleDiscardMainModel.StoreID);
                    dynamicParameters.Add("@DiscNum_In_Old", item.DiscNum_In_Old);

                    dynamicParameters.Add("@DiscNum_In_Max", item.DiscNum_In_Max);
                    dynamicParameters.Add("@SequanceID", item.SequanceID);




                    db.ExecuteStoredProcedureReturnValueInt("Customer_AddDiscardsItem", dynamicParameters);



                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public bool AddProductSaleDiscardMainNotSpecifiedItems(ProductSaleDiscardMainNotSpecifiedModel productSaleDiscardMainNotSpecifiedModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@CustomerID", productSaleDiscardMainNotSpecifiedModel.CustomerID);
                paramters.Add("@Total", productSaleDiscardMainNotSpecifiedModel.Total);
                paramters.Add("@UserID", productSaleDiscardMainNotSpecifiedModel.UserID);
                paramters.Add("@EmpID", productSaleDiscardMainNotSpecifiedModel.EmpID);
                paramters.Add("@DateSubmit", DateTime.Now);
                paramters.Add("@DefaultSalesPointID", 1);
                paramters.Add("@ThisSalesPointID", productSaleDiscardMainNotSpecifiedModel.ThisSalesPointID);
                paramters.Add("@GetMoneyBack", productSaleDiscardMainNotSpecifiedModel.GetMoneyBack);
                paramters.Add("@StoreID", productSaleDiscardMainNotSpecifiedModel.StoreID);

                int DiscardId = db.ExecuteStoredProcedureReturnValueInt("Customer_CreateDiscardNotSpcefiedMain", paramters);

                foreach (var item in productSaleDiscardMainNotSpecifiedModel.DiscardSaleMainItems)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DiscardID ", DiscardId);
                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@Num", item.Num);
                    dynamicParameters.Add("@UnitID", item.UnitID);
                    dynamicParameters.Add("@ChangeNum", item.ChangeNum);
                    dynamicParameters.Add("@Price", item.Price);
                    dynamicParameters.Add("@StoreID", productSaleDiscardMainNotSpecifiedModel.StoreID);
                    db.ExecuteStoredProcedureReturnValueInt("Customer_AddDiscardNotSpcefiedItem", dynamicParameters);



                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public IList<IEnumerable> GetAllProductSaleDiscardNotMainInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> invoicesList = new List<Type>();
                invoicesList.Add(typeof(ProductSaleDiscardSelectMainInvoices));
                return db.ExecuteStoredProcedureMultiple("Customer_Select_AllDiscardsNotSpcefiedMainINSearch", invoicesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        public IList<IEnumerable> GetProductSaleDiscardNotInvoiceItems(int DiscardID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductSaleDiscardNotSelectMainInvoicesItems));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DiscardID", DiscardID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectDiscardNotSpcefiedMainItems", dynamicParameters, itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllProductSaleDiscardtMainInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> invoicesList = new List<Type>();
                invoicesList.Add(typeof(ProductSaleDiscardSelectMainInvoices));
                return db.ExecuteStoredProcedureMultiple("Customer_Select_AllDiscardsMainINSearch", invoicesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

    

        public IList<IEnumerable> GetProductSaleDiscardInvoiceItems(int DiscardID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductSaleDiscardSelectMainInvoicesItems));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DiscardID", DiscardID);
                return db.ExecuteStoredProcedureMultiple("Customer_SelectDiscardMainItems", dynamicParameters, itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllProductSaleProfitMainInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> invoicesList = new List<Type>();
                invoicesList.Add(typeof(ProductSaleProfitSelectMainInvoices));
                return db.ExecuteStoredProcedureMultiple("Customer_Select_AllMainInvoicesProfit", invoicesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllProductDailySalesInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> invoicesList = new List<Type>();
                invoicesList.Add(typeof(ProductDailySalesInvoices));
                return db.ExecuteStoredProcedureMultiple("Customer_SelectDailySales", invoicesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetSaleManSalesInvoicesReport(int EmpID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductDailySalesInvoices));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", EmpID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectSalesMan_Report", dynamicParameters, itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public IList<IEnumerable> GetEmployeeTotalMoneyCommunications(int CustomerID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> totalCommunicationsList = new List<Type>();
                totalCommunicationsList.Add(typeof(CustomerTotalCommunicationSummaryModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", CustomerID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectTotalCommunicationSummary", dynamicParameters, totalCommunicationsList);
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
