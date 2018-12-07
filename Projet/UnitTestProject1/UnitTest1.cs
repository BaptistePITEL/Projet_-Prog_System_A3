using Metier;
using Metier.Salle;
using Metier.Builder;
using Metier.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Restaurant resto;
        private GroupeClient gc1;
        private GroupeClient gc2;
      /*  private Client clt1;
        private Client clt2;
        */


        [TestInitialize]
        public void TestInitialize()
        {

            RestaurantBuilder restaurantBuilder = new RestaurantBuilder();
            RestaurantEngineer restaurantEngineer = new RestaurantEngineer(restaurantBuilder);
            List<string> list = new List<string>();
            list.Add("Didier");
            list.Add("Gilbert");
            restaurantEngineer.makeRestaurant(2, 6, 3, 5, list, "Gontrand");
            resto = restaurantEngineer.getRestaurant();

           /* gc1 = new GroupeClient();
            gc2 = new GroupeClient();

            FabriqueClient fabriqueClient = new FabriqueClient();

            clt1 = fabriqueClient.create(gc1);
            clt2 = fabriqueClient.create(gc1);

            gc1.clients.Add(clt1);
            gc1.clients.Add(clt2);

            for(int i = 0; i < 6; i++)
            {
                gc2.clients.Add(fabriqueClient.create(gc2));

            }*/

            FabriqueGroupeClient fC = new FabriqueGroupeClient();

            gc1 = fC.create();
            gc2 = fC.create();
        }      

        [TestMethod]
        public void TestAccueilClient()
        {
            resto.groupeClientArrive(gc1);

            resto.tick();
            resto.groupeClientArrive(gc2);
            resto.tick();
      
            Assert.AreNotEqual(null, gc1.table);
        }

        [TestMethod]
        public void TestAttribuerCarte()
        {
            resto.groupeClientArrive(gc1);
            resto.tick();
            resto.groupeClientArrive(gc2);
            resto.tick();

            Assert.AreEqual(EnumEtatTable.ONT_CARTE, gc1.table.enumEtatTable);
        }

        [TestMethod]
        public void TestPrendreCommande()
        {
            resto.groupeClientArrive(gc1);
            resto.tick();
            resto.groupeClientArrive(gc2);
            resto.tick();
            resto.tick();
            resto.tick();
            resto.tick();
            resto.tick();


            Assert.AreEqual(EnumEtatTable.COMMANDE_EMISE, gc1.table.enumEtatTable);
        }
    }
}
