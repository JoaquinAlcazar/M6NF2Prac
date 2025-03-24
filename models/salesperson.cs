using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.models
{
    public class salesperson
    {
        public virtual int id { get; set; }
        public virtual string surname { get; set; }
        public virtual string job { get; set; }
        public virtual DateTime startdate { get; set; }
        public virtual double salary { get; set; }
        public virtual double commission { get; set; }
        public virtual string dep { get; set; }
        public virtual IList<product> Products { get; set; } = new List<product>(); // One-To-Many con product
    }
}
