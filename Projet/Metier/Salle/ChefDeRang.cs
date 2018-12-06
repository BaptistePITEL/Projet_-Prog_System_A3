using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class ChefDeRang : Personnel
    {
        public Carre carre;
        public GroupeClient gC;
        public Table table;

        public ChefDeRang(Carre carre, string nom) : base(nom) 
        {
            this.carre = carre;
        }

        public override void log(string log)
        {
            Console.WriteLine(log);
        }

        public override void tick()
        {
            if(!this.table.ontCarte)
            {
                attribuerCarte();
            }
            else if (this.gC != null)
            {
                attribuerTable();
            }
        }

        public bool isDispo()
        {
            if (gC != null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Méthode du tick
        /// </summary>

        public void attribuerTable()
        {
            int quitter = 0;
            foreach (Rang r in carre.rangs)
            {
                foreach (Table t in r.tables)
                {
                    if (t.grclient == null)
                    {
                        this.gC.table = t;
                        this.table = t;
                        t.grclient = gC;
                        this.gC = null;
                        quitter = 1;
                    }
                }
                if (quitter == 0)
                {
                    log("Aucune table de disponible dans ce carré" + carre.id);
                }
            }
        }

        public void attribuerCarte()
        {
            int quitter = 0;
            foreach (Rang r in carre.rangs)
            {
                foreach (Table t in r.tables)
                {
                    if (t.Equals(this.table))
                    {
                        t.ontCarte = true;
                        quitter = 1;
                        break;
                    }
                   
                }
                if(quitter == 1)
                {
                    break;
                }

            }
        }


        /*       public bool verifierTable(GroupeClient gC)
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
        }*/



    }
}
