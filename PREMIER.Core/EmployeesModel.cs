using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
   public class EmployeesModel
    {



        


    }

    public class AddEmployeeModel
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Mob { get; set; }
        public float Salary { get; set; }
        public string Image { get; set; }
        public bool IsSalesMan { get; set; }


    }

    public class ListEmployeesModel
    {

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Mobile { get; set; }
        public string PPCard { get; set; }
        public float Salary { get; set; }
        public bool IsSalesMan { get; set; }
        public float Debit { get; set; }
        public float SalesDebts { get; set; }



    }

    public class ListDebitsTokenModel
    {

        public int ActionID { get; set; }
        public float MoneyValue { get; set; }
        public DateTime DateSubmit { get; set; }
        public string UserName { get; set; }
        



    }


    public class ListCommisionAndPunishByDateModel
    {

        public int ActionID { get; set; }
        public int ReasonID { get; set; }
        public float MoneyValue { get; set; }
        public DateTime DateSubmit { get; set; }
        public string UserName { get; set; }
        public string Reason { get; set; }
        public string Details { get; set; }






    }
  


    public class AddEmployeeDebitsModel
    {
        public int EmpID { get; set; }
        public float MoneyValue { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int SalesPointID { get; set; }
     
    }


    public class AddEmployeeComPunModel
    {
        public int EmpID { get; set; }
        public int ReasonID { get; set; }
        public float MoneyValue { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Details { get; set; }

    }

    public class ListAllCanceldCommisionAndPunishCancled
    {
        public int ActionID { get; set; }
        public string Reason { get; set; }
        public float MoneyValue { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateCanceld { get; set; }
        public string Details { get; set; }

    }

    
    public class AddEmployeeGiveMoneyModel
    {
        public int EmpID { get; set; }
        public int ReasonID { get; set; }
        public float MoneyValue { get; set; }
        public int UserID { get; set; }
        public int SalesPointID { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Details { get; set; }

    }
    public class AddEmployeePayDebitsDirecteModel
    {
        public int EmpID { get; set; }
        public float MoneyValue { get; set; }
        public int UserID { get; set; }
        public int SalesPointID { get; set; }
        public DateTime DateSubmit { get; set; }


    }

    public class AddEmployeeAddSalaryModel
    {
        public int EmpID { get; set; }
        public float BasicSalary { get; set; }
        public float Comm { get; set; }
        public float Punish { get; set; }
        public float PayForDebit { get; set; }
        public int SalesPointID { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }


    }

    public class ListEmployeeSalaryModel
    {

        public int ActionID { get; set; }
        public float Commision { get; set; }
        public float Punish { get; set; }
        public float BasicSalary { get; set; }
        public float NetSalary { get; set; }
        public float PayForDebit { get; set; }
        public DateTime DateSubmit { get; set; }
        public string UserName { get; set; }
        public string EmpName { get; set; }


    }
    public class ListEmployeeGivedMoneyModel
    {
        public int ActionID { get; set; }
        public float MoneyValue { get; set; }
        public string UserName { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Details { get; set; }


    }
    public class AddEmployeeCancelCommisionAndPunishModel
    {

        public int ActionID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int UserID { get; set; }




    }






}
