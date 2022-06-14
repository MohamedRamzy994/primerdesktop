using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class ProductResestStockModel
    {
    }

    public class ProductResetStockReasonModel
    {

        public int ReasonID { get; set; }
        public string Reason { get; set; }



    }

    public class ProductResetStockAddMainModel
    {
        public int InvoiceID { get; set; }
        public int StoreID { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public List<ProductResetStockAddMainItemsModel> InvoiceItems { get; set; }


    }
    public class ProductResetStockAddMainItemsModel
    {
        public int ProductID { get; set; }
        public float Num { get; set; }
        public int UnitID { get; set; }
        public decimal ChangeNum { get; set; }
        public int StoreID { get; set; }
        public int ReasonID { get; set; }



    }


    public class ListProductResetStockeModel
    {

        public int InvoiceID { get; set; }
        public string StoreName { get; set; }
        public string UserName { get; set; }
        public DateTime DateSubmit { get; set; }




    }
    public class ListProductResetStockItemseModel
    {

        public int InvoiceID { get; set; }
        public string StoreName { get; set; }
        public string UserName { get; set; }
        public DateTime DateSubmit { get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public float Num { get; set; }
        public string UnitName { get; set; }
        public string Reason { get; set; }

        public decimal ChangeNum { get; set; }
        public float Stock { get; set; }







    }


}
