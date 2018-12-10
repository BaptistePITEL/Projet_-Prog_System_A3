using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
    public class Carre
    {
        public List<Rang> rangs;
        public ChefDeRang chefDeRang;
        public static int numero = 0;
        public int id;
        public Restaurant resto { get; set; }

        public Carre()
        {
            this.rangs = new List<Rang>();
            numero += 1;
            id = numero;
        }
    }
}
