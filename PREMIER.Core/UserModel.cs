using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{    
    public class UserModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool SystemSettings { get; set; }
        public bool Existing { get; set; }
        public bool AdditionalCost { get; set; }
        public bool ReportAddCost { get; set; }
        public bool ReportProfitLose { get; set; }
        public bool ReportTotalMoneyInfo { get; set; }
        
        #region Store
        public bool StoreAdd { get; set; }
        public bool StoreEdit { get; set; }
        public bool StoreDelete { get; set; }
        public bool StoreTransferBalance { get; set; }

        #endregion

        #region Product
        public bool ProductAdd { get; set; }
        public bool ProductEdit { get; set; }
        public bool ProductDelete { get; set; }
        public bool ProductOpen { get; set; }
        public bool ProductOpenCancel { get; set; }
        public bool ProductResetStock { get; set; }

        #endregion

        #region Supplier
        public bool SupplierAdd { get; set; }
        public bool SupplierEdit { get; set; }
        public bool SupplierDelete { get; set; }
        public bool SupplierDeleteMoney { get; set; }
        public bool SupplierAddMoney { get; set; }
        #endregion

        #region Invoice
        public bool BuyInvoice { get; set; }
        public bool BuyInvoiceCancel { get; set; }
        public bool BuyDiscard { get; set; }

        #endregion

        #region Employee
        public bool EmpAdd { get; set; }
        public bool EmpEdit { get; set; }
        public bool EmpDelete { get; set; }
        public bool EmpComm { get; set; }
        public bool EmpCancelComm { get; set; }
        public bool EmpPunish { get; set; }
        public bool EmpCancelPunish { get; set; }
        public bool EmpDebit { get; set; }
        public bool EmpSalary { get; set; }
        #endregion

        #region Customer
        public bool CustomerAdd { get; set; }
        public bool CustomerEdit { get; set; }
        public bool CustomerDelete { get; set; }
        public bool CustomerAddMoney { get; set; }
        public bool CustomerCancelMoney { get; set; }
        #endregion

        #region Sales
        public bool SalesInvoice { get; set; }
        public bool SalesDiscount { get; set; }
        public bool SalesInvoiceCancel { get; set; }
        public bool SalesDiscard { get; set; }
        public bool SalesManSummaryReport { get; set; }
        public bool SalesPointDepositWithdrow { get; set; }
        public bool SalesPointTransferMoney { get; set; }
        public bool SalesPointReport { get; set; }
        #endregion

        #region Report
        public bool ReportProductMove { get; set; }
        public bool ReportStoreStock { get; set; }
        public bool ReportSupplierBuys { get; set; }
        public bool ReportCustomerSales { get; set; }
        public bool ReportSalesManSales { get; set; }
        #endregion

        #region User
        public bool UserAdd { get; set; }
        public bool UserEdit { get; set; }
        public bool UserDelete { get; set; }

        #endregion
        #region Branches
        public bool AddBranch { get; set; }
        public bool EditBranch { get; set; }
        public bool DeleteBranch { get; set; }
        #endregion
        #region SalesPoints
        public bool AddSalesPoint { get; set; }
        public bool EditSalesPoint { get; set; }
        public bool DeleteSalesPoint { get; set; }
        #endregion
        #region Records
        public bool AccessActivitiesRecord { get; set; }
        public bool AccessStoreNotifications { get; set; }
        public bool AccessSalesPointNotifications { get; set; }
        #endregion

    }
}
