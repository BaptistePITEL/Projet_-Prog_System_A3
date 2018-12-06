using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class Personnel
    {
        private string nom;

        public Personnel(string nom)
        {
            this.nom = nom;
        }

        public abstract void log(string log);
        public abstract void tick();
    }
}
