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

            if (resto.commandesEnAttente.Count != 0)
            {
                compteur += 1;
                if (compteur == 5)
                {
                    log("Prépa commence");
                    recevoirCommande(resto.commandesEnAttente.Dequeue());
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
<<<<<<< HEAD

            while (this.commandes.Count > 0)
=======
            for (int i = 0; i < this.commandes.Count; i++) ;
>>>>>>> 4edef53407020649206c33f6d70fce782ea7cdd1
            {
                Commande c = this.commandes.Dequeue();

                log("Nb recette " + c.recettes.Count);
                foreach (var rct in c.recettes)
                {
<<<<<<< HEAD
                    log("Recette " + rct.titre);
                }


                foreach (Recette r in c.recettes)
                {

                    log(r.categorie);

                    foreach (ChefDePartie cp in chefParties)
=======
                    r.table = c.table;
                    foreach (ChefDePartie cp in this.chefParties)
>>>>>>> 4edef53407020649206c33f6d70fce782ea7cdd1
                    {
                        if (cp.roles.Contains(r.categorie))
                        {
                            cp.recettes.Add(r);
                            break;
                        }
                    }
                }
            }


        }
    }
}
