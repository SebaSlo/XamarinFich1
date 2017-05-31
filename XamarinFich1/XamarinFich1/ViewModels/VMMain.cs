using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinFich1.Helpers;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMMain : VMBase
    {
        #region Comandos
        //propiedades autoimplementadas
        
        #endregion

        #region Atributos

        #endregion

        public VMMain(INavegable nav)
        {
            Title = "C Sharp Curso FICH";
            Navigator = nav;
            //Comanders
            NavigateCommand = new Command<string>(GoToPage, null);
        }

        #region Methods
        public void GoToPage(string page)
        {
            Navigator.GoToPage(page);
        }

        #endregion

    }
}
