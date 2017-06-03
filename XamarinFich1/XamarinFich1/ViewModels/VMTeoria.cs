using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.Helpers;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMTeoria : VMBase
    {
        private string texto;

        public string Texto
        {
            get { return texto; }
            set { SetProperty(ref texto, value); }
        }

        public VMTeoria(INavegable nav)
        {
            Title = "Teoría";
            Navigator = nav;

            NavigateCommand = new Command<string>((s)=> { Navigator.GoToPage(s); },null);
        }
    }
}
