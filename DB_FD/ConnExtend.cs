using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_FD
{
    public partial class FDEntities : DbContext
    {
        public FDEntities(string connName)
            : base("name=" + connName)
        {
        }
    }
}
