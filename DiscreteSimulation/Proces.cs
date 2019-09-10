using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public abstract class Proces
    {
        public string ID; //název obchodu / id cestujícího
        protected Model model;
        public abstract void Zpracuj(Udalost udalost);

        //Vytvoření krátkého výpisu, který je defaultně vypsán po stisku tlačítka Výsledek
        public string Vypis(string zprava)
        {
            return String.Format("{0}:{1}  Cestující {2}: {3}", model.CasSimulace1.Hour,model.CasSimulace1.Minute, ID, zprava); //změnil jsi formát dat!!
        }

        // Vytvoření dlouhého výpisu, který je následně uložen v bufferu pro dlouhý výpis na vyžádání ve stavu Výsledek
        public string VypisDlouhy(string zprava)
        {
            return String.Format("Čas: {0}:{1} / Čas simulace: {2}  Cestující {3}: {4}", model.CasSimulace1.Hour, model.CasSimulace1.Minute,model.CasSimulace, ID, zprava); 
        }

    }
}
