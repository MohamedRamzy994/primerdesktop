using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class SettingsModel
    {
        
        public string ShopName { get; set; }
        public string WorkType { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }
        public string Address { get; set; }

    }
    public class SettingsThemesModel
    {

        public string ThemName { get; set; }
        public string ThemUrl { get; set; }
        public int ThemID { get; set; }
        public bool ThemSelected{ get; set; }

    }
}
