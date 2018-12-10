using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Metier
{
    public  class ConnexionBD
    {
        private  String cnx;
        private  SqlConnection objetConnexion;

        public  ConnexionBD()
        {
            this.cnx = "Data Source=localhost,1434;Initial Catalog=Projet;User ID=SA;Password=C8v5upzw";
            this.objetConnexion = new SqlConnection(this.cnx);
            this.objetConnexion.Open();
        }

        public DataTable execQuery(string v)
        {
            SqlCommand cmd = new SqlCommand(v, this.objetConnexion);       
            DataTable d1 = new DataTable();
            d1.Load(cmd.ExecuteReader());
            return d1;
        }

        public int execInsertUpdateDelete(string v)
        {
            SqlCommand cmd = new SqlCommand(v, this.objetConnexion);
            return cmd.ExecuteNonQuery();
        }

        public bool execID(string v)
        {
            SqlCommand cmd = new SqlCommand(v, this.objetConnexion);
            int i = (int)cmd.ExecuteScalar();
            if (i == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void close()
        {
            this.objetConnexion.Close();
        }


    }
}

       


        
