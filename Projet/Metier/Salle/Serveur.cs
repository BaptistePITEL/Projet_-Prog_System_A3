using Metier.Cuisine;
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
        public Restaurant restaurant;

        public Serveur(Carre carre, Restaurant r, string nom ) : base(nom)
        {
            this.carre = carre;
            this.restaurant = r;
        }

        public void ServirPlat()
        {
            int quitter = 0;
            foreach(Recette r in restaurant.recettesAServir)
            {
                foreach(Rang rang in this.carre.rangs){
                    if (rang.tables.Contains(r.table))
                    {
                        int i = restaurant.recettesAServir.IndexOf(r);
                        restaurant.recettesAServir.RemoveAt(i);
                        //GERER ARRIVAGE A LA TABLE
                        quitter = 1;
                        break;
                    }
                }
                if (quitter == 1)
                {
                    break;
                }
            }
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
