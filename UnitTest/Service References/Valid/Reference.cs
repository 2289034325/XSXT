﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTest.Valid {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Valid.IValidService")]
    public interface IValidService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/BMZHZhuce", ReplyAction="http://tempuri.org/IValidService/BMZHZhuceResponse")]
        void BMZHZhuce(string dlm, string mm, string xm, string tzm, string zcm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/BMZHZhuce", ReplyAction="http://tempuri.org/IValidService/BMZHZhuceResponse")]
        System.Threading.Tasks.Task BMZHZhuceAsync(string dlm, string mm, string xm, string tzm, string zcm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/BMZHBangding", ReplyAction="http://tempuri.org/IValidService/BMZHBangdingResponse")]
        void BMZHBangding(string dlm, string mm, string tzm, string zcm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidService/BMZHBangding", ReplyAction="http://tempuri.org/IValidService/BMZHBangdingResponse")]
        System.Threading.Tasks.Task BMZHBangdingAsync(string dlm, string mm, string tzm, string zcm);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IValidServiceChannel : UnitTest.Valid.IValidService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ValidServiceClient : System.ServiceModel.ClientBase<UnitTest.Valid.IValidService>, UnitTest.Valid.IValidService {
        
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
        
        public void BMZHZhuce(string dlm, string mm, string xm, string tzm, string zcm) {
            base.Channel.BMZHZhuce(dlm, mm, xm, tzm, zcm);
        }
        
        public System.Threading.Tasks.Task BMZHZhuceAsync(string dlm, string mm, string xm, string tzm, string zcm) {
            return base.Channel.BMZHZhuceAsync(dlm, mm, xm, tzm, zcm);
        }
        
        public void BMZHBangding(string dlm, string mm, string tzm, string zcm) {
            base.Channel.BMZHBangding(dlm, mm, tzm, zcm);
        }
        
        public System.Threading.Tasks.Task BMZHBangdingAsync(string dlm, string mm, string tzm, string zcm) {
            return base.Channel.BMZHBangdingAsync(dlm, mm, tzm, zcm);
        }
    }
}
