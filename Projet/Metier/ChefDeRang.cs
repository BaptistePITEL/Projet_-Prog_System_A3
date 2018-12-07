using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class ChefDeRang
    {
        public Carre carre;
        public Table table;

        public ChefDeRang(Carre carre)
        {
            this.carre = carre;
        }

        public bool verifierTable(GroupeClient gC)
        {
            foreach(Rang r in carre.rangs)
            {
                foreach(Table t in r.tables)
                {
                    if(t.grclient == null)
                    {
                        this.table = t;
                        t.grclient = gC;
                        
                        return true;
                    }
                }
            }
            return false;
            

        }
    }
}
