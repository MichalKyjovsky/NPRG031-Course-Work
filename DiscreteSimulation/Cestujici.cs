using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class Cestujici : Proces
    {
        private static Random random = new Random();
        // NastaveniCasu nastaveniCasu = new NastaveniCasu();
        //private GeneratorCestujicich generatorCestujicich = new GeneratorCestujicich();

        private static string[] vsechnyZastavky = { "Bezpečnostní kontrola", "Pasová kontrola", "Nalodění", "Toaleta", "Odbavení", "Bufet", "Butik" };
        public static List<string> dlouhyVypis = new List<string>();
        public static List<string> kratkyVypis = new List<string>();
        private int casDoOdletu;
        private int casPrichodu;

        private DateTime casDoOdletu1 = new DateTime();
        private DateTime casPrichodu1 = new DateTime(); 

        private bool sKufrem = false;
        private bool toaleta = false;
        private List<string> Zastavky;
        private bool stihlLetadlo;
        public static int uspesni = 0; 


        

        public Cestujici(Model model, int pass, bool kufr, bool toaleta, string obchody)
        {
            this.model = model;
            this.ID = pass.ToString();
            int pom1 = NastaveniCasu.casOdletu;
            int pom2 = NastaveniCasu.cas;
            this.stihlLetadlo = true; 

            this.casPrichodu = random.Next(pom2, pom1 - 2); // dolní hranice je čas příchodu prvního cestujícího, horní hranice cas do odletu -1
            this.casDoOdletu = pom1 - this.casPrichodu;


            this.casPrichodu1 = DateTime.Today;
            this.casPrichodu1 = casPrichodu1.AddHours(random.Next(pom2, pom1 - 2));
            this.casDoOdletu1 = DateTime.Today;
            this.casDoOdletu1 = casDoOdletu1.AddHours(pom1 - this.casPrichodu);

            this.sKufrem = kufr;
            this.toaleta = toaleta;
            string[] obchudky = obchody.Split(' ');

            Zastavky = new List<string>();

            if (this.sKufrem == true)
            {
                Zastavky.Add(vsechnyZastavky[4]);
            }

            for (int i = 0; i < 3; i++) // přidání jen povinných zastávek každého cestujícího
            {
                Zastavky.Add(vsechnyZastavky[i]);
            }

            if (this.toaleta == true)
            {
                Zastavky.Add(vsechnyZastavky[3]);
            }

            for (int i = 0; i < obchudky.Length; i++)
            {
                if (obchudky[i] != "")
                    Zastavky.Add(obchudky[i]);
            }

            model.Naplanuj(casPrichodu, this, TypUdalosti.Prichod);

        }
        public override void Zpracuj(Udalost udalost)
        {
            switch (udalost.co)
            {
                case TypUdalosti.Prichod:
                    if ((Zastavky.Count == 0) && stihlLetadlo)
                    {
                        dlouhyVypis.Add(VypisDlouhy("---------- Čeká na nalodění"));
                        kratkyVypis.Add(Vypis("---------- Čeká na nalodění"));
                        uspesni++;
                    }
                    else
                    {
                        Zastavky zastavky = ZastavkaKamChci(Zastavky[0]);
                        if ((Zastavky.Count > 1) && stihlLetadlo)
                            model.Naplanuj(model.CasSimulace + casDoOdletu, this, TypUdalosti.Cas);
                        
                        zastavky.ZaradDoFronty(this);
                    }
                    break;
                case TypUdalosti.Odbaven:
                    dlouhyVypis.Add(VypisDlouhy("Vyřízeno: " + Zastavky[0]));
                    Zastavky.RemoveAt(0); // bude se řešit další zastávka -> typ udalosti START
                    model.Naplanuj(model.CasSimulace, this, TypUdalosti.Prichod);
                    break;
                case TypUdalosti.Cas:
                    {
                        Zastavky zas = ZastavkaKamChci(Zastavky[0]);
                        zas.VyradZFronty(this);
                    }
                    //Stihnu letadlo?
                   if((NastaveniCasu.casOdletu1.Hour < model.CasSimulace1.Hour) && (Zastavky.Count > 0))
                    {
                        while(Zastavky.Count > 0)
                        {
                            Zastavky.RemoveAt(0);
                        }
                        this.stihlLetadlo = false; 
                        dlouhyVypis.Add(VypisDlouhy("----------- NESTIHL SVÉ LETADLO"));
                        kratkyVypis.Add(Vypis("----------- NESTIHL SVÉ LETADLO"));
                        break; 
                    }
                   //Přehození pořadí zastávek, aby např. nalodění neproběhlo před bzp.kontrolou
                    string nesplneny = Zastavky[0];
                    Zastavky.RemoveAt(0);
                    Zastavky.Add(nesplneny);

                    if ((Zastavky[0] == "Pasová kontrola"))
                    {
                        nesplneny = Zastavky[0];
                        Zastavky.RemoveAt(0);
                        Zastavky.Add(nesplneny);
                    }

                    if ((Zastavky[0] == "Nalodění"))
                    {
                        nesplneny = Zastavky[0];
                        Zastavky.RemoveAt(0);
                        Zastavky.Add(nesplneny);
                    }

                    model.Naplanuj(model.CasSimulace, this, TypUdalosti.Prichod);
                    break;
            }
        }
        //Vyber zastavku se seznamu
        private Zastavky ZastavkaKamChci(string kamChci)
        {
            foreach (Zastavky zas in model.VsechnyZastavky)
            {
                if (zas.ID == kamChci)
                    return zas;
            }
            return null;
        }
    }
}
