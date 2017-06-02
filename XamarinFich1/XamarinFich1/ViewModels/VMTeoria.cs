using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.Services;

namespace XamarinFich1.ViewModels
{
    public class VMTeoria : VMBase
    {
        private string texto;

        public string Texto
        {
            get { return texto; }
            set { SetProperty(ref texto, value); }
        }

        public VMTeoria(INavegable nav)
        {
            Title = "Teoría";
            Navigator = nav;

            Texto = "   Mr. Sherlock Holmes, who was usually very late in the mornings, save upon those not infrequent occasions when he was up all night, was seated at the breakfast table. I stood upon the hearth-rug and picked up the stick which our visitor had left behind him the night before. It was a fine, thick piece of wood, bulbous-headed, of the sort which is known as a \u201CPenang lawyer.\u201D Just under the head was a broad silver band, nearly an " + "inch across, \u201CTo James Mortimer, M.R.C.S., " + "from his friends of the C.C.H.,\u201D was engraved " + "upon it, with the date \u201C1884.\u201D It was " + "just such a stick as the old-fashioned family practitioner used to carry\u2014dignified, solid, " + "and reassuring.";
        }
    }
}
