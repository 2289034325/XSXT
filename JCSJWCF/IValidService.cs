using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tool;

namespace JCSJWCF
{
    [ServiceContract]
    public interface IValidService
    {
        //[OperationContract]
        //void BMZHZhuce(string dlm, string mm, string xm, string tzm, string zcm);

        [OperationContract]
        void CKZHZhuce(int ckid, string ckmc, string tzm, string zcm,string ver);

        [OperationContract]
        void FDZHZhuce(int fdid, string fdmc, string tzm, string zcm,string ver);

        [OperationContract]
        void BMZHBangding(string dlm, string mm, string tzm, string zcm,string ver);
    }
}
