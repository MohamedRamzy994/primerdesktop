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
    public class SettingsRepository
    {
        dbhelper.DBConnect db;
        public bool SystemUpdateSettings(SettingsModel settingsModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@ShopName", settingsModel.ShopName);
                paramters.Add("@WorkType", settingsModel.WorkType);
                paramters.Add("@Logo", settingsModel.Logo);
                paramters.Add("@Background", settingsModel.Background);
                paramters.Add("@Address", settingsModel.Address);

                db.ExecuteStoredProcedureReturnValueInt("System_UpdateSettings", paramters);


                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public IEnumerable GetSystemSettings()
        {
            try
            {
                db = new DBConnect();
                return db.ExecuteStoredProcedure<SettingsModel>("System_SelectSettings");

            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IEnumerable GetSelectedSettingsThemes()
        {
            try
            {
                db = new DBConnect();
                return db.ExecuteStoredProcedure<SettingsThemesModel>("System_SelectedSettingsThemes");

            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        public bool SystemSelectSettingsThemes(int ThemeID)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@ThemID", ThemeID);
                db.ExecuteStoredProcedureReturnValueInt("System_SelectSettingsThemes", paramters);
                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public IEnumerable SystemSelectAllSettingsThemes()
        {
            try
            {
                db = new DBConnect();
                return db.ExecuteStoredProcedure<SettingsThemesModel>("System_SelectAllSettingsThemes");

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
