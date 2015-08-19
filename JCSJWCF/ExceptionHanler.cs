using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace JCSJWCF
{
    public class MyExceptionBehavior : Attribute, IServiceBehavior
    {
        private readonly Type _errorHandlerType;
        public MyExceptionBehavior(Type errorHandlerType)
        {
            _errorHandlerType = errorHandlerType;
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            var handler =
                (IErrorHandler)Activator.CreateInstance(_errorHandlerType);

            foreach (ChannelDispatcherBase dispatcherBase in
                serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = dispatcherBase as ChannelDispatcher;
                if (channelDispatcher != null)
                    channelDispatcher.ErrorHandlers.Add(handler);
            }
        }
    }

    public class MyGlobalExceptionHandler : IErrorHandler
    {
        /// <summary>
        /// HandleError
        /// </summary>
        /// <param name="ex">ex</param>
        /// <returns>true</returns>
        public bool HandleError(Exception ex)
        {
            return true;
        }

        /// <summary>
        /// ProvideFault
        /// </summary>
        /// <param name="ex">ex</param>
        /// <param name="version">version</param>
        /// <param name="msg">msg</param>
        public void ProvideFault(Exception ex, MessageVersion version, ref Message msg)
        {
            //打log
            string logfile = ConfigurationManager.AppSettings["LogFile"].ToString();
            Tool.CommonFunc.LogEx(logfile, ex);

            //友好错误信息显示
            string errMsg = null;
            if (ex is Tool.MyException)
            {
                errMsg = ex.Message;
            }
            else if (ex is SqlException)
            {
                if (ex.Message.Contains("REFERENCE"))
                {
                    errMsg = "要删除的数据正在被其他数据引用，请先删除引用该数据的数据！";
                }
                else if (ex.Message.Contains("UNIQUE"))
                {
                    errMsg = "发现重复数据，例如登录名，店名，仓库名称，供应商名称，会员手机号，款号，条码号！";
                }
            }
            int i = 0;
            if (errMsg == null)
            {
                while (ex.InnerException != null)
                {
                    //防止无线循环
                    if (i > 5)
                    {
                        break;
                    }

                    ex = ex.InnerException;
                    if (ex is Tool.MyException)
                    {
                        errMsg = ex.Message;
                    }
                    else if (ex is SqlException)
                    {
                        if (ex.Message.Contains("REFERENCE"))
                        {
                            errMsg = "要删除的数据正在被其他数据引用，请先删除引用该数据的数据！";
                        }
                        else if (ex.Message.Contains("UNIQUE"))
                        {
                            errMsg = "发现重复数据，例如登录名，店名，仓库名称，供应商名称，会员手机号，款号，条码号！";
                        }
                    }

                    //防止无线循环
                    i++;
                }
            }

            if (errMsg == null)
            {
                errMsg = "发生未知的系统错误，请联系系统管理员";
            }

            var newEx = new FaultException(errMsg);
            MessageFault msgFault = newEx.CreateMessageFault();
            msg = Message.CreateMessage(version, msgFault, newEx.Action);
        }
    }
}