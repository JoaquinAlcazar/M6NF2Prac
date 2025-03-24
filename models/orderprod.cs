using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.models
{
    public class orderprod
    {
        public virtual int id { get; set; }
        public virtual DateTime orderdate { get; set; }
        public virtual int amount { get; set; }
        public virtual DateTime deliverydate { get; set; }
        public virtual double cost { get; set; }
        public virtual product product { get; set; } // Many-To-One con product
        public virtual client client { get; set; }   // Many-To-One con client
    }
}
