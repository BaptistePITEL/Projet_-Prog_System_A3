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
        public List<Commande> commandes;
        public List<ChefDePartie> chefParties;
        
        public ChefDeCuisine(string nom) : base(nom)
        {
            this.commandes = new List<Commande>();
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
            this.commandes.Add(c);
        }
        
        public bool RecetteDisponible(Recette r)
        {
            return false;
        }
/*
        public void OrdonnerCommande()
        {
            foreach(Recette r in this.commandes.First().recettes)
            {
                foreach(ChefDePartie cp in this.chefParties)
                {
                    if(cp.role.Equals(r.categorie))
                    {
                        //cp.recettes.(r);
                    }
                }
            }
            this.commandes.RemoveAt(0);
        }
        */
    }
}
