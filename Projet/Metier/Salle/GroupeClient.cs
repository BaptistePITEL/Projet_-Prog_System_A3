using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    public class GroupeClient
    {
        public List<Client> clients;
        public Table table;
        public bool statut;

        public GroupeClient()
        {
            this.clients = new List<Client>();
            this.statut = false;
        }

        public void tick()
        {
            foreach(Client client in clients)
            {
                client.tick();
            }
        }


    } 
}
