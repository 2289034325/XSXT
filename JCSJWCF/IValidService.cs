using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tool;
using Tool.DB.JCSJ;

namespace JCSJWCF
{
    [ServiceContract]
    public interface IValidService
    {
        [OperationContract]
        void BMZHZhuce(string dlm, string mm, string xm, string tzm, string zcm);

        [OperationContract]
        void BMZHBangding(string dlm, string mm, string tzm, string zcm);
    }
}
