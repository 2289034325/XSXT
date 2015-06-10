using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CK
{
    public partial class Entities : DbContext
    {
        public Entities(string connName)
            : base("name=" + connName)
        {
        }
    }
}
