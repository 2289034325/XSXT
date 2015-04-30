﻿using System;
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

        [OperationContract(IsInitiating = false)]
        TTiaoma[] GetTiaomas(int Userid, string Kuanhao, string Tiaoma, DateTime Start,DateTime  End);


        [OperationContract(IsInitiating = false)]
        TGongyingshang[] GetGongyingshangsByUserId(int UserId);


        [OperationContract(IsInitiating = false)]
        TKuanhao[] GetKuanhaosByUserId(int UserId);


        [OperationContract(IsInitiating = false)]
        TKuanhao InsertKuanhao(TKuanhao k);


        [OperationContract(IsInitiating = false)]
        void EditKuanhao(TKuanhao k);


        [OperationContract(IsInitiating = false)]
        void DeleteKuanhao(int id);

        [OperationContract(IsInitiating = false)]
        TGongyingshang InsertGongyingshang(TGongyingshang g);

        [OperationContract(IsInitiating = false)]
        void EditGongyingshang(TGongyingshang g);

        [OperationContract(IsInitiating = false)]
        void DeleteGongyingshang(int id);

        [OperationContract(IsInitiating = false)]
        TKuanhao GetKuanhaoByMc(string kh);

        [OperationContract(IsInitiating = false)]
        TTiaoma[] GetTiaomasByKuanhaoMc(string kh);

        [OperationContract(IsInitiating = false)]
        string[] CheckKuanhaosChongfu(string[] khs);

        [OperationContract(IsInitiating = false)]
        string[] CheckTiaomaChongfu(string[] tms);

        [OperationContract(IsInitiating = false)]
        TKuanhao[] SaveKuanhaos(TKuanhao[] ks);

        [OperationContract(IsInitiating = false)]
        TTiaoma[] SaveTiaomas(TTiaoma[] ts);

        [OperationContract(IsInitiating = false)]
        void EditTiaoma(TTiaoma t);
    }
}
