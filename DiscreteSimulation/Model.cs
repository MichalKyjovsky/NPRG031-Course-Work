using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class Model
    {
        GeneratorCestujicich generatorCestujicich = new GeneratorCestujicich();
        private const int pctVsechCestujicich = 189;

        private string[] stanoviste = { "Bezpečnostní kontrola", "Pasová kontrola", "Nalodění", "Toaleta", "Odbavení", "Bufet", "Butik" };
        int[] cestujici = new int[189];
        public bool[] sKufrem = new bool[189];
        public bool[] toaleta = new bool[189];
        public string[] obchody = new string[189];
        public int CasSimulace;
        public DateTime CasSimulace1;
        //public int hh; 
        public List<Zastavky> VsechnyZastavky = new List<Zastavky>();
        //private NastaveniObsluhy nastaveniObsluhy = new NastaveniObsluhy();
        private Kalendar kalendar;

        public void Naplanuj(int kdy, Proces kdo, TypUdalosti co)
        {
            kalendar.Pridej(kdy, kdo, co);
        }

        public void Odplanuj(Proces kdo, TypUdalosti co)
        {
            kalendar.Odeber(kdo, co);
        }

        public void VytvorProcesy()
        {
            //nacteni vstupnich dat
            cestujici = generatorCestujicich.VytvorID();
            sKufrem = generatorCestujicich.PriradKufry();
            toaleta = generatorCestujicich.ChciNaToaletu();
            obchody = generatorCestujicich.Obchody(NastaveniObsluhy.pctNavstevnikuBufetu, NastaveniObsluhy.pctNavstevnikuButiku);


            for (int i = 0; i < stanoviste.Length; i++)
            {
                new Zastavky(this, stanoviste[i]);
            }

            for (int i = 0; i < pctVsechCestujicich; i++)
            {
                new Cestujici(this, cestujici[i], sKufrem[i], toaleta[i], obchody[i]);
            }

        }

        public void Vypocet()
        {
            CasSimulace = 0;
            CasSimulace1 = new DateTime(); 
            CasSimulace1 = CasSimulace1.AddHours(NastaveniCasu.cas);
            
            kalendar = new Kalendar();
            VytvorProcesy();

            Udalost udalost;

            while ((udalost = kalendar.Vyber()) != null)
            {
                CasSimulace = udalost.kdy;
                CasSimulace1 = CasSimulace1.AddMilliseconds(CasSimulace);

                udalost.kdo.Zpracuj(udalost);
            }
            
        }
    }
}

