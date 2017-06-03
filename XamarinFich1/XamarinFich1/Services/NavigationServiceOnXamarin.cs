using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFich1;
using XamarinFich1.ViewModels;

namespace XamarinFich1.Services
{
    class NavigationServiceOnXamarin : INavegable
    {
        public void GoBack(string page)
        {
            throw new NotImplementedException();
        }

        public void GoToModalpage(string page)
        {
            throw new NotImplementedException();
        }

        public void GoToPage(string page)
        {
            switch (page)
            {
                case "Teoría C#":
                    {
                        App.NavigationService.PushAsync(new Views.VTeoria() {
                            BindingContext = new VMTeoria(new NavigationServiceOnXamarin())});
                        break;
                    }
                case "Ejemplos":
                    {
                        App.NavigationService.PushAsync(new Views.VEjemplos()
                        {
                            BindingContext = new VMEjemplo(new NavigationServiceOnXamarin())
                        });
                        break;
                    }
                case "Ejercicios":
                    {
                        var Npage = new Views.VEjercicios();
                        Npage.BindingContext = new VMExercise(new NavigationServiceOnXamarin());
                        App.NavigationService.PushAsync(Npage);
                        break;
                    }
                case "WPF":
                    {
                        App.NavigationService.PushAsync(new Views.VWPF()
                        {
                            BindingContext = new VMWPF(new NavigationServiceOnXamarin())
                        });
                        break;
                    }
                case "Xamarin":
                    {
                        App.NavigationService.PushAsync(new Views.VXamarin()
                        {
                            BindingContext = new VMXamarin(new NavigationServiceOnXamarin())
                        });
                        break;
                    }
                //Ejemplos
                case "Calculadora":
                    {
                        App.NavigationService.PushAsync(new Views.VCalculadora()
                        {
                            BindingContext = new VMCalculadora(new NavigationServiceOnXamarin())
                        });
                        break;
                    }
                case "Basicos de C#":
                    {
                        App.NavigationService.PushAsync(new Views.VTeoriaBasico()
                        {
                            BindingContext = new ViewModels.VMTeoriaBasico(new NavigationServiceOnXamarin())
                        });
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
