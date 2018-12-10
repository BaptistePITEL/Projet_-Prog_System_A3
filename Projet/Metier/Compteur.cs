using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Compteur
    {
        public int compteur;

        public Compteur()
        {
            compteur = 0;
        }

        public void CompteurIncremente()
        {
            compteur += 1;
        }

        public void reset()
        {
            compteur = 0;
        }

    }
}
