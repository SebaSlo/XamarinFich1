using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFich1.ViewModels;

namespace XamarinFich1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VMain : ContentPage
    {
        public VMain()
        {
            InitializeComponent();
            BindingContext = new VMMain(new Services.NavigationServiceOnXamarin());
            /*
             BindingContext = new VMMain(new Services.NavigationServiceOnLinux());
             */
        }
    }  
}