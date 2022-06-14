using PREMIER.dbhelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PREMIER.core;
using Dapper;
using System.Collections;
namespace PREMIER.data
{
   public class ProductRepository
    {

        private DBConnect db;

        public ProductReturn AddProductBaisc(ProductBasicModel productBasicModel)
        {
            try
            {

                db = new DBConnect();
                ProductReturn productReturn = new ProductReturn();
                ProductCodeModel productCodeModel = new ProductCodeModel();

                IEnumerable selectedProuct;

                var parameters = new DynamicParameters();
                parameters.Add("@Name", productBasicModel.ProductName);
                parameters.Add("@CatID", productBasicModel.CatID);
                parameters.Add("@MinLimit", productBasicModel.MinLimit);
                parameters.Add("@StopBuy", productBasicModel.StopBuy);
                parameters.Add("@StopBuy", productBasicModel.StopBuy);
                parameters.Add("@StopSale", productBasicModel.StopSale);
                parameters.Add("@Price", productBasicModel.Price);
                parameters.Add("@PrintBarcode", productBasicModel.PrintBarcode);
                parameters.Add("@Discount", productBasicModel.Discount);
                parameters.Add("@MinSalesPrice", productBasicModel.MinSalePrice);
                parameters.Add("@P_Price", productBasicModel.P_Price);
                productReturn.ProductID=  db.ExecuteStoredProcedureReturnValueInt("Product_AddNewProduct", parameters); // TODO: Call DBConnect Method and add Group detail.
                productCodeModel.ProductID = productReturn.ProductID;
                productCodeModel.ProductCode = productBasicModel.ProductCode;

                this.AddProductInternationalCode(productCodeModel);

                this.AddProductToAllStores(productReturn.ProductID);



                selectedProuct = this.GetProductByID(productReturn.ProductID);
               







                productReturn.SelectedProduct = selectedProuct.Cast<ProductBasicModel>().ToList()[0];
                productReturn.SelectedProduct.ProductCode = productCodeModel.ProductCode;








                productReturn.Status = true;



                return productReturn;
            }
            catch (Exception ex)
            {
                ProductReturn productReturn = new ProductReturn();
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");

                productReturn.Status = false;
                return productReturn;
            }
        }

        public bool AddProductInternationalCode(ProductCodeModel productCodeModel)
        {
            try
            {

                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@ID",productCodeModel.ProductID);
                parameters.Add("@Code", productCodeModel.ProductCode);


                db.ExecuteStoredProcedure("Product_AddProductInternationalCode", parameters); // TODO: Call DBConnect Method and add Group detail.
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


        public ProductReturn EditProductBaisc(ProductBasicModel productBasicModel)
        {
            try
            {

                db = new DBConnect();
                ProductReturn productReturn = new ProductReturn();
                ProductCodeModel productCodeModel = new ProductCodeModel();

                IEnumerable selectedProuct;

                var parameters = new DynamicParameters();
                parameters.Add("@Code", productBasicModel.ProductID);
                parameters.Add("@Name", productBasicModel.ProductName);
                parameters.Add("@CatID", productBasicModel.CatID);
                parameters.Add("@MinLimit", productBasicModel.MinLimit);
                parameters.Add("@StopBuy", productBasicModel.StopBuy);
                parameters.Add("@StopBuy", productBasicModel.StopBuy);
                parameters.Add("@StopSale", productBasicModel.StopSale);
                parameters.Add("@Price", productBasicModel.Price);
                parameters.Add("@PrintBarcode", productBasicModel.PrintBarcode);
                parameters.Add("@Discount", productBasicModel.Discount);
                parameters.Add("@MinSalesPrice", productBasicModel.MinSalePrice);
                parameters.Add("@P_Price", productBasicModel.P_Price);
                db.ExecuteStoredProcedureReturnValueInt("Product_EditProductDetails", parameters); // TODO: Call DBConnect Method and add Group detail.
                productCodeModel.ProductID = productBasicModel.ProductID;
                productCodeModel.ProductCode = productBasicModel.ProductCode;

                this.EditProductInternationalCode(productCodeModel);
                         
                productReturn.Status = true;



                return productReturn;
            }
            catch (Exception ex)
            {
                ProductReturn productReturn = new ProductReturn();
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");

                productReturn.Status = false;
                return productReturn;
            }
        }



        public bool EditProductInternationalCode(ProductCodeModel productCodeModel)
        {
            try
            {

                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@ID", productCodeModel.ProductID);
                parameters.Add("@Code", productCodeModel.ProductCode);


                db.ExecuteStoredProcedure("Product_EditProductInternationalCode", parameters); // TODO: Call DBConnect Method and add Group detail.
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

        public bool ProductNameToValidate(ProductBasicModel productBasicModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", productBasicModel.ProductName);

                var result = db.ExecuteStoredProcedure<ProductBasicModel>("Product_Select_ProductNameToValidate", parameters); // TODO: Call DBConnect Method and Validate Group detail.

                if (result.Cast<ProductBasicModel>().Count() > 0)
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


        public IEnumerable GetProductByID(int ProductID)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@ProductID", ProductID);
                return db.ExecuteStoredProcedure<ProductBasicModel>("Product_SelectProductByIDForBasicModel", parameters);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public bool ProductCodeToValidate(ProductBasicModel productBasicModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Code", productBasicModel.ProductCode);

                var result = db.ExecuteStoredProcedure<ProductBasicModel>("Product_Select_ProductCodeToValidate", parameters); // TODO: Call DBConnect Method and Validate Group detail.

                if (result.Cast<ProductBasicModel>().Count() > 0)
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
        public IList<IEnumerable> GetAllProducts()
        {
            try
            {
                db = new DBConnect();
                IList<Type> productsList = new List<Type>();
                productsList.Add(typeof(ListProductModel));
                return db.ExecuteStoredProcedureMultiple("Product_SelectAllProducts", productsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public bool AddProductToAllStores(int ProductID)
        {
            try
            {

                db = new DBConnect();

                var parameters = new DynamicParameters();
                StoresRepository storesRepository = new StoresRepository();

              IList<IEnumerable> enumerable=  storesRepository.GetAllStores();

              IEnumerable<StoresModel> list=  enumerable[0].Cast<StoresModel>().ToList();

                foreach (var item in list)
                {
                    parameters.Add("@StoreID", item.StoreID);
                    parameters.Add("@Code", ProductID);
                    parameters.Add("@Stock", 0);



                    db.ExecuteStoredProcedure("Product_AddProductTotalStockInAllStores", parameters); // TODO: Call DBConnect Method and add Group detail.


                }

               
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

        public bool DeleteProduct(int Code)
        {

            try
            {
                db = new DBConnect();

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@Code", Code);

                db.ExecuteStoredProcedure("Product_DeleteProduct", dynamicParameters);

                return true;
            }
            catch (Exception ex)
            {

                return false;

                    throw new Exception(ex.Message);
            }

           
        }



        public IList<IEnumerable> SearchProductsByStore(int StoreID)
        {
            try
            {
                db = new DBConnect();

                IList<Type> productsList = new List<Type>();

                productsList.Add(typeof(ListProductModel));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@StoreID", StoreID);

                return db.ExecuteStoredProcedureMultiple("Product_SelectAllProductsInStore", dynamicParameters,productsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public IList<IEnumerable> SearchProductsBySupplier(int SupplierID)
        {
            try
            {
                db = new DBConnect();

                IList<Type> productsList = new List<Type>();

                productsList.Add(typeof(ListProductModel));

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SupplierID", SupplierID);

                return db.ExecuteStoredProcedureMultiple("Product_SelectAllProductsWithSupplier", dynamicParameters, productsList);
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


    public class ProductReturn
    {

        public bool Status { get; set; }
        public int ProductID { get; set; }
        public ProductBasicModel SelectedProduct { get; set; }



    }
}
