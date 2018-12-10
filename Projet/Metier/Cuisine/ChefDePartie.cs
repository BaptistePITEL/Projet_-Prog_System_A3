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
        public Queue<Recette> recettes;
        public string role;
        public Restaurant restaurant;

        public ChefDePartie(string nom, Restaurant r) : base(nom)
        {
            this.recettes = new Queue<Recette>();
            this.restaurant = r;
        }

        public void PreparerRecette()
        {
            foreach (Recette r in recettes)
            {
                //Attendre tps preparation + cuisson + repos
                this.restaurant.recettesAServir.Add(r);
            }
        }

        public override void log(string log)
        {
            throw new NotImplementedException();
        }

        public override void tick()
        {
            throw new NotImplementedException();
        }
    }

}
