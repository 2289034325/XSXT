﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIANMA.JCSJData {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JCSJData.IDataService", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/BMZHLogin", ReplyAction="http://tempuri.org/IDataService/BMZHLoginResponse")]
        DB_JCSJ.Models.TUser BMZHLogin(string dlm, string mm, string tzm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/BMZHLogin", ReplyAction="http://tempuri.org/IDataService/BMZHLoginResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TUser> BMZHLoginAsync(string dlm, string mm, string tzm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/CKZHLogin", ReplyAction="http://tempuri.org/IDataService/CKZHLoginResponse")]
        void CKZHLogin(int ckid, string tzm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/CKZHLogin", ReplyAction="http://tempuri.org/IDataService/CKZHLoginResponse")]
        System.Threading.Tasks.Task CKZHLoginAsync(int ckid, string tzm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/FDZHLogin", ReplyAction="http://tempuri.org/IDataService/FDZHLoginResponse")]
        void FDZHLogin(int fdid, string tzm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/FDZHLogin", ReplyAction="http://tempuri.org/IDataService/FDZHLoginResponse")]
        System.Threading.Tasks.Task FDZHLoginAsync(int fdid, string tzm);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/BMZHEditPsw", ReplyAction="http://tempuri.org/IDataService/BMZHEditPswResponse")]
        void BMZHEditPsw(string om, string nm);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/BMZHEditPsw", ReplyAction="http://tempuri.org/IDataService/BMZHEditPswResponse")]
        System.Threading.Tasks.Task BMZHEditPswAsync(string om, string nm);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetTiaomasByCond", ReplyAction="http://tempuri.org/IDataService/GetTiaomasByCondResponse")]
        DB_JCSJ.Models.TTiaoma[] GetTiaomasByCond(string Kuanhao, string Tiaoma, System.Nullable<System.DateTime> Start, System.Nullable<System.DateTime> End);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetTiaomasByCond", ReplyAction="http://tempuri.org/IDataService/GetTiaomasByCondResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> GetTiaomasByCondAsync(string Kuanhao, string Tiaoma, System.Nullable<System.DateTime> Start, System.Nullable<System.DateTime> End);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetGongyingshangs", ReplyAction="http://tempuri.org/IDataService/GetGongyingshangsResponse")]
        DB_JCSJ.Models.TGongyingshang[] GetGongyingshangs();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetGongyingshangs", ReplyAction="http://tempuri.org/IDataService/GetGongyingshangsResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TGongyingshang[]> GetGongyingshangsAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetKuanhaos", ReplyAction="http://tempuri.org/IDataService/GetKuanhaosResponse")]
        DB_JCSJ.Models.TKuanhao[] GetKuanhaos();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetKuanhaos", ReplyAction="http://tempuri.org/IDataService/GetKuanhaosResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao[]> GetKuanhaosAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/InsertKuanhao", ReplyAction="http://tempuri.org/IDataService/InsertKuanhaoResponse")]
        DB_JCSJ.Models.TKuanhao InsertKuanhao(DB_JCSJ.Models.TKuanhao k);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/InsertKuanhao", ReplyAction="http://tempuri.org/IDataService/InsertKuanhaoResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao> InsertKuanhaoAsync(DB_JCSJ.Models.TKuanhao k);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/EditKuanhao", ReplyAction="http://tempuri.org/IDataService/EditKuanhaoResponse")]
        void EditKuanhao(DB_JCSJ.Models.TKuanhao k);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/EditKuanhao", ReplyAction="http://tempuri.org/IDataService/EditKuanhaoResponse")]
        System.Threading.Tasks.Task EditKuanhaoAsync(DB_JCSJ.Models.TKuanhao k);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/DeleteKuanhao", ReplyAction="http://tempuri.org/IDataService/DeleteKuanhaoResponse")]
        void DeleteKuanhao(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/DeleteKuanhao", ReplyAction="http://tempuri.org/IDataService/DeleteKuanhaoResponse")]
        System.Threading.Tasks.Task DeleteKuanhaoAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetKuanhaoByMc", ReplyAction="http://tempuri.org/IDataService/GetKuanhaoByMcResponse")]
        DB_JCSJ.Models.TKuanhao GetKuanhaoByMc(string kh);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetKuanhaoByMc", ReplyAction="http://tempuri.org/IDataService/GetKuanhaoByMcResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao> GetKuanhaoByMcAsync(string kh);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetTiaomasByKuanhaoMc", ReplyAction="http://tempuri.org/IDataService/GetTiaomasByKuanhaoMcResponse")]
        DB_JCSJ.Models.TTiaoma[] GetTiaomasByKuanhaoMc(string kh);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetTiaomasByKuanhaoMc", ReplyAction="http://tempuri.org/IDataService/GetTiaomasByKuanhaoMcResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> GetTiaomasByKuanhaoMcAsync(string kh);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/CheckKuanhaosChongfu", ReplyAction="http://tempuri.org/IDataService/CheckKuanhaosChongfuResponse")]
        string[] CheckKuanhaosChongfu(string[] khs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/CheckKuanhaosChongfu", ReplyAction="http://tempuri.org/IDataService/CheckKuanhaosChongfuResponse")]
        System.Threading.Tasks.Task<string[]> CheckKuanhaosChongfuAsync(string[] khs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/CheckTiaomaChongfu", ReplyAction="http://tempuri.org/IDataService/CheckTiaomaChongfuResponse")]
        string[] CheckTiaomaChongfu(string[] tms);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/CheckTiaomaChongfu", ReplyAction="http://tempuri.org/IDataService/CheckTiaomaChongfuResponse")]
        System.Threading.Tasks.Task<string[]> CheckTiaomaChongfuAsync(string[] tms);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/SaveKuanhaos", ReplyAction="http://tempuri.org/IDataService/SaveKuanhaosResponse")]
        DB_JCSJ.Models.TKuanhao[] SaveKuanhaos(DB_JCSJ.Models.TKuanhao[] ks);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/SaveKuanhaos", ReplyAction="http://tempuri.org/IDataService/SaveKuanhaosResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao[]> SaveKuanhaosAsync(DB_JCSJ.Models.TKuanhao[] ks);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/SaveTiaomas", ReplyAction="http://tempuri.org/IDataService/SaveTiaomasResponse")]
        DB_JCSJ.Models.TTiaoma[] SaveTiaomas(DB_JCSJ.Models.TTiaoma[] ts);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/SaveTiaomas", ReplyAction="http://tempuri.org/IDataService/SaveTiaomasResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> SaveTiaomasAsync(DB_JCSJ.Models.TTiaoma[] ts);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/EditTiaoma", ReplyAction="http://tempuri.org/IDataService/EditTiaomaResponse")]
        void EditTiaoma(DB_JCSJ.Models.TTiaoma t);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/EditTiaoma", ReplyAction="http://tempuri.org/IDataService/EditTiaomaResponse")]
        System.Threading.Tasks.Task EditTiaomaAsync(DB_JCSJ.Models.TTiaoma t);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetTiaomasByTiaomahaos", ReplyAction="http://tempuri.org/IDataService/GetTiaomasByTiaomahaosResponse")]
        DB_JCSJ.Models.TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetTiaomasByTiaomahaos", ReplyAction="http://tempuri.org/IDataService/GetTiaomasByTiaomahaosResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> GetTiaomasByTiaomahaosAsync(string[] tmhs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/HuiyuanZhuce", ReplyAction="http://tempuri.org/IDataService/HuiyuanZhuceResponse")]
        DB_JCSJ.Models.THuiyuan HuiyuanZhuce(DB_JCSJ.Models.THuiyuan h);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/HuiyuanZhuce", ReplyAction="http://tempuri.org/IDataService/HuiyuanZhuceResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.THuiyuan> HuiyuanZhuceAsync(DB_JCSJ.Models.THuiyuan h);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetHuiyuanByShoujihao", ReplyAction="http://tempuri.org/IDataService/GetHuiyuanByShoujihaoResponse")]
        DB_JCSJ.Models.THuiyuan GetHuiyuanByShoujihao(string sjh);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetHuiyuanByShoujihao", ReplyAction="http://tempuri.org/IDataService/GetHuiyuanByShoujihaoResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.THuiyuan> GetHuiyuanByShoujihaoAsync(string sjh);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetHuiyuanById", ReplyAction="http://tempuri.org/IDataService/GetHuiyuanByIdResponse")]
        DB_JCSJ.Models.THuiyuan GetHuiyuanById(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetHuiyuanById", ReplyAction="http://tempuri.org/IDataService/GetHuiyuanByIdResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.THuiyuan> GetHuiyuanByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/UpdateHuiyuan", ReplyAction="http://tempuri.org/IDataService/UpdateHuiyuanResponse")]
        void UpdateHuiyuan(DB_JCSJ.Models.THuiyuan h);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/UpdateHuiyuan", ReplyAction="http://tempuri.org/IDataService/UpdateHuiyuanResponse")]
        System.Threading.Tasks.Task UpdateHuiyuanAsync(DB_JCSJ.Models.THuiyuan h);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoXiaoshou", ReplyAction="http://tempuri.org/IDataService/ShangbaoXiaoshouResponse")]
        void ShangbaoXiaoshou(DB_JCSJ.Models.TXiaoshou[] xss);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoXiaoshou", ReplyAction="http://tempuri.org/IDataService/ShangbaoXiaoshouResponse")]
        System.Threading.Tasks.Task ShangbaoXiaoshouAsync(DB_JCSJ.Models.TXiaoshou[] xss);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoKucun_FD", ReplyAction="http://tempuri.org/IDataService/ShangbaoKucun_FDResponse")]
        void ShangbaoKucun_FD(DB_JCSJ.Models.TFendianKucunMX[] fks);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoKucun_FD", ReplyAction="http://tempuri.org/IDataService/ShangbaoKucun_FDResponse")]
        System.Threading.Tasks.Task ShangbaoKucun_FDAsync(DB_JCSJ.Models.TFendianKucunMX[] fks);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoJinchuhuo_FD", ReplyAction="http://tempuri.org/IDataService/ShangbaoJinchuhuo_FDResponse")]
        void ShangbaoJinchuhuo_FD(DB_JCSJ.Models.TFendianJinchuhuo[] fjcs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoJinchuhuo_FD", ReplyAction="http://tempuri.org/IDataService/ShangbaoJinchuhuo_FDResponse")]
        System.Threading.Tasks.Task ShangbaoJinchuhuo_FDAsync(DB_JCSJ.Models.TFendianJinchuhuo[] fjcs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoKucun_CK", ReplyAction="http://tempuri.org/IDataService/ShangbaoKucun_CKResponse")]
        void ShangbaoKucun_CK(DB_JCSJ.Models.TCangkuKucunMX[] cks);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoKucun_CK", ReplyAction="http://tempuri.org/IDataService/ShangbaoKucun_CKResponse")]
        System.Threading.Tasks.Task ShangbaoKucun_CKAsync(DB_JCSJ.Models.TCangkuKucunMX[] cks);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoJinchuhuo_CK", ReplyAction="http://tempuri.org/IDataService/ShangbaoJinchuhuo_CKResponse")]
        void ShangbaoJinchuhuo_CK(DB_JCSJ.Models.TCangkuJinchuhuo[] cjcs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/ShangbaoJinchuhuo_CK", ReplyAction="http://tempuri.org/IDataService/ShangbaoJinchuhuo_CKResponse")]
        System.Threading.Tasks.Task ShangbaoJinchuhuo_CKAsync(DB_JCSJ.Models.TCangkuJinchuhuo[] cjcs);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/CangkufahuoFendian", ReplyAction="http://tempuri.org/IDataService/CangkufahuoFendianResponse")]
        void CangkufahuoFendian(int oid, int fdid);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/CangkufahuoFendian", ReplyAction="http://tempuri.org/IDataService/CangkufahuoFendianResponse")]
        System.Threading.Tasks.Task CangkufahuoFendianAsync(int oid, int fdid);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetFendians", ReplyAction="http://tempuri.org/IDataService/GetFendiansResponse")]
        DB_JCSJ.Models.TFendian[] GetFendians();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/GetFendians", ReplyAction="http://tempuri.org/IDataService/GetFendiansResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TFendian[]> GetFendiansAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/XiazaiJinhuoShuju", ReplyAction="http://tempuri.org/IDataService/XiazaiJinhuoShujuResponse")]
        DB_JCSJ.Models.TCangkuJinchuhuo[] XiazaiJinhuoShuju();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IDataService/XiazaiJinhuoShuju", ReplyAction="http://tempuri.org/IDataService/XiazaiJinhuoShujuResponse")]
        System.Threading.Tasks.Task<DB_JCSJ.Models.TCangkuJinchuhuo[]> XiazaiJinhuoShujuAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataServiceChannel : BIANMA.JCSJData.IDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataServiceClient : System.ServiceModel.ClientBase<BIANMA.JCSJData.IDataService>, BIANMA.JCSJData.IDataService {
        
        public DataServiceClient() {
        }
        
        public DataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DB_JCSJ.Models.TUser BMZHLogin(string dlm, string mm, string tzm) {
            return base.Channel.BMZHLogin(dlm, mm, tzm);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TUser> BMZHLoginAsync(string dlm, string mm, string tzm) {
            return base.Channel.BMZHLoginAsync(dlm, mm, tzm);
        }
        
        public void CKZHLogin(int ckid, string tzm) {
            base.Channel.CKZHLogin(ckid, tzm);
        }
        
        public System.Threading.Tasks.Task CKZHLoginAsync(int ckid, string tzm) {
            return base.Channel.CKZHLoginAsync(ckid, tzm);
        }
        
        public void FDZHLogin(int fdid, string tzm) {
            base.Channel.FDZHLogin(fdid, tzm);
        }
        
        public System.Threading.Tasks.Task FDZHLoginAsync(int fdid, string tzm) {
            return base.Channel.FDZHLoginAsync(fdid, tzm);
        }
        
        public void BMZHEditPsw(string om, string nm) {
            base.Channel.BMZHEditPsw(om, nm);
        }
        
        public System.Threading.Tasks.Task BMZHEditPswAsync(string om, string nm) {
            return base.Channel.BMZHEditPswAsync(om, nm);
        }
        
        public DB_JCSJ.Models.TTiaoma[] GetTiaomasByCond(string Kuanhao, string Tiaoma, System.Nullable<System.DateTime> Start, System.Nullable<System.DateTime> End) {
            return base.Channel.GetTiaomasByCond(Kuanhao, Tiaoma, Start, End);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> GetTiaomasByCondAsync(string Kuanhao, string Tiaoma, System.Nullable<System.DateTime> Start, System.Nullable<System.DateTime> End) {
            return base.Channel.GetTiaomasByCondAsync(Kuanhao, Tiaoma, Start, End);
        }
        
        public DB_JCSJ.Models.TGongyingshang[] GetGongyingshangs() {
            return base.Channel.GetGongyingshangs();
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TGongyingshang[]> GetGongyingshangsAsync() {
            return base.Channel.GetGongyingshangsAsync();
        }
        
        public DB_JCSJ.Models.TKuanhao[] GetKuanhaos() {
            return base.Channel.GetKuanhaos();
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao[]> GetKuanhaosAsync() {
            return base.Channel.GetKuanhaosAsync();
        }
        
        public DB_JCSJ.Models.TKuanhao InsertKuanhao(DB_JCSJ.Models.TKuanhao k) {
            return base.Channel.InsertKuanhao(k);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao> InsertKuanhaoAsync(DB_JCSJ.Models.TKuanhao k) {
            return base.Channel.InsertKuanhaoAsync(k);
        }
        
        public void EditKuanhao(DB_JCSJ.Models.TKuanhao k) {
            base.Channel.EditKuanhao(k);
        }
        
        public System.Threading.Tasks.Task EditKuanhaoAsync(DB_JCSJ.Models.TKuanhao k) {
            return base.Channel.EditKuanhaoAsync(k);
        }
        
        public void DeleteKuanhao(int id) {
            base.Channel.DeleteKuanhao(id);
        }
        
        public System.Threading.Tasks.Task DeleteKuanhaoAsync(int id) {
            return base.Channel.DeleteKuanhaoAsync(id);
        }
        
        public DB_JCSJ.Models.TKuanhao GetKuanhaoByMc(string kh) {
            return base.Channel.GetKuanhaoByMc(kh);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao> GetKuanhaoByMcAsync(string kh) {
            return base.Channel.GetKuanhaoByMcAsync(kh);
        }
        
        public DB_JCSJ.Models.TTiaoma[] GetTiaomasByKuanhaoMc(string kh) {
            return base.Channel.GetTiaomasByKuanhaoMc(kh);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> GetTiaomasByKuanhaoMcAsync(string kh) {
            return base.Channel.GetTiaomasByKuanhaoMcAsync(kh);
        }
        
        public string[] CheckKuanhaosChongfu(string[] khs) {
            return base.Channel.CheckKuanhaosChongfu(khs);
        }
        
        public System.Threading.Tasks.Task<string[]> CheckKuanhaosChongfuAsync(string[] khs) {
            return base.Channel.CheckKuanhaosChongfuAsync(khs);
        }
        
        public string[] CheckTiaomaChongfu(string[] tms) {
            return base.Channel.CheckTiaomaChongfu(tms);
        }
        
        public System.Threading.Tasks.Task<string[]> CheckTiaomaChongfuAsync(string[] tms) {
            return base.Channel.CheckTiaomaChongfuAsync(tms);
        }
        
        public DB_JCSJ.Models.TKuanhao[] SaveKuanhaos(DB_JCSJ.Models.TKuanhao[] ks) {
            return base.Channel.SaveKuanhaos(ks);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TKuanhao[]> SaveKuanhaosAsync(DB_JCSJ.Models.TKuanhao[] ks) {
            return base.Channel.SaveKuanhaosAsync(ks);
        }
        
        public DB_JCSJ.Models.TTiaoma[] SaveTiaomas(DB_JCSJ.Models.TTiaoma[] ts) {
            return base.Channel.SaveTiaomas(ts);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> SaveTiaomasAsync(DB_JCSJ.Models.TTiaoma[] ts) {
            return base.Channel.SaveTiaomasAsync(ts);
        }
        
        public void EditTiaoma(DB_JCSJ.Models.TTiaoma t) {
            base.Channel.EditTiaoma(t);
        }
        
        public System.Threading.Tasks.Task EditTiaomaAsync(DB_JCSJ.Models.TTiaoma t) {
            return base.Channel.EditTiaomaAsync(t);
        }
        
        public DB_JCSJ.Models.TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs) {
            return base.Channel.GetTiaomasByTiaomahaos(tmhs);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TTiaoma[]> GetTiaomasByTiaomahaosAsync(string[] tmhs) {
            return base.Channel.GetTiaomasByTiaomahaosAsync(tmhs);
        }
        
        public DB_JCSJ.Models.THuiyuan HuiyuanZhuce(DB_JCSJ.Models.THuiyuan h) {
            return base.Channel.HuiyuanZhuce(h);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.THuiyuan> HuiyuanZhuceAsync(DB_JCSJ.Models.THuiyuan h) {
            return base.Channel.HuiyuanZhuceAsync(h);
        }
        
        public DB_JCSJ.Models.THuiyuan GetHuiyuanByShoujihao(string sjh) {
            return base.Channel.GetHuiyuanByShoujihao(sjh);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.THuiyuan> GetHuiyuanByShoujihaoAsync(string sjh) {
            return base.Channel.GetHuiyuanByShoujihaoAsync(sjh);
        }
        
        public DB_JCSJ.Models.THuiyuan GetHuiyuanById(int id) {
            return base.Channel.GetHuiyuanById(id);
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.THuiyuan> GetHuiyuanByIdAsync(int id) {
            return base.Channel.GetHuiyuanByIdAsync(id);
        }
        
        public void UpdateHuiyuan(DB_JCSJ.Models.THuiyuan h) {
            base.Channel.UpdateHuiyuan(h);
        }
        
        public System.Threading.Tasks.Task UpdateHuiyuanAsync(DB_JCSJ.Models.THuiyuan h) {
            return base.Channel.UpdateHuiyuanAsync(h);
        }
        
        public void ShangbaoXiaoshou(DB_JCSJ.Models.TXiaoshou[] xss) {
            base.Channel.ShangbaoXiaoshou(xss);
        }
        
        public System.Threading.Tasks.Task ShangbaoXiaoshouAsync(DB_JCSJ.Models.TXiaoshou[] xss) {
            return base.Channel.ShangbaoXiaoshouAsync(xss);
        }
        
        public void ShangbaoKucun_FD(DB_JCSJ.Models.TFendianKucunMX[] fks) {
            base.Channel.ShangbaoKucun_FD(fks);
        }
        
        public System.Threading.Tasks.Task ShangbaoKucun_FDAsync(DB_JCSJ.Models.TFendianKucunMX[] fks) {
            return base.Channel.ShangbaoKucun_FDAsync(fks);
        }
        
        public void ShangbaoJinchuhuo_FD(DB_JCSJ.Models.TFendianJinchuhuo[] fjcs) {
            base.Channel.ShangbaoJinchuhuo_FD(fjcs);
        }
        
        public System.Threading.Tasks.Task ShangbaoJinchuhuo_FDAsync(DB_JCSJ.Models.TFendianJinchuhuo[] fjcs) {
            return base.Channel.ShangbaoJinchuhuo_FDAsync(fjcs);
        }
        
        public void ShangbaoKucun_CK(DB_JCSJ.Models.TCangkuKucunMX[] cks) {
            base.Channel.ShangbaoKucun_CK(cks);
        }
        
        public System.Threading.Tasks.Task ShangbaoKucun_CKAsync(DB_JCSJ.Models.TCangkuKucunMX[] cks) {
            return base.Channel.ShangbaoKucun_CKAsync(cks);
        }
        
        public void ShangbaoJinchuhuo_CK(DB_JCSJ.Models.TCangkuJinchuhuo[] cjcs) {
            base.Channel.ShangbaoJinchuhuo_CK(cjcs);
        }
        
        public System.Threading.Tasks.Task ShangbaoJinchuhuo_CKAsync(DB_JCSJ.Models.TCangkuJinchuhuo[] cjcs) {
            return base.Channel.ShangbaoJinchuhuo_CKAsync(cjcs);
        }
        
        public void CangkufahuoFendian(int oid, int fdid) {
            base.Channel.CangkufahuoFendian(oid, fdid);
        }
        
        public System.Threading.Tasks.Task CangkufahuoFendianAsync(int oid, int fdid) {
            return base.Channel.CangkufahuoFendianAsync(oid, fdid);
        }
        
        public DB_JCSJ.Models.TFendian[] GetFendians() {
            return base.Channel.GetFendians();
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TFendian[]> GetFendiansAsync() {
            return base.Channel.GetFendiansAsync();
        }
        
        public DB_JCSJ.Models.TCangkuJinchuhuo[] XiazaiJinhuoShuju() {
            return base.Channel.XiazaiJinhuoShuju();
        }
        
        public System.Threading.Tasks.Task<DB_JCSJ.Models.TCangkuJinchuhuo[]> XiazaiJinhuoShujuAsync() {
            return base.Channel.XiazaiJinhuoShujuAsync();
        }
    }
}
