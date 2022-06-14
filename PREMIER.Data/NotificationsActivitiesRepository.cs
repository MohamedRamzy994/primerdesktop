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
    public class NotificationsActivitiesRepository
    {
        private DBConnect db ;
        public int CreateActivityRecord(AddActivityModel addActivityModel)
        {
            try
            {
                int status = 0;
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@UserID", addActivityModel.UserID);
                parameters.Add("@POS", addActivityModel.POS);
                parameters.Add("@DateSubmit", addActivityModel.DateSubmit);
                parameters.Add("@Read", addActivityModel.Read);
                parameters.Add("@Type", addActivityModel.Type);

                status=  db.ExecuteStoredProcedureReturnValueInt("System_CreateActivityRecord", parameters); // TODO: Call DBConnect Method and add Store detail.
                return status;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return 0;
            }
        }

        public IList<IEnumerable> GetAllActivitiesRecords()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListAllActivitiesRecordsModel));
                return db.ExecuteStoredProcedureMultiple("System_GetAllActivitiesRecords", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllNotificationsRecords()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListAllNotificationRecordsModel));
                return db.ExecuteStoredProcedureMultiple("System_SelectAllNotifications", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        public IList<IEnumerable> GetAllSalesPointsNotificationsRecords()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListAllSalesPointsNotificationRecordsModel));
                return db.ExecuteStoredProcedureMultiple("System_SelectAllSalesPointsNotifications", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }
        

        public bool UpdateActivityRecord(int ID, bool Read)
        {
            try
            {
                
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                parameters.Add("@Read", Read);

                db.ExecuteStoredProcedure("System_UpdateActivitiesRecordRead", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return false ;
            }
        }
        public int CreateNotificationRecord(AddNotificationModel addNotificationModel)
        {
            try
            {
                int status = 0;
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@ProductID", addNotificationModel.ProductID);
                parameters.Add("@StoreID", addNotificationModel.StoreID);
                parameters.Add("@DateSubmit", addNotificationModel.DateSubmit);
                parameters.Add("@Read", addNotificationModel.Read);
                status = db.ExecuteStoredProcedureReturnValueInt("System_CreateNotificationRecord", parameters); // TODO: Call DBConnect Method and add Store detail.
                return status;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return 0;
            }
        }

        public int CreateSalesPointsNotificationRecord(AddSalesPointsNotificationModel addSalesPointsNotificationModel)
        {
            try
            {
                int status = 0;
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@POS", addSalesPointsNotificationModel.POS);
                parameters.Add("@DateSubmit", addSalesPointsNotificationModel.DateSubmit);
                parameters.Add("@Read", addSalesPointsNotificationModel.Read);
                status = db.ExecuteStoredProcedureReturnValueInt("System_CreateSalesPointsNotificationRecord", parameters); // TODO: Call DBConnect Method and add Store detail.
                return status;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return 0;
            }
        }

        public bool UpdateNotificationRecord(int ID, bool Read)
        {
            try
            {

                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                parameters.Add("@Read", Read);

                db.ExecuteStoredProcedure("System_UpdateNotificationRecordRead", parameters); // TODO: Call DBConnect Method and add Store detail.
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

        public bool UpdateSalesNotificationRecord(int ID, bool Read)
        {
            try
            {

                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                parameters.Add("@Read", Read);

                db.ExecuteStoredProcedure("System_UpdateSalesNotificationRecordRead", parameters); // TODO: Call DBConnect Method and add Store detail.
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
