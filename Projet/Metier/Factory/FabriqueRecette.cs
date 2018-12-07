using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Factory
{
    class FabriqueRecette
    {
        public FabriqueRecette create(int type)
        {
            Random r = new Random();
            int tailleGroupe = r.Next(1, 10);

            if (type == 1)
            {
                if( i == 1)
                {

                }
                else if (i == 2)
                {
                    return new Client(groupeClient, "Maria Garcia");
                }
                else if (i == 3)
                {
                    return new Client(groupeClient, "Clay Robinson");
                }
                else if (i == 4)
                {
                    return new Client(groupeClient, "Chris Brantley");
                }

            }
            

            GroupeClient gC = new GroupeClient();

            FabriqueClient fC = new FabriqueClient();

            for (int i = 1; i < tailleGroupe; i++)
            {
                Client clt = fC.create(gC);
                gC.clients.Add(clt);
            }

            return gC;
        }
    }
}
