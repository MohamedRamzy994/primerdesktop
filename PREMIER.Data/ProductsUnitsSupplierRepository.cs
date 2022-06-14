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
    public class ProductsUnitsSupplierRepository
    {

        DBConnect db;

        public bool AddProductUnits(ProductsUnitsSupplierModel productsUnitsSupplierModel)
        {
            try
            {
                db = new DBConnect();
                OpeningBalanceModel openingBalanceModel = new OpeningBalanceModel();


                DynamicParameters paramters = new DynamicParameters();

                if (productsUnitsSupplierModel.UnitCat11 != 0)
                {
                    paramters.Add("@ID", productsUnitsSupplierModel.ProductID);
                    paramters.Add("@UnitCatID", productsUnitsSupplierModel.UnitCat11);
                    paramters.Add("@UnitID", productsUnitsSupplierModel.Unit11);
                    paramters.Add("@ChangeNum", 1);
                    db.ExecuteStoredProcedure("Product_AddProductWithUnit", paramters);



                }
                if (productsUnitsSupplierModel.UnitCat12 != 0)
                {

                    paramters.Add("@ID", productsUnitsSupplierModel.ProductID);
                    paramters.Add("@UnitCatID", productsUnitsSupplierModel.UnitCat12);
                    paramters.Add("@UnitID", productsUnitsSupplierModel.Unit12);
                    paramters.Add("@ChangeNum", productsUnitsSupplierModel.ChangeNum12);

                    db.ExecuteStoredProcedure("Product_AddProductWithUnit", paramters);


                }

                if (productsUnitsSupplierModel.UnitCat13 != 0)
                {

                    paramters.Add("@ID", productsUnitsSupplierModel.ProductID);
                    paramters.Add("@UnitCatID", productsUnitsSupplierModel.UnitCat13);
                    paramters.Add("@UnitID", productsUnitsSupplierModel.Unit13);
                    paramters.Add("@ChangeNum", productsUnitsSupplierModel.ChangeNum13);

                    db.ExecuteStoredProcedure("Product_AddProductWithUnit", paramters);
                }


                this.AddProductUnitsDefault(productsUnitsSupplierModel);

                openingBalanceModel.DateSubmit = DateTime.Now;
                openingBalanceModel.Num = productsUnitsSupplierModel.OpeningNum;
                openingBalanceModel.ProductID = productsUnitsSupplierModel.ProductID;
                openingBalanceModel.StoreID = productsUnitsSupplierModel.StoreId;
                
                if (productsUnitsSupplierModel.UnitCatId!= 0)
                {
                    switch (productsUnitsSupplierModel.UnitCatId)
                    {
                        case 11:
                            {
                                openingBalanceModel.UnitID = productsUnitsSupplierModel.Unit11;
                                openingBalanceModel.ChangeNum = 1;
                                break;
                            }
                        case 12: { openingBalanceModel.UnitID = productsUnitsSupplierModel.Unit12;
                                openingBalanceModel.ChangeNum = productsUnitsSupplierModel.ChangeNum12;

                                break; }
                        case 13:
                            {
                                openingBalanceModel.UnitID = productsUnitsSupplierModel.Unit13;
                                openingBalanceModel.ChangeNum = productsUnitsSupplierModel.ChangeNum13;

                                break;
                            }

                        default:
                            break;
                    }


                }

                openingBalanceModel.UserID = productsUnitsSupplierModel.UserId;
                

                this.AddOpeningBalance(openingBalanceModel);

                if (productsUnitsSupplierModel.SelectedProductSuppliers !=null)
                {
                    if (productsUnitsSupplierModel.SelectedProductSuppliers.Count > 0)
                    {

                        foreach (var item in productsUnitsSupplierModel.SelectedProductSuppliers)
                        {

                            this.AddProductSuppliers(productsUnitsSupplierModel.ProductID, item);


                        }



                    }
                }
                





                return true;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
                    
           
        }


        public bool EditProductUnits(ProductsUnitsSupplierModel productsUnitsSupplierModel)
        {
            try
            {
                db = new DBConnect();
                OpeningBalanceModel openingBalanceModel = new OpeningBalanceModel();


                DynamicParameters paramters = new DynamicParameters();

                if (productsUnitsSupplierModel.RelationID11 != 0)
                {
                    paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID11);
                    
                    paramters.Add("@UnitID", productsUnitsSupplierModel.Unit11);
                    paramters.Add("@ChangeNum", 0);
                    db.ExecuteStoredProcedure("Product_EditProductUnit", paramters);



                }
                if (productsUnitsSupplierModel.RelationID12 != 0)
                {

                    paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID12);
                    
                    paramters.Add("@UnitID", productsUnitsSupplierModel.Unit12);
                    paramters.Add("@ChangeNum", productsUnitsSupplierModel.ChangeNum12);

                    db.ExecuteStoredProcedure("Product_EditProductUnit", paramters);


                }

                if (productsUnitsSupplierModel.RelationID13 != 0)
                {

                    paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID13);
                    
                    paramters.Add("@UnitID", productsUnitsSupplierModel.Unit13);
                    paramters.Add("@ChangeNum", productsUnitsSupplierModel.ChangeNum13);

                    db.ExecuteStoredProcedure("Product_EditProductUnit", paramters);
                }


                this.EditProductUnitsDefault(productsUnitsSupplierModel);

                if (productsUnitsSupplierModel.SelectedProductSuppliers != null)
                {
                    if (productsUnitsSupplierModel.SelectedProductSuppliers.Count > 0)
                    {

                        this.DeleteProductSuppliers(productsUnitsSupplierModel.ProductID);


                        foreach (var item in productsUnitsSupplierModel.SelectedProductSuppliers)
                        {

                            this.AddProductSuppliers(productsUnitsSupplierModel.ProductID, item);


                        }



                    }
                }





                return true;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        public bool AddProductUnitsDefault(ProductsUnitsSupplierModel productsUnitsSupplierModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();

                if (productsUnitsSupplierModel.UnitBuy != 0)
                {
                  int RelationId = this.GetProductUnitsSelectedDefault(productsUnitsSupplierModel.ProductID, productsUnitsSupplierModel.UnitBuy);
                    paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                    paramters.Add("@RelationID", RelationId);
                    paramters.Add("@Buy_Or_Sale", true);
                    db.ExecuteStoredProcedure("Product_AddDefaultSelectedUnit", paramters);


                }
                if (productsUnitsSupplierModel.UnitSale != 0)
                {
                    int RelationId = this.GetProductUnitsSelectedDefault(productsUnitsSupplierModel.ProductID, productsUnitsSupplierModel.UnitSale);
                    paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                    paramters.Add("@RelationID",RelationId);
                    paramters.Add("@Buy_Or_Sale", false);
                    db.ExecuteStoredProcedure("Product_AddDefaultSelectedUnit", paramters);



                }
                                                                              

                return true;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public bool EditProductUnitsDefault(ProductsUnitsSupplierModel productsUnitsSupplierModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();

                if (productsUnitsSupplierModel.UnitBuy != 0)
                {
                    if (productsUnitsSupplierModel.UnitBuy == 11)
                    {
                        paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                        paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID11);
                        paramters.Add("@Buy_Or_Sale", true);
                        db.ExecuteStoredProcedure("Product_EditDefaultSelectedUnit", paramters);

                    }
                    else if (productsUnitsSupplierModel.UnitBuy == 12)
                    {

                        paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                        paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID12);
                        paramters.Add("@Buy_Or_Sale", true);
                        db.ExecuteStoredProcedure("Product_EditDefaultSelectedUnit", paramters);

                    }
                    else if (productsUnitsSupplierModel.UnitBuy == 13)
                    {

                        paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                        paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID13);
                        paramters.Add("@Buy_Or_Sale", true);
                        db.ExecuteStoredProcedure("Product_EditDefaultSelectedUnit", paramters);

                    }


                }
                if (productsUnitsSupplierModel.UnitSale != 0)
                {
                 
                   
                    if (productsUnitsSupplierModel.UnitSale == 11)
                    {
                        paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                        paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID11);
                        paramters.Add("@Buy_Or_Sale", false);
                        db.ExecuteStoredProcedure("Product_EditDefaultSelectedUnit", paramters);

                    }
                    else if (productsUnitsSupplierModel.UnitSale == 12)
                    {

                        paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                        paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID12);
                        paramters.Add("@Buy_Or_Sale", false);
                        db.ExecuteStoredProcedure("Product_EditDefaultSelectedUnit", paramters);

                    }
                    else if (productsUnitsSupplierModel.UnitSale == 13)
                    {

                        paramters.Add("@ProductID", productsUnitsSupplierModel.ProductID);
                        paramters.Add("@RelationID", productsUnitsSupplierModel.RelationID13);
                        paramters.Add("@Buy_Or_Sale", false);
                        db.ExecuteStoredProcedure("Product_EditDefaultSelectedUnit", paramters);

                    }




                }


                return true;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

      

        public bool AddOpeningBalance(OpeningBalanceModel openingBalanceModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@StoreID",openingBalanceModel.StoreID);
                paramters.Add("@UserID",openingBalanceModel.UserID);
                paramters.Add("@DateSubmit", openingBalanceModel.DateSubmit);
                int InvoiceId= db.ExecuteStoredProcedureReturnValueInt("ProductOpenning_AddMain", paramters);
                                       
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceID", InvoiceId);
                dynamicParameters.Add("@ProductID", openingBalanceModel.ProductID);
                dynamicParameters.Add("@Num", openingBalanceModel.Num);
                dynamicParameters.Add("@UnitID", openingBalanceModel.UnitID);

                dynamicParameters.Add("@ChangeNum", openingBalanceModel.ChangeNum);

                dynamicParameters.Add("@StoreID", openingBalanceModel.StoreID);

                db.ExecuteStoredProcedureReturnValueInt("ProductOpenning_AddInvoiceItem", dynamicParameters);
              
                return true;
                        
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        public bool AddProductSuppliers(int ProductID,int SupplierID)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@ID", ProductID);
                paramters.Add("@SuppID", SupplierID);
                db.ExecuteStoredProcedure("Product_AddProductSupplier", paramters);

               

                return true;

            }
            catch (Exception ex)
            {
                return false;

                throw new Exception(ex.Message);

                
            }


        }

        public int GetProductUnitsSelectedDefault(int ProductID,int UnitCatId)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@ProductID", ProductID);
                paramters.Add("@UnitCatID", UnitCatId);

              return db.ExecuteStoredProcedureReturnValueInt("Product_SelectDefaultSelectedUnitRelationID", paramters);


              


              


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }



        public bool DeleteProductSuppliers(int ProductID)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@ID", ProductID);
                
                db.ExecuteStoredProcedure("Product_DeleteProductSupplier", paramters);



                return true;

            }
            catch (Exception ex)
            {
                return false;

                throw new Exception(ex.Message);


            }


        }






    }
}
