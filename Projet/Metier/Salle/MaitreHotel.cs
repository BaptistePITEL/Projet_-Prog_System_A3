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
        public int statMaitreHotel = 0;

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
            if(resto.listAttente.Count != 0)
            {
                statMaitreHotel += 1;
            }
            foreach( GroupeClient gC in resto.listAttente)
            {   
                foreach (Carre c in resto.carres)
                {
                   if( c.chefDeRang.isDispo())
                    {
                        c.chefDeRang.gC = gC;
                        resto.listAttente.Remove(gC);
                        quitter = 1;
                        log("Le " + c.chefDeRang.nom + " est disponible, le groupe de clients a été attribué");
                        break;
                    }
                   else
                    {
                        log("Le chef de rang du carré [" + resto.carres.IndexOf(c) + "] est indisponible");
                    }
                }
                if (quitter == 1)
                {
                    break;
                }
                else
                {
                    log("Il n'y a pas de place dans le restaurant");
                }          
            }
        }
    }
}
