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
   public class ProductEditedRepository
    {
        DBConnect db;

        public IEnumerable GetProductDetails(int ProductId)
        {
            try
            {
                db = new DBConnect();


                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ProductID", ProductId);

               return db.ExecuteStoredProcedure<ProductBasicModel>("Product_SelectProductByIDForBasicModel", dynamicParameters);

                         
            }
            catch (Exception ex)
            {
               

                throw new Exception (ex.Message);
            }


          
        }

        public IEnumerable GetProductCodeDetails(int ProductId)
        {
            try
            {
                db = new DBConnect();


                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Code", ProductId);

                return db.ExecuteStoredProcedure<ProductCodeModel>("Product_SelectProductInternationalCodes", dynamicParameters);


            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }



        }

        public IEnumerable GetProductSupplierDetails(int ProductId)
        {
            try
            {
                db = new DBConnect();

               

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Code", ProductId);

             return db.ExecuteStoredProcedure<SupplierModel>("Product_SelectProductSuppliers", dynamicParameters);



            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }



        }


        public IEnumerable GetProductUnitDetails(int ProductId)
        {
            try
            {
                db = new DBConnect();



                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Code", ProductId);

                return db.ExecuteStoredProcedure<ProductSelectedUnitsModel>("Product_SelectProductUnits", dynamicParameters);



            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }



        }


        public IEnumerable GetProductUnitDefaultDetails(int ProductId)
        {
            try
            {
                db = new DBConnect();



                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Code", ProductId);

                return db.ExecuteStoredProcedure<ProductUnitsDefaultModel>("Product_SelectDefaultSelectedUnit", dynamicParameters);



            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }



        }


        


    }
}
