using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_JCSJ
{
    public partial class JCSJEntities : DbContext
    {
        public JCSJEntities(string connName)
            : base("name=" + connName)
        {
        }
    }
}
