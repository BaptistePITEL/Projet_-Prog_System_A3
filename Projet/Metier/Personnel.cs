using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class Personnel
    {
        public string nom;

        public Personnel(string nom)
        {
            this.nom = nom;
        }

        public void log(string log)
        {
            Console.WriteLine("[" + nom + "](" + getRestaurant().nbTick + ") " + log + "\n");
        }

        public abstract Restaurant getRestaurant();

        public abstract void tick();
    }
}
