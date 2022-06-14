using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class CustomersModel
    {

    }
    public class AddCustomerModel
    {

        public string Name { get; set; }
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
        public int CatID { get; set; }

    }

    public class EditCustomerModel
    {

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
        public int CatID { get; set; }

    }
    public class ListCustomersModel
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public float Balance { get; set; }
        public string Category { get; set; }


    }

    public class AddCustomerRebateActionModel
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public int EmpID { get; set; }
        public float MoneyValue { get; set; }
        public int ReasonID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int SalesPointID { get; set; }
        public string Details { get; set; }
    }
    public class AddCustomerPostBalanceModel
    {

        public int CustomerID { get; set; }
        public int EmpID { get; set; }
        public float MoneyValue { get; set; }
        public int ReasonID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int UserID { get; set; }
        public int SalesPointID { get; set; }
        public string Details { get; set; }

    }
    public class AddCustomerCheckRebateActionModel
    {

        public int CustomerID { get; set; }
        public float MoneyValue { get; set; }
        public int ReasonID { get; set; }
        public int EmpID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int UserID { get; set; }
        public int SalesPointID { get; set; }
        public string Details { get; set; }
        public int BankID { get; set; }
        public int ChequeNum { get; set; }
        public DateTime DueDate { get; set; }

    }
    public class ListCustomerMoneyDetailsModel
    {

        public int PayID { get; set; }
        public int ReasonID { get; set; }
        public string UserName { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Reason { get; set; }
        public string SalesPoint { get; set; }
        public int SalesPointID { get; set; }


        public float MoneyValue { get; set; }

        public float BalanceAfter { get; set; }


    }
    public class CustomerTotalCommunicationSummaryModel
    {

        public float TotalCommunication { get; set; }
        public float CompletedCommunication { get; set; }

        public float RestCommunication { get; set; }



    }
    public class AddCustomerCancelMoneyAction
    {
        public int PayID { get; set; }
        public int CustomerID { get; set; }
        public int EmpID { get; set; }
        public int ReasonID { get; set; }
        public float MoneyValue { get; set; }
        public int SalesPointID { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
    }
    public class CustomerMoneyActionDetails
    {
        public int PayID { get; set; }
        public string Details { get; set; }


    }
    public class ListCustomerCanceldMoneyDetailsModel
    {
        public int PayID { get; set; }
        public int ReasonID { get; set; }
        public string UserName { get; set; }
        public string EmpName { get; set; }

        public string UName { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Reason { get; set; }
        public string SalesPoint { get; set; }
        public int SalesPointID { get; set; }
        public float MoneyValue { get; set; }
        public float BalanceAfter { get; set; }
    }
}
