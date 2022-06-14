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
    public class ProductBuyRepository
    {
        DBConnect db;

        public bool AddProductBuy(ProductBuyMainTableModel productBuyMainTableModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@StoreID", productBuyMainTableModel.StoreID);
                paramters.Add("@SupplierID", productBuyMainTableModel.SupplierID);
                paramters.Add("@InvoiceNum", Guid.NewGuid().ToString());
                paramters.Add("@UserID", productBuyMainTableModel.UserID);
                paramters.Add("@DateSubmit", DateTime.Now);
                paramters.Add("@Total", productBuyMainTableModel.Total);
                paramters.Add("@DefaultSalesPointID", 1);
                paramters.Add("@PayedMoney", productBuyMainTableModel.PayedMoney);
                paramters.Add("@SalesPointID", productBuyMainTableModel.SalesPointID);
                paramters.Add("@DiscountCash", productBuyMainTableModel.DiscountCash);
                int InvoiceId =  db.ExecuteStoredProcedureReturnValueInt("ProductBuy_AddMain", paramters);

                foreach (var item in productBuyMainTableModel.SelectedProducts)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@InvoiceID", InvoiceId);
                    dynamicParameters.Add("@StoreID", productBuyMainTableModel.StoreID);

                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@Num", item.Num);
                    dynamicParameters.Add("@UnitID", item.UnitID);

                    dynamicParameters.Add("@ChangeNum", item.ChangeNum);

                    dynamicParameters.Add("@Price", item.Price);
                    dynamicParameters.Add("@Update_B_Price", 0);


                    db.ExecuteStoredProcedureReturnValueInt("ProductBuy_AddInvoiceItem", dynamicParameters);



                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public bool AddProductDiscardMainItems(ProductBuyDiscardMainModel productBuyDiscardMainModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@InvoiceID", productBuyDiscardMainModel.InvoiceID);
                paramters.Add("@DiscardValue", productBuyDiscardMainModel.DiscardValue);
                paramters.Add("@UserID", productBuyDiscardMainModel.UserID);
                paramters.Add("@DateSubmit", DateTime.Now);
                paramters.Add("@DefaultSalesPointID", 2);
                int DiscardId = db.ExecuteStoredProcedureReturnValueInt("ProductBuy_CreateProductDiscardMain", paramters);

                foreach (var item in productBuyDiscardMainModel.DiscardMainItems)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@InvoiceID", productBuyDiscardMainModel.InvoiceID);
                    dynamicParameters.Add("@DiscardID ", DiscardId);

                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@DiscNum", item.DiscNum);
                    dynamicParameters.Add("@UnitID", item.UnitID);

                    dynamicParameters.Add("@DiscChangeNum", item.DiscChangeNum);

                    dynamicParameters.Add("@Price", item.Price);


                    dynamicParameters.Add("@StoreID", productBuyDiscardMainModel.StoreID);
                    dynamicParameters.Add("@DiscNum_In_Old", item.DiscNum_In_Old);

                    dynamicParameters.Add("@DiscNum_In_Max", item.DiscNum_In_Max);



                    db.ExecuteStoredProcedureReturnValueInt("ProductBuy_AddDiscardsItem", dynamicParameters);



                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        public bool AddProductDiscardMainNotSpecified(ProductBuyDiscardMainNotSpecifiedModel productBuyDiscardMainNotSpecifiedModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@SupplierID", productBuyDiscardMainNotSpecifiedModel.SupplierID);
                paramters.Add("@StoreID", productBuyDiscardMainNotSpecifiedModel.StoreID);
                paramters.Add("@UserID", productBuyDiscardMainNotSpecifiedModel.UserID);
                paramters.Add("@Total", productBuyDiscardMainNotSpecifiedModel.Total);
                paramters.Add("@DateSubmit", DateTime.Now);
                paramters.Add("@DefaultSalesPointID", 2);
                int DiscardId = db.ExecuteStoredProcedureReturnValueInt("ProductBuy_CreateDiscardNotSpcefiedMain", paramters);

                foreach (var item in productBuyDiscardMainNotSpecifiedModel.DiscardMainItems)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DiscardID ", DiscardId);
                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@Num", item.Num);
                    dynamicParameters.Add("@UnitID", item.UnitID);

                    dynamicParameters.Add("@ChangeNum", item.ChangeNum);

                    dynamicParameters.Add("@Price", item.Price);                                      
                    dynamicParameters.Add("@StoreID", productBuyDiscardMainNotSpecifiedModel.StoreID);

                    db.ExecuteStoredProcedureReturnValueInt("ProductBuy_AddDiscardNotSpcefiedItem", dynamicParameters);



                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }



        public IList<IEnumerable> GetAllProductBuyMainInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> suppliersList = new List<Type>();
                suppliersList.Add(typeof(ProductBuySelectMainInvoices));
                return db.ExecuteStoredProcedureMultiple("ProductBuy_SelectMainInvoicesINSearch", suppliersList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetProductBuyInvoiceItems(int InvoiceID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductBuyInvoiceItems));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceID);
                return db.ExecuteStoredProcedureMultiple("ProductBuy_SelectInvoiceItems", dynamicParameters ,itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public IList<IEnumerable> GetAllProductBuyDiscardMainInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> invoicesList = new List<Type>();
                invoicesList.Add(typeof(ProductBuyDiscardSelectMainInvoices));
                return db.ExecuteStoredProcedureMultiple("ProductBuy_Select_AllDiscardsMainINSearch", invoicesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public IList<IEnumerable> GetAllProductBuyDiscardNotMainInvoices()
        {
            try
            {
                db = new DBConnect();
                IList<Type> invoicesList = new List<Type>();
                invoicesList.Add(typeof(ProductBuyDiscardSelectMainInvoices));
                return db.ExecuteStoredProcedureMultiple("ProductBuy_Select_AllDiscardsNotMainINSearch", invoicesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        
        public IList<IEnumerable> GetProductBuyDiscardInvoiceItems(int DiscardID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductBuyDiscardSelectMainInvoicesItems));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DiscardID", DiscardID);
                return db.ExecuteStoredProcedureMultiple("ProductBuy_SelectDiscardMainItems", dynamicParameters, itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public IList<IEnumerable> GetProductBuyDiscardNotInvoiceItems(int DiscardID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductBuyDiscardSelectMainInvoicesItems));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DiscardID", DiscardID);
                return db.ExecuteStoredProcedureMultiple("ProductBuy_SelectDiscardNotMainItems", dynamicParameters, itemsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        
        public IList<IEnumerable> GetProductBuyAllDiscardInvoiceItems(int InvoiceID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> itemsList = new List<Type>();
                itemsList.Add(typeof(ProductBuyDiscardSelectMainInvoicesItems));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceID);
                return db.ExecuteStoredProcedureMultiple("ProductBuy_SelectDiscardsInvoiceAllItems", dynamicParameters, itemsList);
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
