using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class GeneratorCestujicich
    {
        //Vytvoří všechny ID cestujících na palubě 
        public static int[] cestujiciID = new int[189];
        public static int pasazeriKufr;
        private static readonly bool[] SKufrem = new bool[189];
        private static bool[] Toaleta = new bool[189];
        private static string[] obchody = new string[189];

        //Zamíchá pasažéry 
        public int[] VytvorID()
        {
            Random random = new Random();

            for (int i = 0; i < cestujiciID.Length; i++)
            {
                cestujiciID[i] = i + 1;
            }

            cestujiciID = cestujiciID.OrderBy(x => random.Next()).ToArray();

            return cestujiciID;
        }

        //Vrátí nastavený počet pasažérů
        public int PctPasazeru(int pocet)
        {
            return pocet;
        }

        //Vrátí nastavený počet pasažérů se zavazadlem
        public int PctPasazeruSKufrem(int pocet)
        {
            pasazeriKufr = pocet;
            return pocet;
        }

        //Cestující jsou již "zamícháni", většinou chodí první ti co mají zavazadlo na 15Kg
        public bool[] PriradKufry()
        {
            for (int i = 0; i < pasazeriKufr; i++)
            {
                SKufrem[i] = true; //Vymyslet lepší rozřazení zavazadel
            }

            return SKufrem;
        }

        //Cestující chodí na toaletu náhodně
        public bool[] ChciNaToaletu()
        {
            Random random = new Random();
            for (int i = 0; i < Toaleta.Length; i++)
            {
                Toaleta[i] = random.Next(100) >= 50 ? true : false;
            }
            return Toaleta;
        }

        public string[] Obchody(int navstevniciBufetu, int navstevniciButiku)
        {
            //NastaveniObsluhy nastaveniObsluhy = new NastaveniObsluhy();
            Random random = new Random();
            bool[] navstevniciEt = new bool[189];
            bool[] navstevniciIk = new bool[189];

            for (int i = 0; i < NastaveniObsluhy.pctNavstevnikuBufetu; i++)
            {
                navstevniciEt[i] = true;
            }

            for (int i = 0; i < NastaveniObsluhy.pctNavstevnikuButiku; i++)
            {
                navstevniciIk[i] = true;
            }

            navstevniciEt = navstevniciEt.OrderBy(x => random.Next()).ToArray();
            navstevniciIk = navstevniciIk.OrderBy(x => random.Next()).ToArray();

            for (int i = 0; i < obchody.Length; i++)
            {
                if ((navstevniciEt[i] == true) && (navstevniciIk[i] == true))
                    obchody[i] = "Bufet Butik";
                else if ((navstevniciEt[i] == true) && (navstevniciIk[i] == false))
                    obchody[i] = "Bufet";
                else if ((navstevniciEt[i] == false) && (navstevniciIk[i] == true))
                    obchody[i] = "Butik";
                else
                    obchody[i] = "";
            }
            return obchody;
        }
    }
}
