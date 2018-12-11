using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;


namespace Metier.Cuisine
{
    public class ChefDeCuisine : Personnel
    {
        public Queue<Commande> commandes;
        public List<ChefDePartie> chefParties;
        public Restaurant resto;

        public int compteur = 0;


        public ChefDeCuisine(Restaurant r, string nom) : base(nom)
        {
            this.commandes = new Queue<Commande>();
            this.resto = r;

        }

        public override Restaurant getRestaurant()
        {
            return resto;
        }

        public override void tick()
        {

            if (resto.comptoir.commandeAPrepare.Count != 0)
            {
                compteur += 1;
                if (compteur == 5)
                {
                    log("Préparation commencé");
                    recevoirCommande(resto.comptoir.commandeAPrepare.Dequeue());
                    ordonnerCommande();
                    compteur = 0;

                }
            }



        }


        public void recevoirCommande(Commande c)
        {
            this.commandes.Enqueue(c);
        }


        public void ordonnerCommande()
        {
            while (this.commandes.Count > 0)
            {   
                Commande c = this.commandes.Dequeue();

                log("Nombre de recette : " + c.recettes.Count);

                foreach (var rct in c.recettes)
                {
                    log("Recette : " + rct.titre);
                }

                foreach (Recette r in c.recettes)
                {
                    log("Catégorie : " + r.categorie );

                    r.table = c.table;
                    int quitter = 0;
                    foreach (ChefDePartie cp in this.chefParties)
                    {
                        if (cp.compteurRecette == 0 )
                        { 
                            if (cp.roles.Contains(r.categorie))
                            {
                                cp.compteurRecette = 1;
                                foreach(ChefDePartie cp1 in this.chefParties)
                                {
                                    if(cp1 != cp)
                                    {
                                        cp1.compteurRecette = 0;
                                    }
                                }
                                quitter = 1;
                                cp.recettes.Add(r);
                                break;
                            }
                            if (quitter == 1)
                            {
                                c.recettes.Remove(r);
                                break;
                            }
                        }
                    }

                }
            }


        }
    }
}
