using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BBZXWCF
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDataService
    {
        [OperationContract(IsInitiating = true)]
        void CKZHLogin(int ckid, string tzm);

        [OperationContract(IsInitiating = true)]
        void FDZHLogin(int fdid, string tzm);

        //[OperationContract(IsInitiating = false)]
        //TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs);
    }
}
