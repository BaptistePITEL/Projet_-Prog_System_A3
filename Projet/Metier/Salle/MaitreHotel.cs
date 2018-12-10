using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    public class MaitreHotel : Personnel
    {
        public Restaurant resto;

        public MaitreHotel(Restaurant resto, string nom) : base(nom)
        {
            this.resto = resto;
        }

        public override Restaurant getRestaurant()
        {
            return resto;
        }

        public override void tick()
        {
            int quitter = 0;
            foreach( GroupeClient gC in resto.listAttente)
            {   
                foreach (Carre c in resto.carres)
                {
                   if( c.chefDeRang.isDispo())
                    {
                        c.chefDeRang.gC = gC;
                        resto.listAttente.Remove(gC);
                        quitter = 1;
                        break;
                    }
                   else
                    {
                        log("Chef de rang du carré " + resto.carres.IndexOf(c) + " indisponible");
                    }
                }
                if (quitter == 1)
                {
                    break;
                }
                else
                {
                    log("Pas de place dans le restaurant");
                }          
            }
        }
    }
}
