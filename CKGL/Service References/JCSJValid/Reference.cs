﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CKGL.JCSJValid {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JCSJValid.IValidService")]
    public interface IValidService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/CKZHZhuce", ReplyAction="http://tempuri.org/IValidService/CKZHZhuceResponse")]
        void CKZHZhuce(int ckid, string ckmc, string tzm, string zcm, string ver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/CKZHZhuce", ReplyAction="http://tempuri.org/IValidService/CKZHZhuceResponse")]
        System.Threading.Tasks.Task CKZHZhuceAsync(int ckid, string ckmc, string tzm, string zcm, string ver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/FDZHZhuce", ReplyAction="http://tempuri.org/IValidService/FDZHZhuceResponse")]
        void FDZHZhuce(int fdid, string fdmc, string tzm, string zcm, string ver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/FDZHZhuce", ReplyAction="http://tempuri.org/IValidService/FDZHZhuceResponse")]
        System.Threading.Tasks.Task FDZHZhuceAsync(int fdid, string fdmc, string tzm, string zcm, string ver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/BMZHBangding", ReplyAction="http://tempuri.org/IValidService/BMZHBangdingResponse")]
        void BMZHBangding(string dlm, string mm, string tzm, string zcm, string ver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/BMZHBangding", ReplyAction="http://tempuri.org/IValidService/BMZHBangdingResponse")]
        System.Threading.Tasks.Task BMZHBangdingAsync(string dlm, string mm, string tzm, string zcm, string ver);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IValidServiceChannel : CKGL.JCSJValid.IValidService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ValidServiceClient : System.ServiceModel.ClientBase<CKGL.JCSJValid.IValidService>, CKGL.JCSJValid.IValidService {
        
        public ValidServiceClient() {
        }
        
        public ValidServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ValidServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ValidServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ValidServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CKZHZhuce(int ckid, string ckmc, string tzm, string zcm, string ver) {
            base.Channel.CKZHZhuce(ckid, ckmc, tzm, zcm, ver);
        }
        
        public System.Threading.Tasks.Task CKZHZhuceAsync(int ckid, string ckmc, string tzm, string zcm, string ver) {
            return base.Channel.CKZHZhuceAsync(ckid, ckmc, tzm, zcm, ver);
        }
        
        public void FDZHZhuce(int fdid, string fdmc, string tzm, string zcm, string ver) {
            base.Channel.FDZHZhuce(fdid, fdmc, tzm, zcm, ver);
        }
        
        public System.Threading.Tasks.Task FDZHZhuceAsync(int fdid, string fdmc, string tzm, string zcm, string ver) {
            return base.Channel.FDZHZhuceAsync(fdid, fdmc, tzm, zcm, ver);
        }
        
        public void BMZHBangding(string dlm, string mm, string tzm, string zcm, string ver) {
            base.Channel.BMZHBangding(dlm, mm, tzm, zcm, ver);
        }
        
        public System.Threading.Tasks.Task BMZHBangdingAsync(string dlm, string mm, string tzm, string zcm, string ver) {
            return base.Channel.BMZHBangdingAsync(dlm, mm, tzm, zcm, ver);
        }
    }
}
