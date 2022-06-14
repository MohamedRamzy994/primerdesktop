using PREMIER.dbhelper;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PREMIER.core;

namespace PREMIER.data
{
   public class ProductUnitsRepository
    {
        DBConnect db;

        public IList<IEnumerable> GetAllProductUnits()
        {
            try
            {
                db = new DBConnect();
                IList<Type> UnitsList = new List<Type>();
                UnitsList.Add(typeof(ProductUnitsModel));

                return db.ExecuteStoredProcedureMultiple("Product_SelectAllUnits", UnitsList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllProductCatUnits()
        {
            try
            {
                db = new DBConnect();
                IList<Type> UnitsCatList = new List<Type>();
                UnitsCatList.Add(typeof(ProductUnitsCatModel));

                return db.ExecuteStoredProcedureMultiple("Product_SelectAllUnitsCats", UnitsCatList);
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
