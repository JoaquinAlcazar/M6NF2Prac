using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.models
{
    public class provider
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string address { get; set; }
        public virtual string city { get; set; }
        public virtual string stcode { get; set; }
        public virtual string zipcode { get; set; }
        public virtual int area { get; set; }
        public virtual string phone { get; set; }
        public virtual int ammount { get; set; }
        public virtual double credit { get; set; }
        public virtual string remark { get; set; }
        public virtual product product { get; set; } // One-To-One con product
    }
}
