using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WA.Common.API;
using WA.Common.DataLayer;

namespace WA.API.WCF
{
    public class WcfApi : IApi
    {
        private ServiceHost config;
        public void Bind(string host, int port, IStorage storage)
        {
            config = new ServiceHost(new WcfService(storage), new Uri($"http://{host}:{port}"));
            config.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            
            var behavior = config.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            behavior.ConcurrencyMode = ConcurrencyMode.Multiple;
            behavior.UseSynchronizationContext = false;
            behavior.InstanceContextMode = InstanceContextMode.Single;

            config.Open();
        }

        public void UnBind()
        {
            config?.Close();
        }
    }
}
