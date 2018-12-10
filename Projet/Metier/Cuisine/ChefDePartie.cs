using Metier.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Cuisine
{
    public class ChefDePartie : Personnel
    {
<<<<<<< HEAD
        public List<Recette> recettes;
        public List<string> roles;
        public Restaurant restaurant;
        public int compteurPrepa = 0;

        public ChefDePartie(string nom, Restaurant r, List<string> roles) : base(nom)
        {
            this.recettes = new List<Recette>();
            this.restaurant = r;
            this.roles = roles;

        }

        public override Restaurant getRestaurant()
        {
            return restaurant;
=======
        public Queue<Recette> recettes;
        public string role;
        public Restaurant restaurant;

        public ChefDePartie(string nom, Restaurant r) : base(nom)
        {
            this.recettes = new Queue<Recette>();
            this.restaurant = r;
>>>>>>> 4edef53407020649206c33f6d70fce782ea7cdd1
        }

        public void PreparerRecette()
        {
            foreach (Recette r in recettes)
            {
                //Attendre tps preparation + cuisson + repos
                this.restaurant.recettesAServir.Add(r);
            }
        }

        public override void tick()
        {
            if(recettes.Count != 0)
            {
                compteurPrepa += 1;
                if (compteurPrepa == 100)
                {
                    log("Plat préparé");
                    compteurPrepa = 0;
                    recettes[0].etat = true;
                }
            }
            
        }
    }

}
