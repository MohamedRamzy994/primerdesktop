using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class SalesPointModel
    {

    }
    public class ListSalesPointsModel
    {
        public int SalesPointID { get; set; }
        public string SalesPointMACEthernet { get; set; }
        public string SalesPointMACWireless { get; set; }


        public string SalesPoint { get; set; }
        public bool Active { get; set; }
        public float Balance { get; set; }

    }
    public class AddSalesPointsModel
    {
        public string SalesPointMACEthernet { get; set; }
        public string SalesPointMACWireless { get; set; }
        public string SalesPoint { get; set; }

    }
    public class ListWithdrawDepositReasonModel
    {
        public int ReasonID { get; set; }
        public string Reason { get; set; }
  

    }
    public class AddAdditionalCostEventModel
    {
        public float MoneyValue { get; set; }
        public string Details { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int SalesPointID { get; set; }
        public int SelectedReasonID { get; set; }

    }

    public class AddTransferMoneyEventModel
    {
        public float MoneyValue { get; set; }
        public string Details { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int SalesPointIDFrom { get; set; }
        public int SalesPointIDTo { get; set; }

    }
    public class ListGetStartBalanceModel
    {

        public float CustomerPayed { get; set; }
        public float TransferToThis { get; set; }
        public float Deposit { get; set; }
        public float Withdraw { get; set; }
        public float TransferFromThis { get; set; }
        public float SupplierPayed { get; set; }
        public float CustomerRetrieve { get; set; }
        public float Salary { get; set; }
        public float EmpDebits { get; set; }
        public float CustomerTanzelCancel { get; set; }
        public float SupplierTanzelCancel { get; set; }
        public float CustomerRetrieveCancel { get; set; }
        public float Balance { get; set; }
        public float AddCost { get; set; }
        public float EmpGivedMoney { get; set; }
        public float EmpPayedDebitDirect { get; set; }


    }


}
