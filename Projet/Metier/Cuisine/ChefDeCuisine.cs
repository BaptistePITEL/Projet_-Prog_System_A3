using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;


namespace Metier.Cuisine
{
    class ChefDeCuisine : Personnel
    {
        public List<Commande> listCommandes;
        public List<ChefDePartie> listChefParties;
        
        public ChefDeCuisine(string nom) : base(nom)
        {
            this.listCommandes = new List<Commande>();
            this.listChefParties = new List<ChefDePartie>();
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
            this.listCommandes.Add(c);
        }
        
        public bool RecetteDisponible(Recette r)
        {
            return false;
        }

        public void OrdonnerCommande()
        {
            foreach(Recette r in this.listCommandes.First().listRecettes)
            {
                foreach(ChefDePartie cp in this.listChefParties)
                {
                    if(cp.role.equals(r.categorie))
                    {
                        cp.listRecettes.Add(r);
                    }
                }
            }
            this.listCommandes.First().remove();
        }

    }
}
