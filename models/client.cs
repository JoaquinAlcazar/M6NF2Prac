using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6NF2Prac.models
{

    public class client
    {
        public virtual int id { get; set; }
        public virtual int code { get; set; }
        public virtual string name { get; set; }
        public virtual double credit { get; set; }
        public virtual ISet<orderprod> Orders { get; set; }// One-To-Many con orderprod
    }
}
