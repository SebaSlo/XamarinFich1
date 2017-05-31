using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMXamarin:VMBase
    {
        public VMXamarin(INavegable nav)
        {
            Title = "Aprende Xamarin Forms";
            Navigator = nav;
        }
    }
}
