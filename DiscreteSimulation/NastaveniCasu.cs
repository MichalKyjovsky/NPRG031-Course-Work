using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class NastaveniCasu
    {
        //Reálně časy cestujících při výpisu 
        public static DateTime cas1 = new DateTime();
        public static DateTime casOdletu1 = new DateTime();

        //Časy simulace --výpočet
        public static int cas;
        public static int casOdletu;

        //Nastav statiku a vrať
        public int NastavCas(int vstup)
        {
            cas = vstup;
            return vstup;
        }

        public int NastavOdlet(int vstup)
        {
            casOdletu = vstup;
            return vstup;
        }

        public DateTime NastavOdlet(DateTime vstup)
        {
            casOdletu1 = vstup;
            return vstup;
        }
    }
}
