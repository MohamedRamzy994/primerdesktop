using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PREMIER.core;
using PREMIER.dbhelper;


namespace PREMIER.data
{
    public class EmployeeComPunishRepository
    {

        DBConnect db;

        public IList<IEnumerable> GetAllEmployeeComPunish()
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(EmployeeComPunishModel));
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAll_CommisionAndPunishReasons", employeesList);
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
