using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class NastaveniObsluhy
    {
        //Třída pro nastavení statických atributů rychlostí obsluh pomocí TrackBarů aby šli snadno předávat
        //Nastavení počtu cestujících
        //ZBAVIT SE STATIKY!! 
        public static int rychlostBufetu;
        public static int rychlostButiku;
        public static int rychlostOdbaveni;
        public static int rychlostPasCtrl;
        public static int rychlostBzpCtrl;
        public static int rychlostNalodeni;

        public static int pctNavstevnikuBufetu;
        public static int pctNavstevnikuButiku;
        public int nastavObsluhu(int nastaveni)
        {
            return nastaveni;
        }
    }
}
