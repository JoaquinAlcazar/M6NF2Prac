

using cat.itb.M6NF2Prac.cruds;
using cat.itb.M6NF2Prac.models;

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
                    //exercicis.exercici4();
                    break;
                case 5:
                    //exercicis.exercici5();
                    break;
                case 6:
                    //exercicis.exercici6();
                    break;
                case 7:
                    //exercicis.exercici7();
                    break;
                case 8:
                    //exercicis.exercici8();
                    break;
                case 9:
                    //exercicis.exercici9();
                    break;
                case 10:
                    //exercicis.exercici10();
                    break;
                case 11:
                    //exercicis.exercici11();
                    break;
                case 12:
                    //exercicis.exercici12();
                    break;
                case 13:
                    //exercicis.exercici13();
                    break;
                case 14:
                    //exercicis.exercici14();
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
    }
}
