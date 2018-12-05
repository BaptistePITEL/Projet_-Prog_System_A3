using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Restaurant
    {
        
        public MaitreHotel maitreHotel;
        public List<GroupeClient> listAttente;
        public List<Carre> carres;

        public Restaurant()
        {
            this.listAttente = new List<GroupeClient>();
            this.carres = new List<Carre>();

        }

        public  void tick()
        {
            maitreHotel.tick();
        }
        public void tickFor(int x)
        {
            
        }

        public void groupeClientArrive(GroupeClient gc)
        {
            this.listAttente.Add(gc);
        }
        
    }
}
