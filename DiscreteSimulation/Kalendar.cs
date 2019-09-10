using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class Kalendar
    {
        private List<Udalost> seznam;

        public Kalendar()
        {
            seznam = new List<Udalost>();
        }

        //Přídá do kalendáře událost čekající na zpracování 
        public void Pridej(int kdy, Proces kdo, TypUdalosti co)
        {
            foreach (Udalost udalost in seznam)
            {
                if (udalost.kdo == kdo)
                {
                    Cestujici.dlouhyVypis.Add("\n");
                }
            }

            seznam.Add(new Udalost(kdy, kdo, co));
        }

        //Odebere shodný výskyt z kalendáře, pakliže byla událost již zpracvána
        public void Odeber(Proces kdo, TypUdalosti co)
        {
            foreach (Udalost udalost in seznam)
            {
                if ((udalost.kdo == kdo) && (udalost.co == co))
                {
                    seznam.Remove(udalost);
                    return;
                }
            }
        }

        //Vybere událost která je v simulaci první na řade podle atributu třídy událost --kdy
        private Udalost Prvni()
        {
            Udalost prvni = null;

            foreach (Udalost udalost in seznam)
            {
                if ((prvni == null) || (udalost.kdy < prvni.kdy))
                    prvni = udalost;
            }

            seznam.Remove(prvni);
            return prvni;
        }

        //Getter 
        public Udalost Vyber()
        {
            return Prvni();
        }
    }
}
