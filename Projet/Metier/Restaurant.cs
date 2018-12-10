using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Salle;
using Metier.Cuisine;
using static Metier.ConnexionBD;

namespace Metier
{
    public class Restaurant
    {
        
        public MaitreHotel maitreHotel;
        public ChefDeCuisine chefDeCuisine;

        public List<GroupeClient> listAttente;
        public List<Carre> carres;

        public List<Recette> recettesAServir;
        public Queue<Commande> commandesEnAttente;

        public int nbTick { get; set; }

        public Restaurant()
        {
            this.listAttente = new List<GroupeClient>();
            this.carres = new List<Carre>();
            this.recettesAServir = new List<Recette>();
            this.commandesEnAttente = new Queue<Commande>();
        }

        public  void tick()
        {
            nbTick++;
            log("------------------ DEBUT TICK ------------------");
            maitreHotel.tick();
            foreach(Carre c in carres)
            {
                c.chefDeRang.tick();     
                foreach(Rang r in c.rangs)
                {
                    foreach(Table t in r.tables)
                    {
                        if(t.grclient !=  null)
                             t.grclient.tick();
                    }
                }
                chefDeCuisine.tick();
                foreach(ChefDePartie chef in chefDeCuisine.chefParties)
                {
                    chef.tick();
                }
            }
            log("------------------ FIN TICK ------------------");
        }
        public void tickFor(int x)
        {
            for(int i = 0; i<x; i++)
            {
                tick();
            }
        }

        public void groupeClientArrive(GroupeClient gc)
        {
            this.listAttente.Add(gc);
        }

        public void addMaitreHotel(MaitreHotel maitreHotel)
        {
            this.maitreHotel = maitreHotel;
        }

        public void addChefDeCuisine(ChefDeCuisine chef)
        {
            this.chefDeCuisine = chef;
        }

        public void log(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }

    }
}
