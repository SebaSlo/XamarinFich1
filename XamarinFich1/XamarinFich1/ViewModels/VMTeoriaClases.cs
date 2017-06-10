using System.Collections.ObjectModel;
using XamarinFich1.Models.Text;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMTeoriaClases : VMBase
    {
        private ObservableCollection<DataText> documento;
        public ObservableCollection<DataText> Documento { get { return documento; } set { SetProperty(ref documento, value); } }

        public VMTeoriaClases(INavegable nav)
        {
            Title = "Las clases de C#";
            //ver navegacion
            Navigator = nav;
            #region SampleData
            Documento = new ObservableCollection<DataText>();

            //Agrego el título
            Documento.Add(
                new DataText()
                {
                    Text = "Titulo uno" ,
                    Type = TextType.Title
                }
                );
            //Agrego un texto plano
            Documento.Add(
                new DataText()
                {
                    Text =  "Lorem Ipsum naluirhng liuahknaui vlawnvlawu fnvalwuernloiunw afil aneig baiuwelf Lorem Ipsum naluirhng liuahknaui vlawnvlawu fnvalwuernloiunw afil aneig baiuwelf Lorem Ipsum naluirhng liuahknaui vlawnvlawu fnvalwuernloiunw afil aneig baiuwelf Lorem Ipsum naluirhng liuahknaui vlawnvlawu fnvalwuernloiunw afil aneig baiuwelf Lorem Ipsum naluirhng liuahknaui vlawnvlawu fnvalwuernloiunw afil aneig baiuwelf " ,
                    Type = TextType.PlainText
                }
                );
            //Agrego lineas de código
            Documento.Add(
                new DataText()
                {
                    Text ="line code 1\nline code 2\nline code 3\nline code 4\nline code 5",
                    Type = TextType.Code
                }
                );
            #endregion
        }
    }
}
