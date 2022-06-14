using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class ProductSalesModel
    {


    }
    public class ProductSaleMainTableModel
    {

        public int? InvoiceID { get; set; }

        public int UserID { get; set; }
        public int EmpID { get; set; }

        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateSubmit { get; set; }
        public float Total { get; set; }
        public float Addtions { get; set; }
        public float? TotalPayed { get; set; }
        public float? Cash { get; set; }
        public float Net { get; set; }
        public float? DiscPercent { get; set; }
        public float DiscLE { get; set; }
        public int? PayID { get; set; }
        public string Notes { get; set; }
        public int InvTypeID { get; set; }
        public int? SalesPointID { get; set; }
        public bool? Existing { get; set; }
        public List<ProductSaleTableModel> SelectedProducts { get; set; }

    }

    public class ProductSaleTableModel
    {
        public int? InvoiceID { get; set; }

        public int ProductID { get; set; }
        public float Num { get; set; }

        public int UnitID { get; set; }

        public float ChangeNum { get; set; }
        public float Price { get; set; }
        public float DiscardNum { get; set; }
        public float TotalDisc { get; set; }
        public float NetPrice { get; set; }

        public int SequanceID { get; set; }

 




    }

    public class ProductSaleSelectMainInvoices
    {

        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }

        public string StoreName { get; set; }
        public DateTime DateSubmit { get; set; }

        public string UserName { get; set; }
        public float Net { get; set; }

        public int InvTypeID { get; set; }

        public bool Existing { get; set; }







    }

    public class ProductSaleInvoiceMainDetails
    {


        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string EmpName { get; set; }
        public string UserName { get; set; }
        public string StoreName { get; set; }
        public int? PayID { get; set; }
        public int EmpID { get; set; }

        public int StoreID { get; set; }

        public float Total { get; set; }
        public float Additions { get; set; }
        public float DiscPercent { get; set; }
        public float DiscLE { get; set; }
        public float Net { get; set; }
        public float? TotalPayed { get; set; }
        public float? Rem { get; set; }
        public string Notes { get; set; }
        public DateTime DateSubmit { get; set; }


        public bool? Existing { get; set; }




    }

    public class ProductSaleInvoiceItems
    {


        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float Num { get; set; }
        public string UnitName { get; set; }
        public float Price { get; set; }
        public float Stock { get; set; }
        public float ChangeNum { get; set; }
        public float DiscardNum { get; set; }
        public float TotalDisc { get; set; }
        public float NetPrice { get; set; }
        public int SequanceID { get; set; }







    }

    public class ProductSaleDiscardSelectMainInvoicesItems
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public float Num { get; set; }
        public string UnitName { get; set; }
        public float Price { get; set; }
        public float ChangeNum { get; set; }
        public bool Stock { get; set; }

    }

    public class ProductSaleDiscardMainModel
    {
        public int InvoiceID { get; set; }
        public float DiscardValue { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int DefaultSalesPointID { get; set; }
        public int ThisSalesPointID { get; set; }
      

        public bool GetMoneyBack { get; set; }
            
        public int StoreID { get; set; }


        public List<ProductSaleDiscardMainItemsModel> DiscardSaleMainItems { get; set; }

    }
    public class ProductSaleDiscardMainItemsModel
    {
        public int DiscardID { get; set; }
        public int ProductID { get; set; }

        public float DiscNum { get; set; }
        public int UnitID { get; set; }
        public float Price { get; set; }
        public float DiscNum_In_Max { get; set; }
        public float DiscNum_In_Old { get; set; }
        public int StoreID { get; set; }
        public int InvoiceID { get; set; }
        public float DiscChangeNum { get; set; }
        public int SequanceID { get; set; }

    }

    public class ProductSaleDiscardMainNotSpecifiedModel
    {
        public int CustomerID { get; set; }
        public float Total { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int DefaultSalesPointID { get; set; }
        public int ThisSalesPointID { get; set; }
        public bool GetMoneyBack { get; set; }


        public int StoreID { get; set; }
        public int EmpID { get; set; }

        public List<ProductSaleDiscardMainNotSpecifiedItemsModel> DiscardSaleMainItems { get; set; }

    }
    public class ProductSaleDiscardMainNotSpecifiedItemsModel
    {
      
        public float Num { get; set; }
        public float ChangeNum { get; set; }
        public int DiscardID { get; set; }
        public int ProductID { get; set; }

        public int UnitID { get; set; }
        public float Price { get; set; }

        public int StoreID { get; set; }


    }
    public class ProductSaleDiscardSelectMainInvoices
    {

        public int DiscardID { get; set; }
        public string CustomerName { get; set; }
        public string StoreName { get; set; }
        public DateTime DateSubmit { get; set; }

        public string UserName { get; set; }
        public float DiscardValue { get; set; }
        public bool Existing { get; set; }
       





    }

    public class ProductSaleDiscardNotSelectMainInvoices
    {

        public int DiscardID { get; set; }
        public string CustomerName { get; set; }
        public string StoreName { get; set; }
        public DateTime DateSubmit { get; set; }

        public string UserName { get; set; }
        public float DiscardValue { get; set; }
        public bool Existing { get; set; }


    }


    public class ProductSaleDiscardNotSelectMainInvoicesItems
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public float Num { get; set; }
        public string UnitName { get; set; }
        public float Price { get; set; }
        public float ChangeNum { get; set; }
        public bool Stock { get; set; }

    }

    public class ProductSaleProfitSelectMainInvoices
    {

        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }

        public string StoreName { get; set; }
        public DateTime DateSubmit { get; set; }

        public string UserName { get; set; }
        public float Net { get; set; }
        public float Profit { get; set; }
        public float Cost { get; set; }
        public int InvTypeID { get; set; }

        public bool Existing { get; set; }


    }
    public class ProductDailySalesInvoices
    {
        public int ProductID { get; set; }
        public int StoreID { get; set; }

        public string ProductName { get; set; }
        public float Num { get; set; }
        public string UnitName { get; set; }
        public float Price { get; set; }
        public float ChangeNum { get; set; }
        public float Stock { get; set; }
        public int InvoiceID { get; set; }
        public float NetPrice { get; set; }
        public DateTime DateSubmit { get; set; }



    }



}
