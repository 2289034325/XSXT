﻿using System;
using System.Collections.Generic;
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
            var newEx = new FaultException(ex.Message);
            MessageFault msgFault = newEx.CreateMessageFault();
            msg = Message.CreateMessage(version, msgFault, newEx.Action);
        }
    }
}