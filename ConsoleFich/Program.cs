using ConsoleFich.View;
using System;

namespace ConsoleFich
{
    class Program
    {
        static void Main(string[] args)
        {
            VMain mainApp = new VMain(new XamarinFich1.ViewModels.VMMain(null)
            {
                Title = "Aplicacion de consola. Curso C# FICH"
            });

            mainApp.AppConsoleRun();

        }
    }
}