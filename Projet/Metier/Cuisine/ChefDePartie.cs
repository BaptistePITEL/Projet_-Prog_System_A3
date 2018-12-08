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


        public ChefDePartie(string nom) : base(nom)
        {
            this.recettes = new Queue<Recette>();
        }

        public void PreparerRecette()
        {
            foreach (Recette r in recettes)
            {
                //Attendre tps preparation + cuisson + repos
                //servir plat
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
