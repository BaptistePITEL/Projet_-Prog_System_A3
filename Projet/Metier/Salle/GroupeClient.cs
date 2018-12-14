using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    public class GroupeClient
    {
        public List<Client> clients;
        public Table table;
        public bool statut;

        public GroupeClient()
        {
            this.clients = new List<Client>();
            this.statut = false;
        }

        public void tick()
        {
            foreach (Client client in clients)
            {
                client.tick();
            }
        }

        internal void checkToutLeMondePret()
        {
            foreach (var client in clients)
            {
                if (client.dessert == null)
                    return;
            }
            table.enumEtatTable = EnumEtatTable.PRET_A_COMMANDE;
        }

        internal void checkToutLeMondeRecu()
        {
            int nombreEntreRecu = 0;
            int nombrePlatRecu = 0;
            int nombreDessertRecu = 0;

            foreach (var client in clients)
            {
                if (client.platRecu == null)
                {
                    return;                  
                }

                if (client.platRecu.categorie.Equals("Entrées"))
                {
                    nombreEntreRecu += 1;
                }


                if (client.platRecu.categorie.Equals("Plat"))
                {
                     nombrePlatRecu += 1;
                }


                if (client.platRecu.categorie.Equals("Desserts"))
                {
                     nombreDessertRecu += 1;
                }
            }


            if (nombreEntreRecu == this.clients.Count)
            {
                table.enumEtatTable = EnumEtatTable.ENTREE;
                /*foreach (var client in clients)
                {
                    client.log(" Entrées reçu : " + client.platRecu.titre);
                }*/
            }
            if (nombrePlatRecu == this.clients.Count)
            {
                table.enumEtatTable = EnumEtatTable.PLAT;
                /*foreach(var client in clients)
                {
                    client.log(" Plat reçu : " + client.platRecu.titre);
                }*/
            }
            if (nombreDessertRecu == this.clients.Count)
            {
                table.enumEtatTable = EnumEtatTable.DESSERT;
                /*foreach(var client in clients)
                {
                    client.log(" Desserts reçu : " + client.platRecu.titre);
                }*/
            }

        }



        internal void checkToutLeMondeFiniPlat()
        {
            int nombre = 0;

            foreach (var client in clients)
            {
                if (client.platRecu == null)
                {
                    nombre += 1;
                }
            }
            if (nombre == this.clients.Count)
            {
                table.enumEtatTable = EnumEtatTable.COMMANDE_EMISE;
                foreach (var client in clients)
                {
                    client.log("----- La table [" + table.numeroTable+ "] a fini de mangé ses plats -----");
                    break;
                }
            }
        }


        internal void checkToutLeMondeFiniEntree()
        {

            int nombre = 0;

            foreach (var client in clients)
            {
                if (client.platRecu == null)
                {
                    nombre += 1;
                }               
            }
            if (nombre == this.clients.Count)
            {
                table.enumEtatTable = EnumEtatTable.COMMANDE_EMISE;
                foreach (var client in clients)
                {
                    client.log("----- La table [" + table.numeroTable + "] a fini de mangé ses entrées -----");
                    break;
                }
            }
        }


        internal void checkToutLeMondeFiniDessert()
        {
            int nombre = 0;

            foreach (var client in clients)
            {
                if (client.platRecu == null)
                {
                    nombre += 1;
                }
            }
            if (nombre == this.clients.Count)
            {
                table.enumEtatTable = EnumEtatTable.REPAS_FINI;
                foreach (var client in clients)
                {
                    client.log("La table [" + table.numeroTable + "] a fini de mangé ses desserts");
                    break;
                }
            }
        }


        internal void checkToutLeMondePaye()
        {
            int nombre = 0;

            foreach (var client in clients)
            {
                if (client.paye == true)
                {
                    nombre += 1;
                }
            }
            if (nombre == this.clients.Count)
            {
                table.enumEtatTable = EnumEtatTable.PAYE;
                foreach (var client in clients)
                {
                    client.log("La table ["+ table.numeroTable + "] a payé et le groupe part");
                    break;
                }

                foreach (var client in clients)
                {
                   client.groupeClient = null;
                }

                table.grclient = null;
                table.enumEtatTable = EnumEtatTable.INITIALE;         
              

            }
        }

  
    }
        
}
