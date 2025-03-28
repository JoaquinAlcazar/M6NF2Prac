

using cat.itb.M6NF2Prac.cruds;
using cat.itb.M6NF2Prac.models;
using M6UF2Prac;
using NHibernate.Mapping;

namespace program
{
    public class Program
    {
        static void Main(string[] args)
        {
            exercicis exercicis = new exercicis();

            Console.WriteLine("Selecciona un exercici 1-14");
            int exercici = int.Parse(Console.ReadLine());
            
            switch (exercici)
            {
                case 1:
                    exercicis.exercici1();
                    break;
                case 2:
                    exercicis.exercici2();
                    break;
                case 3:
                    exercicis.exercici3();
                    break;
                case 4:
                    exercicis.exercici4();
                    break;
                case 5:
                    exercicis.exercici5();
                    break;
                case 6:
                    exercicis.exercici6();
                    break;
                case 7:
                    exercicis.exercici7();
                    break;
                case 8:
                    exercicis.exercici8();
                    break;
                case 9:
                    exercicis.exercici9();
                    break;
                case 10:
                    exercicis.exercici10();
                    break;
                case 11:
                    exercicis.exercici11();
                    break;
                case 12:
                    exercicis.exercici12();
                    break;
                case 13:
                    exercicis.exercici13();
                    break;
                case 14:
                    exercicis.exercici14();
                    break;
                default:
                    Console.WriteLine("Exercici no trobat");
                    break;
            }
        }
    }

    public class exercicis
    {
        clientCRUD clientCRUD = new clientCRUD();
        productCRUD productCRUD = new productCRUD();
        orderprodCRUD orderprodCRUD = new orderprodCRUD();
        providerCRUD providerCRUD = new providerCRUD();
        salespersonCRUD salespersonCRUD = new salespersonCRUD();


        public void exercici1()
        {
            List<client> clientsAInsertar = new List<client>
            {
                new client {
                    code=2998,
                    name="Sun Systems"},
                new client {
                    code=2677,
                    name="Roxy Stars"},
                new client {
                    code=2865,
                    name="Clen Ferrant"},
                new client {
                    code=1873,
                    name="Roast Coast"}
            };

            clientCRUD.InsertADO(clientsAInsertar);
        }

        public void exercici2()
        {
            string nameclient = "Roast Coast";
            client client = clientCRUD.SelectByNameADO(nameclient);
            clientCRUD.DeleteADO(client);
        }

        public void exercici3()
        {

            product product1 = productCRUD.SelectByCodeADO(100890);
            product product2 = productCRUD.SelectByCodeADO(200376);
            product product3 = productCRUD.SelectByCodeADO(200380);
            product product4 = productCRUD.SelectByCodeADO(100861);

            product1.price = 59.05;
            product2.price = 25.56;
            product3.price = 33.12;
            product4.price = 13.34;

            productCRUD.UpdateADO(product1);
            productCRUD.UpdateADO(product2);
            productCRUD.UpdateADO(product3);
            productCRUD.UpdateADO(product4);
        }

        public void exercici4()
        {
            double credit = 6000;
            ISet<provider> providers = providerCRUD.SelectCreditLowerThanADO(credit);

            foreach (var provider in providers)
            {
                Console.WriteLine(provider.id + " " + 
                    provider.name + " " + 
                    provider.address + " " + 
                    provider.city + " " + 
                    provider.stcode + " " + 
                    provider.zipcode + " " + 
                    provider.area + " " + 
                    provider.phone + " " + 
                    provider.ammount + " " + 
                    provider.credit + " " + 
                    provider.remark);
            }
        }

        public void exercici5()
        {
            List<salesperson> salespersons = new List<salesperson>
            {
                //Comission no acepta nulls perque double no es nullable en C#
                new salesperson
                {
                    surname = "WASHINGTON",
                    job = "MANAGER",
                    startdate = new DateTime(1974, 12, 01),
                    salary = 139000,
                    commission = 62000,
                    dep = "REPAIR"
                },
                new salesperson
                {
                    surname = "FORD",
                    job = "ASSISTANT",
                    startdate = new DateTime(1985, 03, 25),
                    salary = 105000,
                    commission = 25000,
                    dep = "REPAIR"
                },
                new salesperson
                {
                    surname = "FREEMAN",
                    job = "ASSISTANT",
                    startdate = new DateTime(1965, 09, 12),
                    salary = 90000,
                    commission = 0.0,
                    dep = "REPAIR"
                },
                new salesperson
                {
                    surname = "DAMON",
                    job = "ASSISTANT",
                    startdate = new DateTime(1995, 11, 15),
                    salary = 90000,
                    commission = 0.0,
                    dep = "WOOD"
                }
            };

            salespersonCRUD.InsertADO(salespersons);
        }

        public void exercici6()
        {
            string name = "Carter & Sons";
            client client = clientCRUD.SelectByName(name);

            int num_comandes = client.Orders.Count;
            double cost_total = client.Orders.Sum(o => o.cost);

            Console.WriteLine($"El client amb id {client.id} ha realitzat {num_comandes} comandes i s'ha gastat en total {cost_total} diners");
        }

        public void exercici7()
        {
            salesperson salesperson = salespersonCRUD.SelectBySurname("YOUNG");

            foreach (var product in salesperson.Products)
            {
                Console.WriteLine(product.provider.name + " " +
                    product.provider.city + " " +
                    product.provider.zipcode + " " +
                    product.provider.phone);
            }
        }

        public void exercici8()
        {
            double cost = 12000;
            int amount = 100;

            ISet<orderprod> orders = orderprodCRUD.SelectCostHigherThan(cost, amount);

            foreach (var order in orders)
            {
                Console.WriteLine(order.id + " " +
                    order.orderdate + " " +
                    order.amount + " " +
                    order.deliverydate + " " +
                    order.cost + " " +
                    order.product.description + " " +
                    order.product.price);
            }
        }

        public void exercici9()
        {
            provider provider = providerCRUD.SelectLowestAmount();

            Console.WriteLine(
                provider.name + " " + 
                provider.ammount + " " + 
                provider.product.description + " " + 
                provider.product.currentstock);
        }

        //No puedo hacer que funcione on god
        public void exercici10()
        {
            /*product product1 = new product
            {
                code = 300000,
                description = "Martell",
                price = 10.50,
                currentstock = 100,
                minstock = 10,
                salesp = salespersonCRUD.SelectById(5)
            };

            product product2 = new product
            {
                code = 300001,
                description = "Pollo con salsa y picante",
                price = 5.50,
                currentstock = 100,
                minstock = 10,
                salesp = salespersonCRUD.SelectById(5)
            };

            productCRUD.Insert(product1);
            productCRUD.Insert(product2);

            provider provider1 = new provider
            {
                name = "Ferreteria S.L.",
                address = "Carrer de la Ferreria, 12",
                city = "Barcelona",
                stcode = "B",
                zipcode = "08001",
                area = 415,
                phone = "934567890",
                product = product1,
                ammount = 100,
                credit = 10000,
                remark = "Proveïdor de ferreteria"
            };
            provider provider2 = new provider
            {
                name = "DonPolloInc.",
                address = "Carrer de la Salsa, 13",
                city = "Barcelona",
                stcode = "B",
                zipcode = "08001",
                area = 415,
                phone = "934567891",
                product = product2,
                ammount = 100,
                credit = 10000,
                remark = "Proveïdor de ferreteria"
            };

            
            providerCRUD.Insert(provider1);
            providerCRUD.Insert(provider2);*/
        }

        public void exercici11()
        {
            ISet<client> clients = clientCRUD.SelectAll();
            foreach (var client in clients) {
                Console.WriteLine(
                    client.id + " " + 
                    client.code + " " + 
                    client.name + " " +
                    client.credit);
            }
        }

        public void exercici12()
        {
            string city = "BELMONT";
            double newCredit = 25000;

            ISet<provider> providers = providerCRUD.SelectByCity(city);

            foreach (var provider in providers)
            {
                provider.credit = newCredit;
                providerCRUD.Update(provider);
            }
        }

        public void exercici13()
        {
            ISet<product> products = productCRUD.SelectByPriceHigherThan(100);

            foreach (var product in products)
            {
                Console.WriteLine(product.description + " " + product.price);
            }
        }

        public void exercici14()
        {

            double credit = 50000;
            ISet<client> clients = clientCRUD.SelectByCreditHigherThan(credit);

            foreach (var client in clients)
            {
                Console.WriteLine(client.name + " " + client.credit);
            }
        }
    }
}
