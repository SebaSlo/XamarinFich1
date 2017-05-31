using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.ViewModels;

namespace XamarinFich1.Services
{
    /*
     * Servicio de navegacion:
     * Brinda una interfaz para ir de una ventana a otra dentro de una app
     * La ventana puede ser cualquier cosa, dependiendo de la implementacion.
     * Cada método recibe la view model a la cual se quiere navegar.
     * Esto obliga a pensar en mnejo de ViewModels y no de Views y, además, logra 
     * una separación de capas muy robusta.
     */
    public interface INavegable
    {
        void GoToPage(string page);
        void GoToModalpage(string page);
        void GoBack(string page);
    }
}
