using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class ReportsModel
    {

    }
    public class ListProductMoveMentReportModel
    {
        public int InvoiceID { get; set; }
        public string ActionType { get; set; }
        public string Actor { get; set; }
        public float Price { get; set; }
        public float Num { get; set; }
        public string Unit { get; set; }
        public DateTime DateSubmit { get; set; }

        public int ProductID { get; set; }



    }

    public class ListSupplierProductsInStoreModel
    {
        public int ProductID { get; set; }
        public string CatName { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public float Stock { get; set; }
        public int SupplierID { get; set; }
        public bool StopSale { get; set; }
        public bool StopBuy { get; set; }
    }


    public class ProductBuySelectTotalCommunicationReportModel
    {

        public int BuyNumber { get; set; }
        public int DiscardNumber { get; set; }
        public float BuyQuntity { get; set; }
        public float BuyPrice { get; set; }
        public float DiscardQuantity { get; set; }
        public float DiscardPrice { get; set; }




    }
    public class CustomerSelectTotalCommunicationReportModel
    {

        public int SaleNumber { get; set; }
        public int DiscardNumber { get; set; }
        public float SaleQuntity { get; set; }
        public float SalePrice { get; set; }
        public float DiscardQuantity { get; set; }
        public float DiscardPrice { get; set; }




    }
    public class ListProductSaleSelectMainInvoicesToReport
    {

        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }

        public string StoreName { get; set; }
        public DateTime DateSubmit { get; set; }

        public string UserName { get; set; }
        public float Net { get; set; }

        public int InvTypeID { get; set; }
        public int EmpID { get; set; }


        public bool Existing { get; set; }







    }

    public class ListSelectAdditionalCostEventToReport
    {
        public int SalesPointID { get; set; }
        public string SalesPoint { get; set; }
        public string Reason { get; set; }
        public float MoneyValue { get; set; }
        public string Details { get; set; }
        public DateTime DateSubmit { get; set; }
        public string UserName { get; set; }



    }
    public class ListGivedMoneyToReport
    {
        public int SalesPointID { get; set; }
        public string SalesPoint { get; set; }
        public string Reason { get; set; }
        public float MoneyValue { get; set; }
        public string Details { get; set; }
        public DateTime DateSubmit { get; set; }
        public string UserName { get; set; }
        public string EmpName { get; set; }




    }
    public class ListSupplierSelectProductSalesReport
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public float Num { get; set; }
        public float Price { get; set; }
        public float Stock { get; set; }
        public int InvoiceID { get; set; }






    }
    public class SystemCreateProfitLoseReport
    {
 
        public float AdditionalCost { get; set; }
        public float Sales { get; set; }
        public float Profit { get; set; }
        public float AllEmployee { get; set; }




    }
    public class SystemCreateTotalInformationMoneyReport
    {

        public float ProductsPrice { get; set; }
        public float SuppliersDebits { get; set; }
        public float CustomersDebits { get; set; }
        public float SalesPointsBalance { get; set; }
        public float NetBalance { get; set; }
        public float EmpDebits { get; set; }





    }



}
