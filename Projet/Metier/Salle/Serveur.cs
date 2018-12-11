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
        public int compteurServir = 0;
        public static int serviceEntree = 0;
        public static int servicePlat = 0;
        public static int serviceDessert = 0;

        public List<Recette> recettes;
        
        public Serveur(Carre carre, Restaurant r, string nom) : base(nom)
        {
            this.carre = carre;
            this.restaurant = r;
            this.recettes = new List<Recette>();
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

                if (nombreClient_Entree == restaurant.comptoir.entreesAServir.Count || serviceEntree >= 1)
                {
                    compteurServir += 1;

                    if (compteurServir == 5)
                    {
                        recettes.Add(restaurant.comptoir.entreesAServir.Dequeue());


                        log("" + serviceEntree);


                        int quitter = 0;
                        foreach (Rang rang in this.carre.rangs)
                        {
                            if (rang.tables.Contains(recettes.First().table))
                            {
                                foreach (Client client in recettes.First().table.grclient.clients)
                                {
                                    if (client.platRecu == null)
                                    {
                                        client.platRecu = recettes.First();
                                        log("" + this.nom + ": Plat servis : " + recettes.First().titre);
                                        quitter = 1;
                                        break;
                                    }

                                }
                                if (quitter == 1)
                                    break;
                            }
                        }
                        compteurServir = 0;

                    }
                    Serveur.serviceEntree += 1;
                    if (Serveur.serviceEntree >= nombreClient_Entree)
                    {
                        Serveur.serviceEntree = 0;
                    }
                }

            }
            else if (restaurant.comptoir.platsAServir.Count != 0)
            { 

                int nombreClient_Plat = 0;

                foreach (Recette recette in restaurant.comptoir.platsAServir)
                {
                    nombreClient_Plat = recette.table.grclient.clients.Count;
                }


                    if (nombreClient_Plat == restaurant.comptoir.platsAServir.Count || servicePlat >= 1)
                    {
                        compteurServir += 1;

                        if (compteurServir == 5)
                        {
                            recettes.Add(restaurant.comptoir.platsAServir.Dequeue());

                            int quitter = 0;
                            foreach (Rang rang in this.carre.rangs)
                            {
                                if (rang.tables.Contains(recettes.First().table))
                                {
                                    foreach (Client client in recettes.First().table.grclient.clients)
                                    {
                                        if (client.platRecu == null)
                                        {
                                            client.platRecu = recettes.First();
                                            log("" + this.nom + ": Plat servis : " + recettes.First().titre);
                                            quitter = 1;
                                            break;
                                        }

                                    }
                                    if (quitter == 1)
                                        break;
                                }
                            }
                            compteurServir = 0;
                        }
                        if (Serveur.servicePlat == nombreClient_Plat)
                        {
                            Serveur.servicePlat = 0;
                        }
                        Serveur.servicePlat += 1;

                    }
            }

            if(restaurant.comptoir.dessertsAServir.Count != 0)
            { 
                int nombreClient_Dessert = 0;
                foreach (Recette recette in restaurant.comptoir.dessertsAServir)
                {
                    nombreClient_Dessert = recette.table.grclient.clients.Count;
                }

                if (nombreClient_Dessert == restaurant.comptoir.dessertsAServir.Count || serviceDessert >= 1)
                {
                    compteurServir += 1;

                    if (compteurServir == 5)
                    {
                        recettes.Add(restaurant.comptoir.dessertsAServir.Dequeue());

                        int quitter = 0;
                        foreach (Rang rang in this.carre.rangs)
                        {
                            if (rang.tables.Contains(recettes.First().table))
                            {
                                foreach (Client client in recettes.First().table.grclient.clients)
                                {
                                    if (client.platRecu == null)
                                    {
                                        client.platRecu = recettes.First();
                                        log("" + this.nom + ": Plat servis : " + recettes.First().titre);
                                        quitter = 1;
                                        break;
                                    }

                                }
                                if (quitter == 1)
                                    break;
                            }
                        }
                        compteurServir = 0;
                    }
                    if (Serveur.serviceDessert == nombreClient_Dessert)
                    {
                        Serveur.serviceDessert = 0;
                    }
                    Serveur.serviceDessert += 1;
                }
            }

        }
    }
}
