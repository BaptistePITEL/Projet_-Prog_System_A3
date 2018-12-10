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
        
        public ChefDeCuisine(string nom) : base(nom)
        {
            this.commandes = new Queue<Commande>();
            this.chefParties = new List<ChefDePartie>();
        }

        public override void log(string log)
        {
            throw new NotImplementedException();
        }

        public override void tick()
        {
            throw new NotImplementedException();
        }


    public void RecevoirCommande(Commande c)
        {
            this.commandes.Enqueue(c);
        }
        
        public bool RecetteDisponible(Recette r)
        {
            return true;
        }
        public void OrdonnerCommande()
        {
            for (int i = 0; i < this.commandes.Count; i++) ;
            {
                Commande c = this.commandes.Dequeue();
                foreach(Recette r in c.recettes)
                {
                    r.numTable = c.numTable;
                    foreach (ChefDePartie cp in this.chefParties)
                    {
                        if (cp.role.Equals(r.categorie))
                        {
                            cp.recettes.Enqueue(r);
                        }
                    }
                }
                
            }
        }
    }
}
