using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Metier.Salle;
using Metier.Cuisine;
using static Metier.ConnexionBD;

namespace Metier
{
    public class Restaurant
    {
        
        public MaitreHotel maitreHotel;
        public ChefDeCuisine chefDeCuisine;

        public Comptoir comptoir;

        public List<GroupeClient> listAttente;
        public List<Carre> carres;


        public int nbTick { get; set; }

        public Restaurant()
        {
            this.listAttente = new List<GroupeClient>();
            this.carres = new List<Carre>();
        }

        public  void tick()
        {
            nbTick++;
            //log("------------------ DEBUT TICK ------------------");
            maitreHotel.tick();
            foreach(Carre c in carres)
            {
                c.chefDeRang.tick();


                foreach (Serveur serveur in c.serveurs)
                {
                    serveur.tick();
                }

                foreach (Rang r in c.rangs)
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
           //log("------------------ FIN TICK ------------------");
        }
        public void tickFor(int x)
        {
            log("-----------------------------Restaurant Ouvert !!!!!!!! ----------------------------------");
            for (int i = 0; i<x; i++)
            {
                tick();
            }
            log("-----------------------------Restaurant Fermé !!!!!!!! ----------------------------------");
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
            Console.WriteLine(s);
        }

    }
}
