using Dapper;
using PREMIER.core;
using PREMIER.dbhelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.data
{
   public  class BankCheckRepository
    {

        private DBConnect db;

        public IList<IEnumerable> GetAllBanks()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListBanksModel));
                return db.ExecuteStoredProcedureMultiple("Bank_SelecAllBank", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public bool AddBank(string BankName)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", BankName);

                db.ExecuteStoredProcedure("Bank_AddBank", parameters); // TODO: Call DBConnect Method and add Store detail.
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
        public bool DeleteBank(int BankID)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@BankID", BankID);

                db.ExecuteStoredProcedure("Bank_DeleteBank", parameters); // TODO: Call DBConnect Method and add user detail.
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

        //:TODO  update Store using the system  in UserModule . (APPLET)
        public bool EditBank(ListBanksModel listBanksModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();

                parameters.Add("@Name", listBanksModel.BankName);
                parameters.Add("@BankID", listBanksModel.BankID);

                db.ExecuteStoredProcedure("Bank_EditBank", parameters); // TODO: Call DBConnect Method and add user detail.
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
