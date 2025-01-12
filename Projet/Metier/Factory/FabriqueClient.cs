﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Salle;

namespace Metier.Factory
{
    public class FabriqueClient
    {
        public Random r = new Random();
        static List<String> noms = new List<string>()
                {
                    "John Doe",
                    "Maria Garcia",
                    "Clay Robinson",
                    "Anais Tremblay",
                    "Isa Baresi",
                    "Denise Carrera",
                    "Albert Wayne",
                    "Clark Kent",
                    "Jackie Didier",
                    "Gustave Dupont",
                    "Blenda Olsson"
                };

        public Client create(GroupeClient groupeClient)
        {
            int i = r.Next(noms.Count);
            while (!isvalid(noms[i], groupeClient.clients))
            {
                i = r.Next(noms.Count);
            }
            return new Client(groupeClient, noms[i]);
        }
        /*
        if (i == 1)
        {
            return new Client(groupeClient, "John Doe");
        }
        else if (i == 2)
        {
            return new Client(groupeClient, "Maria Garcia");
        }
        else if (i == 3)
        {
            return new Client(groupeClient, "Clay Robinson");
        }
        else if (i == 4)
        {
            return new Client(groupeClient, "Chris Brantley");
        }
        else if (i == 5)
        {
            return new Client(groupeClient, "Luca Eisenhower");
        }
        else if (i == 6)
        {
            return new Client(groupeClient, "Anais Tremblay");
        }
        else if (i == 7)
        {
            return new Client(groupeClient, "Isa Baresi");
        }
        else if (i == 8)
        {
            return new Client(groupeClient, "Blenda Olsson");
        }
        else if (i == 9)
        {
            return new Client(groupeClient, "Leonardo Sundberg");
        }
        else if (i == 10)
        {
            return new Client(groupeClient, "Eva Townsend");
        }
        else
        {
            return new Client(groupeClient, "Chelsea Rice");
        }*/

        public bool isvalid(string nom, List<Client> clients)
        {
            for(int i =0; i<clients.Count; i++)
            {
                if(clients[i].nom == nom)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
