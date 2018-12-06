using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Materiel
    {
        public string nom;
        public int id;
        public int quantiteMax;

        public Materiel(string nom, int id, int quantiteMax)
        {
            this.nom = nom;
            this.id = id;
            this.quantiteMax = quantiteMax;
        }
    }
}
