

using cat.itb.M6NF2Prac.cruds;
using cat.itb.M6NF2Prac.models;

namespace program
{
    public class Program
    {
        static void Main(string[] args)
        {
            exercicis exercicis = new exercicis();
        }
    }

    public class exercicis
    {
        clientCRUD clientCRUD = new clientCRUD();
        productCRUD productCRUD = new productCRUD();
        orderprodCRUD orderprodCRUD = new orderprodCRUD();
        providerCRUD providerCRUD = new providerCRUD();

        



    }
}
