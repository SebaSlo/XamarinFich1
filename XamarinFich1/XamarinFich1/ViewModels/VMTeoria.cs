using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMTeoria:VMBase
    {
        public VMTeoria(INavegable nav)
        {
            Title = "Teoría";
            Navigator = nav;
        }
    }
}
