using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMWPF:VMBase
    {
        public VMWPF(INavegable nav)
        {
            Title = "Aprende sobre WPF.";
            Navigator = nav;
        }
    }
}
