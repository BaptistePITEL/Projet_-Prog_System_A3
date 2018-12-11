using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Salle;

namespace Metier.Factory
{
    public class FabriqueGroupeClient
    {

        public static GroupeClient create()
        {
            Random r = new Random();
            int tailleGroupe = 3
                /*r.Next(2,10)*/;



            GroupeClient gC = new GroupeClient();
            
            FabriqueClient fC = new FabriqueClient();

            for (int i = 0; i < tailleGroupe; i++)
            {
                Client clt = fC.create(gC);
                gC.clients.Add(clt);
            }

            return gC;
        }
    }
}
