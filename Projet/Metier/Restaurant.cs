using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Salle;
using Metier.Cuisine;

namespace Metier
{
    public class Restaurant
    {
        
        public MaitreHotel maitreHotel;
        public List<GroupeClient> listAttente;
        public List<Carre> carres;
        public static ConnexionBD connexionBD; 

        public Restaurant()
        {
            this.listAttente = new List<GroupeClient>();
            this.carres = new List<Carre>();
            connexionBD = new ConnexionBD();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
        }

        public  void tick()
        {
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
            }
            log("------------------ FIN TICK ------------------");
        }
        public void tickFor(int x)
        {
            
        }

        public void groupeClientArrive(GroupeClient gc)
        {
            this.listAttente.Add(gc);
        }

        public void addMaitreHotel(MaitreHotel maitreHotel)
        {
            this.maitreHotel = maitreHotel;
        }

        public void log(string s)
        {
            Console.WriteLine(s);
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
            connexionBD.close();
        }
    }
}
