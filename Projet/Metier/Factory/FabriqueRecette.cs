using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Cuisine;
using Metier;
using System.Data;

namespace Metier.Factory
{
    class FabriqueRecette
    {
        public ConnexionBD connexionBD;
        public DataTable d1;
        public List<DataRow> list;

        public void create(int type)
        {
            Random r = new Random();
            int i = r.Next(1, 10);

            list = new List<DataRow>();

            connexionBD = new ConnexionBD();

            d1 = connexionBD.execQuery(SelectRecette(type));
            foreach (DataRow r1 in d1.Rows)
            {
                list.Add(r1);
            }


  
            
        }

        public string SelectRecette(int type)
        {
            return "SELECT CTG_NOM_CATEGORIE_RECETTE, R_NOM_RECETTE, R_DESC_RECETTE, R_NBR_PERS_RECETTE,R_TPSPREP_RECETTE, R_TPSCUISSON_RECETTE, R_TPSREPOS_RECETTE FROM RECETTE r, CATEGORIE_RECETTE c WHERE r.CTG_ID == c.CTG_ID AND r.CTG_ID ='" + type +"'";
        }

      
    }
}
