using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PREMIER.core;
using PREMIER.dbhelper;
using Dapper;
using System.Data;
using System.Collections;

namespace PREMIER.data
{
    public class OAuthRepository
    {
        DBConnect DBConnect;

        //: TODO check user is existed by loginname&&Password in the system in AuthenticationModule (APPLET) .
        public bool Login(OAuthModel oAuthModel)
        {
            try
            {
                DBConnect = new DBConnect();

                DynamicParameters Params = new DynamicParameters();

                Params.Add("@LoginName", oAuthModel.LogInName, DbType.String, ParameterDirection.Input, 50);
                Params.Add("@Password", oAuthModel.Password, DbType.String, ParameterDirection.Input, 50);

                bool Authenticated = DBConnect.ExecuteStoredProcedureReturnValue("OAuthentication", Params);

                if (Authenticated == true)
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
                throw new Exception(ex.Message);
            }


        }

        //: TODO Get userInfo is existed by loginname&&Password in the system in AuthenticationModule (APPLET) .
        public IEnumerable GetAuthenticatedUserInfo(OAuthModel oAuthModel)
        {

            try
            {


                DBConnect = new DBConnect();

                DynamicParameters Params = new DynamicParameters();

                Params.Add("@LoginName", oAuthModel.LogInName, DbType.String, ParameterDirection.Input, 50);
                Params.Add("@Password", oAuthModel.Password, DbType.String, ParameterDirection.Input, 50);

                return DBConnect.ExecuteStoredProcedure<UserModel>("OAuthenticatedInfo", Params);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
