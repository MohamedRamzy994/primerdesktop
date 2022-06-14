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
    public class EmployeesRepository
    {
        dbhelper.DBConnect db;
        public bool AddEmployee(AddEmployeeModel addEmployeeModel)
        {
            try
            {
                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@Name", addEmployeeModel.Name);
                paramters.Add("@Mob", addEmployeeModel.Mob);
                paramters.Add("@Salary", addEmployeeModel.Salary);
                paramters.Add("@img", addEmployeeModel.Image);
                paramters.Add("@IsSalesMan", addEmployeeModel.IsSalesMan);
               
                db.ExecuteStoredProcedureReturnValueInt("Emp_AddEmp", paramters);
                                                                         

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        public IList<IEnumerable> GetAllEmployees()
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(ListEmployeesModel));
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAll_EmpsInSearch", employeesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllDebitsToken(int EmpID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(ListDebitsTokenModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", EmpID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAllDebitsToken",dynamicParameters, employeesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllCommisionAndPunishByDate(int EmpID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(ListCommisionAndPunishByDateModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", EmpID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAllCommisionAndPunish_ByDate", dynamicParameters, employeesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public IList<IEnumerable> GetAllCanceldCommisionAndPunishCancled(int EmpID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(ListAllCanceldCommisionAndPunishCancled));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", EmpID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAllCanceldCommisionAndPunish", dynamicParameters, employeesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllDebitsPayed(int EmpID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(ListDebitsTokenModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", EmpID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAllDebit_Payed", dynamicParameters, employeesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllEmployeeSalary(int EmpID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(ListEmployeeSalaryModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", EmpID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAllSalaryToken", dynamicParameters, employeesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }

        public IList<IEnumerable> GetAllGivedMoney(int EmpID)
        {
            try
            {
                db = new DBConnect();
                IList<Type> employeesList = new List<Type>();
                employeesList.Add(typeof(ListEmployeeGivedMoneyModel));
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmpID", EmpID);
                return db.ExecuteStoredProcedureMultiple("Emp_SelectAllGivedMoney", dynamicParameters, employeesList);
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                return null;
            }
        }


        public bool DeleteEmployee(ListEmployeesModel listEmployeesModel)
        {
            try
            {
                db = new DBConnect();
                var parameters = new DynamicParameters();
                parameters.Add("@ID", listEmployeesModel.EmpID);

                db.ExecuteStoredProcedure("Emp_DeleteEmp", parameters); // TODO: Call DBConnect Method and add user detail.
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



        public bool EditEmployee(AddEmployeeModel addEmployeeModel )
        {
            try
            {
                db = new DBConnect();

                var parameters = new DynamicParameters();
                parameters.Add("@EmpID", addEmployeeModel.EmpID);
                parameters.Add("@Name", addEmployeeModel.Name);
                parameters.Add("@Mob", addEmployeeModel.Mob);
                parameters.Add("@Salary", addEmployeeModel.Salary);
                parameters.Add("@img", addEmployeeModel.Image);
                parameters.Add("@IsSalesMan", addEmployeeModel.IsSalesMan);
                                                           

        db.ExecuteStoredProcedure("Emp_EditEmpBasics", parameters); // TODO: Call DBConnect Method and add Store detail.
                return true;
            }
            catch (Exception ex)
            {
                string bodyTitleMessage = "<h1>Portal:SparkLean</h1><br/><h2>Exception :  public IEnumerable SignUp(LoginModel lm)</h2>";
                string bodyMessage = "<p><b>parameters: spName : </b>SK_RegisteUser</p>";
                //SparKlean.Data.XError.CatchError(ex, bodyTitleMessage, bodyMessage, "LoginRepo");
                throw new Exception(ex.Message);

                return false;

            }
        }

        public bool AddEmployeeDebits(AddEmployeeDebitsModel addEmployeeDebitsModel)
        {
            try
            {

                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@EmpID", addEmployeeDebitsModel.EmpID);
                paramters.Add("@MoneyValue", addEmployeeDebitsModel.MoneyValue);
                paramters.Add("@UserID", addEmployeeDebitsModel.UserID);
                paramters.Add("@DateSubmit", addEmployeeDebitsModel.DateSubmit);
                paramters.Add("@SalesPointID", addEmployeeDebitsModel.SalesPointID);

                db.ExecuteStoredProcedureReturnValueInt("Emp_AddDebit", paramters);

    



                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public bool AddEmployeeCommisionPunish(AddEmployeeComPunModel addEmployeeComPunModel)
        {
            try
            {

                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@EmpID", addEmployeeComPunModel.EmpID);
                paramters.Add("@MoneyValue", addEmployeeComPunModel.MoneyValue);
                paramters.Add("@UserID", addEmployeeComPunModel.UserID);
                paramters.Add("@DateSubmit", addEmployeeComPunModel.DateSubmit);
                paramters.Add("@Details", addEmployeeComPunModel.Details);
                paramters.Add("@ReasonID", addEmployeeComPunModel.ReasonID);
                db.ExecuteStoredProcedureReturnValueInt("Emp_AddCommisionOrPunish", paramters);
                                                          
                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public bool AddEmployeeGiveMoney(AddEmployeeGiveMoneyModel addEmployeeGiveMoneyModel)
        {
            try
            {

                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@EmpID", addEmployeeGiveMoneyModel.EmpID);
                paramters.Add("@MoneyValue", addEmployeeGiveMoneyModel.MoneyValue);
                paramters.Add("@UserID", addEmployeeGiveMoneyModel.UserID);
                paramters.Add("@SalesPointID", addEmployeeGiveMoneyModel.SalesPointID);
                paramters.Add("@DateSubmit", addEmployeeGiveMoneyModel.DateSubmit);
                paramters.Add("@Details", addEmployeeGiveMoneyModel.Details);
                paramters.Add("@ReasonID", addEmployeeGiveMoneyModel.ReasonID);
                db.ExecuteStoredProcedureReturnValueInt("Emp_AddGiveMoney", paramters);

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public bool AddEmployeePayDebitsDirecte(AddEmployeePayDebitsDirecteModel addEmployeePayDebitsDirecteModel)
        {
            try
            {

                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@EmpID", addEmployeePayDebitsDirecteModel.EmpID);
                paramters.Add("@MoneyValue", addEmployeePayDebitsDirecteModel.MoneyValue);
                paramters.Add("@UserID", addEmployeePayDebitsDirecteModel.UserID);
                paramters.Add("@SalesPointID", addEmployeePayDebitsDirecteModel.SalesPointID);
                paramters.Add("@DateSubmit", addEmployeePayDebitsDirecteModel.DateSubmit);
                db.ExecuteStoredProcedureReturnValueInt("Emp_PayDebitsDirecte", paramters);

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public bool AddEmployeeSalary(AddEmployeeAddSalaryModel addEmployeeAddSalaryModel)
        {
            try
            {

                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@EmpID", addEmployeeAddSalaryModel.EmpID);
                paramters.Add("@BasicSalary", addEmployeeAddSalaryModel.BasicSalary);
                paramters.Add("@Comm", addEmployeeAddSalaryModel.Comm);
                paramters.Add("@PayForDebit", addEmployeeAddSalaryModel.PayForDebit);
                paramters.Add("@Punish", addEmployeeAddSalaryModel.Punish);
                paramters.Add("@UserID", addEmployeeAddSalaryModel.UserID);
                paramters.Add("@SalesPointID", addEmployeeAddSalaryModel.SalesPointID);
                paramters.Add("@DateSubmit", DateTime.Now);
                db.ExecuteStoredProcedureReturnValueInt("Emp_AddSalary", paramters);

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public bool AddEmployeeCancelCommisionAndPunish(AddEmployeeCancelCommisionAndPunishModel employeeCancelCommisionAndPunishModel)
        {
            try
            {

                db = new DBConnect();

                DynamicParameters paramters = new DynamicParameters();
                paramters.Add("@ActionID", employeeCancelCommisionAndPunishModel.ActionID);
                paramters.Add("@UserID", employeeCancelCommisionAndPunishModel.UserID);
                paramters.Add("@DateSubmit", DateTime.Now);
                db.ExecuteStoredProcedureReturnValueInt("Emp_CancelCommisionAndPunish", paramters);

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}
