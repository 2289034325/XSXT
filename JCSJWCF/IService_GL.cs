using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tool.DB.JCSJ;

namespace JCSJWCF
{
    [ServiceContract]
    public interface IService_GL
    {
        [OperationContract]
        DataTable GetAllUsers(bool ExceptAdmin);

        [OperationContract]
        TUser Login(string dlm, string mm);
    }
}
