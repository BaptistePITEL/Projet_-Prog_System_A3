using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    class Serveur : Personnel
    {
        public Carre carre;

        public Serveur(Carre carre, string nom ) : base(nom)
        {
            this.carre = carre;
        }


        public override void log(string log)
        {
            throw new NotImplementedException();
        }

        public override void tick()
        {
            throw new NotImplementedException();
        }
    }
}
