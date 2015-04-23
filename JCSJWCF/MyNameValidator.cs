using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;

namespace JCSJWCF
{
    public class MyNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {

        }
    }
}