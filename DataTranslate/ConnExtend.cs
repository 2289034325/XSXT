using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranslate
{
    public partial class FD_BetaEntities : DbContext
    {
        public FD_BetaEntities(string connName)
            : base("name=" + connName)
        {
        }
    }
}
