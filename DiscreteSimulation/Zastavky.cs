using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class Zastavky : Proces
    {
        public int rychlostObsluhy;
        private List<Cestujici> fronta;
        private bool obsluhuje;
        public Zastavky(Model model, string popis)
        {
            this.model = model;
            //NastaveniObsluhy nastaveniObsluhy = new NastaveniObsluhy();
            obsluhuje = false;
            //Nastavení ID
            switch (popis)
            {
                case "Odbavení":
                    this.rychlostObsluhy = NastaveniObsluhy.rychlostOdbaveni;
                    this.ID = "Odbavení";
                    break;
                case "Bezpečnostní kontrola":
                    this.rychlostObsluhy = NastaveniObsluhy.rychlostBzpCtrl;
                    this.ID = "Bezpečnostní kontrola";
                    break;
                case "Pasová kontrola":
                    this.rychlostObsluhy = NastaveniObsluhy.rychlostPasCtrl;
                    this.ID = "Pasová kontrola";
                    break;
                case "Bufet":
                    this.rychlostObsluhy = NastaveniObsluhy.rychlostBufetu;
                    this.ID = "Bufet";
                    break;
                case "Butik":
                    this.rychlostObsluhy = NastaveniObsluhy.rychlostButiku;
                    this.ID = "Butik";
                    break;
                case "Nalodění":
                    this.rychlostObsluhy = NastaveniObsluhy.rychlostNalodeni;
                    this.ID = "Nalodění";
                    break;
                case "Toaleta":
                    this.rychlostObsluhy = 1;
                    this.ID = "Toaleta";
                    break;
            }

            fronta = new List<Cestujici>();
            model.VsechnyZastavky.Add(this);
        }

        public void ZaradDoFronty(Cestujici cestujici)
        {
            fronta.Add(cestujici);
            Cestujici.dlouhyVypis.Add(VypisDlouhy("Cestující " + cestujici.ID + " ve frontě"));

            if (!obsluhuje)
            {
                obsluhuje = true;
                model.Naplanuj(model.CasSimulace, this, TypUdalosti.Prichod);
            }
        }

        public void VyradZFronty(Cestujici ktereho)
        {
            foreach (Cestujici cestujici in fronta)
            {
                if (cestujici == ktereho)
                {
                    fronta.Remove(cestujici);
                    return;
                }
            }
        }
        public override void Zpracuj(Udalost udalost)
        {
            switch (udalost.co)
            {
                case TypUdalosti.Prichod:
                    if (fronta.Count == 0)
                    {
                        obsluhuje = false;
                    }
                    else
                    {
                        Cestujici cestujici = fronta[0];
                        fronta.RemoveAt(0);
                        model.Odplanuj(cestujici, TypUdalosti.Cas);
                        model.Naplanuj(model.CasSimulace + rychlostObsluhy, cestujici, TypUdalosti.Odbaven);
                        model.Naplanuj(model.CasSimulace + rychlostObsluhy, this, TypUdalosti.Prichod);
                    }
                    break;
            }
        }
    }
}
