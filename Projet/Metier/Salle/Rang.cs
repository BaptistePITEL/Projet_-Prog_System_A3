using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Salle
{
   public  class Rang
    {
        public List<Table> tables;
        public Carre Carre { get; set; }

        public Rang()
        {
            this.tables = new List<Table>();
        }


        

        
    }
}
