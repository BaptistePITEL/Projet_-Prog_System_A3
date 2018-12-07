using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace Metier.Salle
{
    public class ChefDeRang : Personnel
    {
        public Carre carre;
        public GroupeClient gC;
        public Table table;
        public List<Commande> commandes;
        public Queue<Table> tablesPretaCommander;


        public ChefDeRang(Carre carre, string nom) : base(nom)
        {
            this.carre = carre;
            commandes = new List<Commande>();
            tablesPretaCommander = new Queue<Table>();
        }

        public override void log(string log)
        {
            Console.WriteLine(log);
        }

        public override void tick()
        {
            foreach (Rang r in carre.rangs)
            {
                foreach (Table t in r.tables)
                {
                    if (t.enumEtatTable == EnumEtatTable.PRET_A_COMMANDE)
                    {
                        tablesPretaCommander.Enqueue(t);
                        t.enumEtatTable = EnumEtatTable.PRET_A_COMMANDE_ATTENTE;
                    }
                }

            }


            if (tablesPretaCommander.Count != 0)
            {
                prendreCommande(tablesPretaCommander.Dequeue());
            }
            else if (this.table != null)
            {
                    if (this.table.enumEtatTable == EnumEtatTable.INSTALLE)
                    {
                        attribuerCarte();
                  }
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

            log("Nombre de rangs : " + carre.rangs.Count + "\n");

            foreach (Rang r in carre.rangs)
            {
                int b = carre.rangs.IndexOf(r) + 1;
                log("--------    RANG " + b + " :   --------");
                log("Nombre de table dans le rang " + b + " : " + carre.rangs.Count + "\n");
                foreach (Table t in r.tables)
                {
                    int a = r.tables.IndexOf(t) + 1;
                    log("Table " + a + " : ");
                    log("Nombre de client : " + gC.clients.Count + " / Nombre de places : " + t.nbPlaces + "\n");
                    if (t.nbPlaces - gC.clients.Count == 0 || t.nbPlaces - gC.clients.Count == 1)
                    {
                        if (t.grclient == null)
                        {
                            this.gC.table = t;
                            this.table = t;
                            t.grclient = gC;
                            this.gC = null;
                            log("TABLE TROUVE \n");
                            quitter = 1;
                            break;
                        }
                    }

                }
                if (quitter == 1)
                {
                    break;
                }
            }
            if (quitter == 0)
            {
                log("Aucune table de disponible dans le carré " + carre.id);
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
                        t.enumEtatTable = EnumEtatTable.ONT_CARTE;
                        int a = r.tables.IndexOf(t) + 1;
                        int b = carre.rangs.IndexOf(r) + 1;
                        log("Carte apportée a la table " + a + " du rang  " + b);
                        this.table = null;
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

        public void prendreCommande(Table t)
        {
            t.enumEtatTable = EnumEtatTable.COMMANDE_EMISE;           
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
