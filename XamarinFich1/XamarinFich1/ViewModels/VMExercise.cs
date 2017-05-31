using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMExercise:VMBase
    {
        public VMExercise(INavegable nav)
        {
            Title = "Ejercicios para resolver.";
            Navigator = nav;
        }
    }
}
