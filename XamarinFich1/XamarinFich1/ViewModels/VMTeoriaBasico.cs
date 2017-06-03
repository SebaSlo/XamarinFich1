using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    internal class VMTeoriaBasico:VMBase
    {
        public VMTeoriaBasico(INavegable navigationServiceOnXamarin)
        {
            Title = "Conceptos básicos de C#";
            Navigator = navigationServiceOnXamarin;
        }
    }
}