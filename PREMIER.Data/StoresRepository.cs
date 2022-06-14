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
   public class StoresRepository
    {
        private DBConnect db;

        public bool AddStore(StoresModel storesModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", storesModel.StoreName);

                db.ExecuteStoredProcedure("Stores_AddStore", parameters); // TODO: Call DBConnect Method and add Store detail.
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

        public bool StoresNameToValidate(StoresModel storesModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", storesModel.StoreName);

               var result= db.ExecuteStoredProcedure<StoresModel>("Stores_Select_StoresNameToValidate", parameters); // TODO: Call DBConnect Method and Validate Store detail.

                if (result.Cast<StoresModel>().Count() > 0)
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

        public IList<IEnumerable> GetAllStores()
        {
            try
            {
                db = new DBConnect();
                IList<Type> storesList = new List<Type>();
                storesList.Add(typeof(StoresModel));
                return db.ExecuteStoredProcedureMultiple("Stores_SelectAll_StoresInSearch", storesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetStoreByName(string StoreName)
        {
            try
            {
                db = new DBConnect();
                IList<Type> storesList = new List<Type>();

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", StoreName);
                storesList.Add(typeof(StoresModel));
                return db.ExecuteStoredProcedureMultiple("Stores_Select_StoresNameToValidate", dynamicParameters , storesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        //:TODO  update Store using the system  in UserModule . (APPLET)
        public bool EditStore(StoresModel storesModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();

                parameters.Add("@Name", storesModel.StoreName);
                parameters.Add("@ID", storesModel.StoreID);

                db.ExecuteStoredProcedure("Stores_UpdateStore", parameters); // TODO: Call DBConnect Method and add user detail.
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

        //:TODO  delete specific  store  from using the system  in StoresModule . (APPLET)
        public bool DeleteStore(StoresModel storesModel)
        {
            try
            {
                db = new DBConnect();              
                var parameters = new DynamicParameters();
                parameters.Add("@ID", storesModel.StoreID);
             
                db.ExecuteStoredProcedure("Stores_DeleteStore", parameters); // TODO: Call DBConnect Method and add user detail.
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
