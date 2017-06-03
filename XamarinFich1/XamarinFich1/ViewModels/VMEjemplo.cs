using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMEjemplo : VMBase
    {
        #region Propiedades
        private List<OptionExample> options;

        public List<OptionExample> Options
        {
            get { return options; }
            private set { options = value; }
        }
        #endregion

        private OptionExample selectedItem;

        /// <summary>
        /// Propiedad de seleccion de item de la view. Al seleccionar un item, se navga a la pagina correspondiente.
        /// </summary>
        public OptionExample SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
                if(selectedItem!=null) Navigator.GoToPage(selectedItem.Name) ;
                selectedItem = null;
            }
        }



        public VMEjemplo(INavegable nav)
        {
            Title = "Ejemplos de Código";
            Navigator = nav;            

            //creo las opciones que el usuario puede elegir
            Options = new List<OptionExample>()
            {
                new OptionExample(){Name="Calculadora", Description="Aprende a usar los conceptos básicos de C#"},
                new OptionExample(){Name="Agenda", Description="Aprende cómo se puede crear una agenda en C#"},
                new OptionExample(){Name="Zodiaco", Description="Aprende a taer datos de internet con C#"},
                new OptionExample(){Name="No me acuerdo", Description="Acá vas a aprender cómo hacer un chichumeque"}
            };
        }
    }

    public class OptionExample
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
