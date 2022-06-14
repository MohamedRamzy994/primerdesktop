using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class SupplierModel
    {

        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public float Balance { get; set; }
        public bool Stopped { get; set; }


    }

    public class AddSupplierModel
    {

        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public float Balance { get; set; }
        public bool Stopped { get; set; }

    }

    public class AddRebateActionModel
    {

        public int SupplierID { get; set; }
        public float MoneyValue { get; set; }
        public int ReasonID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int UserID { get; set; }
        public int SalesPointID { get; set; }
        public string Details { get; set; }

    }

    public class AddCheckRebateActionModel
    {

        public int SupplierID { get; set; }
        public float MoneyValue { get; set; }
        public int ReasonID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int UserID { get; set; }
        public int SalesPointID { get; set; }
        public string Details { get; set; }
        public int BankID { get; set; }
        public int ChequeNum { get; set; }
        public DateTime DueDate { get; set; }

    }
    public class AddPostBalanceModel
    {

        public int SupplierID { get; set; }
        public float MoneyValue { get; set; }
        public int ReasonID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int UserID { get; set; }
        public int SalesPointID { get; set; }
        public string Details { get; set; }

    }

    public class ListSupplierMoneyDetailsModel
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

    public class ListSupplierCanceldMoneyDetailsModel
    {

        public int PayID { get; set; }
        public int ReasonID { get; set; }
        public string UserName { get; set; }
        public string UName { get; set; }

        public DateTime DateSubmit { get; set; }
        public string Reason { get; set; }
        public string SalesPoint { get; set; }
        public int SalesPointID { get; set; }


        public float MoneyValue { get; set; }

        public float BalanceAfter { get; set; }


    }
    public class SupplierTotalCommunicationSummaryModel
    {

        public float TotalCommunication { get; set; }
        public float CompletedCommunication { get; set; }

        public float RestCommunication { get; set; }



    }

    public class AddSupplierCancelMoneyAction
    {
        public int PayID { get; set; }
        public int SupplierID { get; set; }
        public int ReasonID { get; set; }
        public float MoneyValue { get; set; }
        public int SalesPointID { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
    }

    public class SupplierMoneyActionDetails
    {
        public int PayID { get; set; }
        public string  Details { get; set; }


    }
}
