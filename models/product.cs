using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.models
{
    public class product
    {
        public virtual int id { get; set; }
        public virtual int code { get; set; }
        public virtual string description { get; set; }
        public virtual int currentstock { get; set; }
        public virtual int minstock { get; set; }
        public virtual double price { get; set; }
        public virtual salesperson salesp { get; set; } // Many-To-One con salesperson
        public virtual provider provider { get; set; }  // One-To-One con provider
        public virtual ISet<orderprod> Orders { get; set; } // One-To-Many con orderprod
    }
}
