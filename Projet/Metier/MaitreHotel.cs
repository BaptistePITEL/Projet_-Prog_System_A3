using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class MaitreHotel : Personnel
    {
        public Restaurant resto;

        public MaitreHotel(string nom) : base(nom)
        {
        }
        


        public override void log(string log)
        {
            throw new NotImplementedException();
        }

        public override void tick()
        {
            int quitter = 0;
            foreach( GroupeClient gC in resto.listAttente)
            {   
                foreach (Carre c in resto.carres)
                {
                   if( c.chefDeRang.verifierTable(gC))
                    {
                        gC.table = c.chefDeRang.table;
                        resto.listAttente.Remove(gC);
                        quitter = 1;
                        break;
                    }
                }
                if (quitter == 1)
                    break;
            
               
            }
        }
    }
}
