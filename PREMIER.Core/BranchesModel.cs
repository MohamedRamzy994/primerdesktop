using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class BranchesModel
    {

    }
    public class ListBranchesModel
    {
        public int BranchID { get; set; }
        public string Name { get; set; }
        public string DeviceIP { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }



    }
    public class AddBranchModel
    {
        public string Name { get; set; }
        public string DeviceIP { get; set; }
        public string Address { get; set; }

    }
}
