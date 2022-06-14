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
    public  class ProductOpenningBalanceRepository
    {
        DBConnect db;


        public bool AddOpeningBalance(ProductOpenningBalanceModel productOpenningBalanceModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@StoreID", productOpenningBalanceModel.StoreID);
                paramters.Add("@UserID", productOpenningBalanceModel.UserID);
                paramters.Add("@DateSubmit", DateTime.Now);
                int InvoiceId = db.ExecuteStoredProcedureReturnValueInt("ProductOpenning_AddMain", paramters);

                foreach (var item in productOpenningBalanceModel.InvoiceItems)
                {

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@InvoiceID", InvoiceId);
                    dynamicParameters.Add("@ProductID", item.ProductID);
                    dynamicParameters.Add("@Num", item.Num);
                    dynamicParameters.Add("@UnitID", item.UnitID);

                    dynamicParameters.Add("@ChangeNum", item.ChangeNum);

                    dynamicParameters.Add("@StoreID", productOpenningBalanceModel.StoreID);

                    db.ExecuteStoredProcedureReturnValueInt("ProductOpenning_AddInvoiceItem", dynamicParameters);



                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        public IList<IEnumerable> GetAllProductOpenningInvoices()
        {

            try
            {
                db = new DBConnect();
                IList<Type> invoiceList = new List<Type>();
                invoiceList.Add(typeof(ListProductOpenningBalanceModel));
                return db.ExecuteStoredProcedureMultiple("ProductOpenning_SelectMainInvoices", invoiceList);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }

        public IList<IEnumerable> GetProductOpenningInvoiceItems(int InvoiceID)
        {
            try
            {

                db = new DBConnect();
                IList<Type> invoiceList = new List<Type>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceID);
                invoiceList.Add(typeof(ListProductOpenningBalanceInvoiceItemsModel));
                return db.ExecuteStoredProcedureMultiple("ProductOpenning_SelectInvoiceItems", dynamicParameters, invoiceList);




            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }




        }


        public bool ProductOpenningCancleInvoice(ProductOpenningCancleInvoiceModel productOpenningCancleInvoiceModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@InvoiceID", productOpenningCancleInvoiceModel.InvoiceID);
                paramters.Add("@UserID", productOpenningCancleInvoiceModel.UserID);
                paramters.Add("@DateSubmit", DateTime.Now);
                int InvoiceId = db.ExecuteStoredProcedureReturnValueInt("ProductOpenning_CancelInvoice", paramters);
            
                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


    }
}
