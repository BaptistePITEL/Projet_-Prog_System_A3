using Metier;
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
        private Client clt1;
        private Client clt2;



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

            gc1 = new GroupeClient();
            gc2 = new GroupeClient();

            FabriqueClient fabriqueClient = new FabriqueClient();

            clt1 = fabriqueClient.create(gc1);
            clt2 = fabriqueClient.create(gc1);

            gc1.clients.Add(clt1);
            gc1.clients.Add(clt2);

            for(int i = 0; i < 6; i++)
            {
                gc2.clients.Add(fabriqueClient.create(gc2));

            }
        }      

        [TestMethod]
        public void TestAccueilClient()
        {
            resto.groupeClientArrive(gc1);

            resto.groupeClientArrive(gc2);
            resto.tick();
      
            Assert.AreNotEqual(null, gc1.table);
        }
    }
}
