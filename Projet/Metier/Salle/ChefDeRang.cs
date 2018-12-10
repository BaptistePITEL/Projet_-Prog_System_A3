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
        public Queue<Table> tablesPretaCommander;
        public Restaurant resto;
        public int compteurCommande = 0;
        public int compteurTable = 0;
        public int compteurCarte = 0;

        public ChefDeRang(Restaurant resto, Carre carre, string nom) : base(nom)
        {
            this.resto = resto;
            this.carre = carre;
            tablesPretaCommander = new Queue<Table>();
        }

        public override Restaurant getRestaurant()
        {
            return resto;
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
                compteurCommande += 1;
                if (compteurCommande == 10)
                {
                    prendreCommande(tablesPretaCommander.Dequeue());
                    compteurCommande = 0;
                }

            }
            else if (this.table != null)
            {
                if (this.table.enumEtatTable == EnumEtatTable.INSTALLE)
                {
                    compteurCarte += 1;
                    if (compteurCarte == 2)
                    {
                        attribuerCarte();
                        compteurCarte = 0;
                    }

                }
            }
            else if (this.gC != null)
            {
                compteurTable += 1;
                if (compteurTable == 10)
                {
                    attribuerTable();
                    compteurTable = 0;
                }
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
            log("" + t.grclient.clients.Count);

            Commande commande = new Commande(t);

            foreach (Client client in t.grclient.clients)
            {


                commande.recettes.Add(client.entree);

                commande.recettes.Add(client.plat);

                commande.recettes.Add(client.dessert);


            }

            resto.commandesEnAttente.Enqueue(commande);
            t.enumEtatTable = EnumEtatTable.COMMANDE_EMISE;

            log("Commande prise sur la table "+commande.recettes.Count);

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
