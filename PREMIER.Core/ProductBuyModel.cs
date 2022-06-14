using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
   public class ProductBuyModel
    {





    }

    public class ProductBuyMainTableModel
    {

        public int InvoiceID { get; set; }


        public int StoreID { get; set; }
        public int SupplierID { get; set; }

        public string InvoiceNum { get; set; }

        public int UserID { get; set; }

        public DateTime DateSubmit { get; set; }

        public float Total { get; set; }

        public int PayID { get; set; }

        public float PayedMoney { get; set; }
        public float DiscountCash { get; set; }


        
        public int SalesPointID { get; set; }


        



        public bool Existing { get; set; }

        public List<ProductBuyTableModel> SelectedProducts { get; set; }


        
                   


    }
    public class ProductBuyTableModel
    {
        public int InvoiceID { get; set; }

        public int ProductID { get; set; }
        public float Num { get; set; }

        public int UnitID { get; set; }

        public float ChangeNum { get; set; }
        public float Price { get; set; }
        public float DiscardNum { get; set; }
        public bool Update_B_Pric { get; set; }


        



    }
    public class ProductBuySelectMainInvoices
    {

        public int InvoiceID { get; set; }
        public string SupplierName { get; set; }

        public string InvoiceNum { get; set; }

        public string StoreName { get; set; }
        public DateTime DateSubmit { get; set; }

        public string UserName { get; set; }
        public float Total { get; set; }
        public bool Existing { get; set; }







    }

    public class ProductBuyInvoiceItems
    {


        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float Num { get; set; }
        public string UnitName { get; set; }
        public float Price { get; set; }
        public float Stock { get; set; }
        public float ChangeNum { get; set; }
        public float DiscardNum { get; set; }





    }

    public class ProductBuyDiscardMainModel
    {
        public int InvoiceID { get; set; }
        public float DiscardValue { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int DefaultSalesPointID { get; set; }
        public int StoreID { get; set; }
        public List<ProductBuyDiscardMainItemsModel> DiscardMainItems { get; set; }

    }


    public class ProductBuyDiscardMainItemsModel
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
        
    }

    public class ProductBuyDiscardMainNotSpecifiedModel
    {
        public int SupplierID { get; set; }
        public float Total { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int DefaultSalesPointID { get; set; }
        public int StoreID { get; set; }
        public List<ProductBuyDiscardMainNotSpecifiedItemsModel> DiscardMainItems { get; set; }

    }

    public class ProductBuyDiscardMainNotSpecifiedItemsModel
    {
        public int DiscardID { get; set; }
        public int ProductID { get; set; }

        public float Num { get; set; }
        public int UnitID { get; set; }
        public float Price { get; set; }
   
        public int StoreID { get; set; }
     
        public float ChangeNum { get; set; }

    }

    public class ProductBuyDiscardSelectMainInvoices
    {

        public int DiscardID { get; set; }
        public string SupplierName { get; set; }

        public string InvoiceNum { get; set; }

        public string StoreName { get; set; }
        public DateTime DateSubmit { get; set; }

        public string UserName { get; set; }
        public float DiscardValue { get; set; }
        public bool Existing { get; set; }







    }

    public class ProductBuyDiscardSelectMainInvoicesItems
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
          
        public float Num { get; set; }
        public string UnitName { get; set; }
        public float Price { get; set; }
        public float ChangeNum { get; set; }
        public bool Stock { get; set; }
                   
    }

}
