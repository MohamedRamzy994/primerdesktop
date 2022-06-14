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
    public class ProductResestStockRepository
    {


        DBConnect db;



        public IList<IEnumerable> GetAllProductResetStockReasons()
        {

            try
            {
                db = new DBConnect();
                IList<Type> reasonsList = new List<Type>();
                reasonsList.Add(typeof(PREMIER.core.ProductResetStockReasonModel));
                return db.ExecuteStoredProcedureMultiple("ProductResetStockReason_SelectAllReasons", reasonsList);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }

        public bool ProductResetStockAddMain(ProductResetStockAddMainModel productResetStockAddMainModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@StoreID", productResetStockAddMainModel.StoreID);
                paramters.Add("@UserID", productResetStockAddMainModel.UserID);
                paramters.Add("@DateSubmit", DateTime.Now);
                int InvoiceId = db.ExecuteStoredProcedureReturnValueInt("ProductResetStock_AddMain", paramters);

                foreach (var item in productResetStockAddMainModel.InvoiceItems)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@InvoiceID", InvoiceId);
                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@Num", item.Num);
                    dynamicParameters.Add("@UnitID", item.UnitID);

                    dynamicParameters.Add("@ChangeNum", item.ChangeNum);

                    dynamicParameters.Add("@StoreID", productResetStockAddMainModel.StoreID);
                    dynamicParameters.Add("@ReasonID", item.ReasonID);


                    db.ExecuteStoredProcedureReturnValueInt("ProductResetStock_InvoiceAddItem", dynamicParameters);



                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public IList<IEnumerable> GetAllResetStockInvoices()
        {

            try
            {
                db = new DBConnect();
                IList<Type> invoiceList = new List<Type>();
                invoiceList.Add(typeof(ListProductResetStockeModel));
                return db.ExecuteStoredProcedureMultiple("ProductResetStock_SelectMainAllInvoices", invoiceList);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }

        public IList<IEnumerable> GetProductResetStockInvoiceItems(int InvoiceID)
        {
            try
            {

                db = new DBConnect();
                IList<Type> invoiceList = new List<Type>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceID);
                invoiceList.Add(typeof(ListProductResetStockItemseModel));
                return db.ExecuteStoredProcedureMultiple("ProductResetStock_SelectInvoiceItems", dynamicParameters, invoiceList);




            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }




        }

        public bool AddResetStockReason(string Reason)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Reason", Reason);
                db.ExecuteStoredProcedure("ProductResetStock_AddResetStockReason", parameters); // TODO: Call DBConnect Method and add Store detail.
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

        public bool DeleteResetStockReason(int ReasonID)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@ReasonID", ReasonID);

                db.ExecuteStoredProcedure("ProductResetStock_DeleteResetStockReason", parameters); // TODO: Call DBConnect Method and add user detail.
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

        public bool EditResetStockReason(ListWithdrawDepositReasonModel listWithdrawDepositReasonModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();

                parameters.Add("@ReasonID", listWithdrawDepositReasonModel.ReasonID);
                parameters.Add("@Reason", listWithdrawDepositReasonModel.Reason);

                db.ExecuteStoredProcedure("ProductResetStock_UpdateResetStockReason", parameters); // TODO: Call DBConnect Method and add user detail.
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
