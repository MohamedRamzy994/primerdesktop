using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class ProductOpenningBalanceModel
    {
        public int InvoiceID { get; set; }
        public int StoreID { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public bool Existing { get; set; }
        public List<ProductOpenningBalanceItemsModel> InvoiceItems { get; set; }


    }
    public class ProductOpenningCancleInvoiceModel
    {
        public int InvoiceID { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }


    }

    public class ProductOpenningBalanceItemsModel
    {
        public int ProductID { get; set; }
        public float Num { get; set; }
        public int UnitID { get; set; }
        public decimal ChangeNum { get; set; }
        public int StoreID { get; set; }


    }

    public class ListProductOpenningBalanceModel
    {

        public int InvoiceID { get; set; }
        public string StoreName { get; set; }
        public string UserName { get; set; }
        public DateTime DateSubmit { get; set; }
        public bool Existing { get; set; }




    }

    public class ListProductOpenningBalanceInvoiceItemsModel
    {



        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public float Num { get; set; }
        public string UnitName { get; set; }
        public decimal ChangeNum { get; set; }
        public float Stock { get; set; }





    }



}
