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
    public class BranchesRepository
    {
        private DBConnect db;

        public IList<IEnumerable> GetAllBranches()
        {
            try
            {
                db = new DBConnect();
                IList<Type> banksList = new List<Type>();
                banksList.Add(typeof(ListBranchesModel));
                return db.ExecuteStoredProcedureMultiple("Branch_SelecAllBranches", banksList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public bool AddBranch(AddBranchModel addBranchModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@Name", addBranchModel.Name);
                parameters.Add("@DeviceIP", addBranchModel.DeviceIP);
                parameters.Add("@Address", addBranchModel.Address);

                db.ExecuteStoredProcedure("Branch_AddBranch", parameters); // TODO: Call DBConnect Method and add Store detail.
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

        public bool DeleteBranch(int BranchID)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchID", BranchID);

                db.ExecuteStoredProcedure("Branch_DeleteBranch", parameters); // TODO: Call DBConnect Method and add user detail.
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

        public bool EditBranch(ListBranchesModel listBranchesModel)
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();

                parameters.Add("@Name", listBranchesModel.Name);
                parameters.Add("@BranchID", listBranchesModel.BranchID);
                parameters.Add("@DeviceIP", listBranchesModel.DeviceIP);
                parameters.Add("@Address", listBranchesModel.Address);
                db.ExecuteStoredProcedure("Branch_EditBranch", parameters); // TODO: Call DBConnect Method and add user detail.
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
