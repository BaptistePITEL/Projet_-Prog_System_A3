using Metier.Cuisine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    public class Serveur : Personnel
    {
        public Carre carre;
        public Restaurant restaurant;

        public int compteurServirEntree = 0;
        public int compteurServirPlat = 0;
        public int compteurServirDessert = 0;

        public static int serviceEntree = 0;
        public static int servicePlat = 0;
        public static int serviceDessert = 0;

        public Recette recette;
        
        public Serveur(Carre carre, Restaurant r, string nom) : base(nom)
        {
            this.carre = carre;
            this.restaurant = r;
        }

        public override Restaurant getRestaurant()
        {
            return restaurant;
        }

        public override void tick()
        {
            if (restaurant.comptoir.entreesAServir.Count != 0)
            {

                int nombreClient_Entree = 0;

                foreach (Recette recette in restaurant.comptoir.entreesAServir)
                {
                    nombreClient_Entree = recette.table.grclient.clients.Count;
                }

                int tablePresente = 0;

                foreach (Rang rang in this.carre.rangs)
                {
                    if (rang.tables.Contains(restaurant.comptoir.entreesAServir.First().table))
                    {
                        tablePresente = 1;
                    }
                }

                if ((nombreClient_Entree == restaurant.comptoir.entreesAServir.Count || serviceEntree >= 1) && tablePresente == 1)
                {
                    
                    compteurServirEntree += 1;

                    if (compteurServirEntree == 2)
                    {
                        recette  = restaurant.comptoir.entreesAServir.Dequeue();
                        
                        int quitter = 0;
                        foreach (Rang rang in this.carre.rangs)
                        {
                            if (rang.tables.Contains(recette.table))
                            {
                                foreach (Client client in recette.table.grclient.clients)
                                {
                                    if (client.platRecu == null)
                                    {
                                        client.platRecu = recette;
                                        log("" + this.nom + ": Entrées servis : " + recette.titre);
                                        recette = null;
                                        quitter = 1;
                                        break;
                                    }

                                }
                                if (quitter == 1)
                                    break;
                            }
                        }
                        compteurServirEntree = 0;

                        Serveur.serviceEntree += 1;
                        Serveur.servicePlat = 0;
                        Serveur.serviceDessert = 0;

                        if (Serveur.serviceEntree == nombreClient_Entree)
                        {
                            Serveur.serviceEntree = 0;
                        }

                    }

                
                }

            }

          

            if (restaurant.comptoir.platsAServir.Count != 0)
            { 

                int nombreClient_Plat = 0;

                foreach (Recette recette in restaurant.comptoir.platsAServir)
                {
                    nombreClient_Plat = recette.table.grclient.clients.Count;
                }

                int tablePresente = 0;

                foreach (Rang rang in this.carre.rangs)
                {
                    if (rang.tables.Contains(restaurant.comptoir.platsAServir.First().table))
                    {
                        tablePresente = 1;
                    }
                }

                if ((nombreClient_Plat == restaurant.comptoir.platsAServir.Count || servicePlat >= 1) && tablePresente == 1)
                    {
                        compteurServirPlat += 1;

                        if (compteurServirPlat == 2)
                        {
                             recette = restaurant.comptoir.platsAServir.Dequeue();
                        
                             int quitter = 0;

                            foreach (Rang rang in this.carre.rangs)
                            {
                                if (rang.tables.Contains(recette.table))
                                {
                                    foreach (Client client in recette.table.grclient.clients)
                                    {

                                        if (client.platRecu == null)
                                        {
                                            client.platRecu = recette;
                                            log("" + this.nom + ": Plat servis : " + recette.titre);                                       
                                            recette = null;
                                            quitter = 1;
                                            break;
                                        }

                                    }
                                    if (quitter == 1)
                                        break;
                                }
                            }
                            compteurServirPlat = 0;

                            Serveur.serviceEntree = 0;
                            Serveur.servicePlat += 1;
                            Serveur.serviceDessert = 0;

                            if (Serveur.servicePlat == nombreClient_Plat)
                            {
                                Serveur.servicePlat = 0;
                            }
                        }     
                    }
            }

            if(restaurant.comptoir.dessertsAServir.Count != 0)
            { 
                int nombreClient_Dessert = 0;
                foreach (Recette recette in restaurant.comptoir.dessertsAServir)
                {
                    nombreClient_Dessert = recette.table.grclient.clients.Count;
                }


                int tablePresente = 0;

                foreach (Rang rang in this.carre.rangs)
                {
                    if (rang.tables.Contains(restaurant.comptoir.dessertsAServir.First().table))
                    {
                        tablePresente = 1;
                    }
                }

                if ((nombreClient_Dessert == restaurant.comptoir.dessertsAServir.Count || serviceDessert >= 1) && tablePresente == 1)
                {
                    compteurServirDessert += 1;

                    if (compteurServirDessert == 2)
                    {
                        recette  = restaurant.comptoir.dessertsAServir.Dequeue();

                        int quitter = 0;
                        foreach (Rang rang in this.carre.rangs)
                        {
                            if (rang.tables.Contains(recette.table))
                            {
                                foreach (Client client in recette.table.grclient.clients)
                                {
                                    if (client.platRecu == null)
                                    {
                                        client.platRecu = recette;
                                        log("" + this.nom + ": Dessert servis : " + recette.titre);

                                        recette = null;
                                        quitter = 1;
                                        break;
                                    }

                                }
                                if (quitter == 1)
                                    break;
                            }
                        }
                        compteurServirDessert = 0;

                        Serveur.serviceEntree = 0;
                        Serveur.servicePlat = 0;
                        Serveur.serviceDessert += 1;

                        if (Serveur.serviceDessert == nombreClient_Dessert)
                        {
                            Serveur.serviceDessert = 0;
                        }
                    }
                   
                }
            }

        }
    }
}
