using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PREMIER.core;
using PREMIER.dbhelper;
using Dapper;

namespace PREMIER.data
{
    public class TransferKindsRepository
    {

        DBConnect db;


        public IList<IEnumerable> GetProductUnites(int ProductID)
        {

            try
            {
                db = new DBConnect();
                IList<Type> unitsList = new List<Type>();
                unitsList.Add(typeof(ProductUnitsModel));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Code", ProductID);
                return db.ExecuteStoredProcedureMultiple("Product_SelectProductUnits", dynamicParameters,unitsList);
                
               


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


           
        }


        public bool AddTransferStock(TransferKindsModel transferKindsModel)
        {

            try
            {
                db = new DBConnect();

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@StoreIDFrom", transferKindsModel.StoreIDFrom);
                dynamicParameters.Add("@StoreIDTo", transferKindsModel.StoreIDTo);
                dynamicParameters.Add("@UserID", transferKindsModel.UserID);
                dynamicParameters.Add("@DateSubmit", DateTime.Now);
                int InvoiceID = db.ExecuteStoredProcedureReturnValueInt("Stores_AddTransferStockMain", dynamicParameters);

                if (InvoiceID != 0)
                {

                    foreach (var item in transferKindsModel.InvoiceItems)
                    {

                        DynamicParameters dynamicParametersStockItem = new DynamicParameters();

                        dynamicParametersStockItem.Add("@StoreIDFrom", transferKindsModel.StoreIDFrom);
                        dynamicParametersStockItem.Add("@StoreIDTo", transferKindsModel.StoreIDTo);
                        dynamicParametersStockItem.Add("@InvoiceID", InvoiceID);
                        dynamicParametersStockItem.Add("@ProductID", item.ProductID);
                        dynamicParametersStockItem.Add("@Num", item.Num);
                        dynamicParametersStockItem.Add("@UnitID", item.UnitID);
                        dynamicParametersStockItem.Add("@ChangeNum", item.ChangeNum);

                        db.ExecuteStoredProcedure("Stores_AddTransferStockItem", dynamicParametersStockItem);

                    }

                   


                }


                return true;
            }
            catch (Exception ex)
            {

                return false;
                throw new Exception(ex.Message);
            }

         

        }



        public IList<IEnumerable> GetAllTransferKindInvoices()
        {

            try
            {
                db = new DBConnect();
                IList<Type> invoiceList = new List<Type>();
                invoiceList.Add(typeof(ListTransferKindModel));
                return db.ExecuteStoredProcedureMultiple("Stores_Transfer_SelectAllInvoiceMainINSearch", invoiceList);
                                                                                                                 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }

        public IList<IEnumerable> GetTransferInvoiceItems(int InvoiceID)
        {
            try
            {

                db = new DBConnect();
                IList<Type> invoiceList = new List<Type>();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceID);
                invoiceList.Add(typeof(ListTransferInvoiceItemsModel));
                return db.ExecuteStoredProcedureMultiple("Stores_Transfer_SelectInvoiceItems", dynamicParameters , invoiceList);




            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }




        }





    }
}
