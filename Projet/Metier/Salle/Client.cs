using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Client : Personnel
    {
        public GroupeClient groupeClient;


        public Client(GroupeClient groupeClient, string nom) : base(nom)
        {
            this.groupeClient = groupeClient;
        }

        public override void log(string log)
        {
            throw new NotImplementedException();
        }

        public override void tick()
        {
           
        }
    }
}
