using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class NotificationsActivitiesModel
    {
    }
    public class AddActivityModel
    {
        public int UserID { get; set; }
        public int POS { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Type { get; set; }
        public bool Read { get; set; }


    }
    public class AddNotificationModel
    {
        public int ProductID { get; set; }
        public int StoreID { get; set; }
        public DateTime DateSubmit { get; set; }
        public bool Read { get; set; }


    }
    public class AddSalesPointsNotificationModel
    {
        public int POS { get; set; }
        public DateTime DateSubmit { get; set; }
        public bool Read { get; set; }


    }
    public class ListAllActivitiesRecordsModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int POS { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Type { get; set; }
        public bool Read { get; set; }


    }
    public class ListAllNotificationRecordsModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int StoreID { get; set; }
        public DateTime DateSubmit { get; set; }
        public bool Read { get; set; }


    }
    public class ListAllSalesPointsNotificationRecordsModel
    {
        public int ID { get; set; }
        public int POS { get; set; }
        public DateTime DateSubmit { get; set; }
        public bool Read { get; set; }


    }
}
