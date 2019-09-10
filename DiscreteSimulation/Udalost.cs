using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteSimulation
{
    public class Udalost
    {
        public int kdy; // čas události
        public Proces kdo; //entita
        public TypUdalosti co; //fáze procesu
        public Udalost(int kdy, Proces kdo, TypUdalosti co)
        {
            this.kdy = kdy;
            this.kdo = kdo;
            this.co = co;
        }
    }
}
