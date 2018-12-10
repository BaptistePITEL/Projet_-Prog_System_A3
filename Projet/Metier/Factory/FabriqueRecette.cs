using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier.Cuisine;
using Metier;
using System.Data;
using Metier.Salle;

namespace Metier.Factory
{
    public class FabriqueRecette
    {
        public DataTable d1;
        public List<DataRow> list;

        public Recette create(int type, Table tb)
        {
            Random r = new Random();
            int i = r.Next(1, 10);

            if (type == 1)
            {
                if (i == 1)
                {
                    return new Recette("Entrées", "Feuilleté au crabe", 10, 20, 0, tb);
                }
                else if (i == 2)
                {
                    return new Recette("Entrées", "Oeuf cocotte", 10, 5, 0, tb);
                }
                else if (i == 3)
                {
                    return new Recette("Entrées", "Foie gras à la vapeur", 60, 4, 1440, tb);
                }
                else if (i == 4)
                {
                    return new Recette("Entrées", "Tarte au thon", 10, 20, 0, tb);
                }
                else
                {
                    return new Recette("Entrées", "Soupe chinoise", 15, 30, 0, tb);
                }
            }
            else if (type == 2)
            {
                if (i == 1)
                {
                    return new Recette("Plat", "Bouillinade d'anguilles ou de poissons", 10, 20, 0, tb);
                }
                else if (i == 2)
                {
                    return new Recette("Plat", "Boles de picoulats", 60, 0, 0, tb);
                }
                else if (i == 3)
                {
                    return new Recette("Plat", "Blanquette de veau", 60, 120, 0, tb);
                }
                else if (i == 4)
                {
                    return new Recette("Plat", "Pate de porc", 30, 180, 0, tb);
                }
                else
                {
                    return new Recette("Plat", "Blanc de poulet a la creme et au miel", 5, 10, 0, tb);
                }
            }
            else
            {
                {
                    if (i == 1)
                    {
                        return new Recette("Desserts", "Gaufres", 10, 120, 0, tb);
                    }
                    else if (i == 2)
                    {
                        return new Recette("Desserts", "Crêpes", 60, 0, 60, tb);
                    }
                    else if (i == 3)
                    {
                        return new Recette("Desserts", "Tiramusi", 60, 0, 60, tb);
                    }
                    else
                    {
                        return new Recette("Desserts", "Madeleine au miel", 15, 5, 0, tb);
                    }
                }

            }


        }
      
    }
}
