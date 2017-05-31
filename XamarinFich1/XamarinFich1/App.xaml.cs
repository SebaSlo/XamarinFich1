using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinFich1
{
    public partial class App : Application
    {
        //Expongo el servicio de navegacion de la app para poder navegar entre páginas.
        public static INavigation NavigationService;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.VMain());
            NavigationService = MainPage.Navigation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
