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
    public class ProductGroupsRepository
    {
        private DBConnect db;

        public bool AddGroup(ProductGroupsModel productGroupsModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", productGroupsModel.CatName);

                db.ExecuteStoredProcedure("Product_AddGroup", parameters); // TODO: Call DBConnect Method and add Group detail.
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

        public bool GroupsNameToValidate(ProductGroupsModel productGroupsModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", productGroupsModel.CatName);

                var result = db.ExecuteStoredProcedure<ProductGroupsModel>("Product_Select_GroupsNameToValidate", parameters); // TODO: Call DBConnect Method and Validate Group detail.

                if (result.Cast<ProductGroupsModel>().Count() > 0)
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

        public IList<IEnumerable> GetAllGroups()
        {
            try
            {
                db = new DBConnect();
                IList<Type> GroupsList = new List<Type>();
                GroupsList.Add(typeof(ProductGroupsModel));
                return db.ExecuteStoredProcedureMultiple("Product_SelectAll_GroupsInSearch", GroupsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        //:TODO  update Group using the system  in UserModule . (APPLET)
        public bool EditGroup(ProductGroupsModel productGroupsModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();

                parameters.Add("@Name", productGroupsModel.CatName);
                parameters.Add("@ID", productGroupsModel.CatID);

                db.ExecuteStoredProcedure("Product_UpdateGroup", parameters); // TODO: Call DBConnect Method and add user detail.
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

        //:TODO  delete specific  Group  from using the system  in GroupsModule . (APPLET)
        public bool DeleteGroup(ProductGroupsModel productGroupsModel)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@ID", productGroupsModel.CatID);

                db.ExecuteStoredProcedure("Product_DeletteGroup", parameters); // TODO: Call DBConnect Method and add user detail.
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
