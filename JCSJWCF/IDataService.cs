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
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDataService
    {
        [OperationContract(IsInitiating = true)]
        TUser BMZHLogin(string dlm, string mm, string tzm);

        [OperationContract(IsInitiating=false)]
        void BMZHEditPsw(string om,string nm);
    }
}
