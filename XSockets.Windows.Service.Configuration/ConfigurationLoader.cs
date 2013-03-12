using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using XSockets.Core.Common.Configuration;
using XSockets.Plugin.Framework.Core.Attributes;
using ConfigurationSettings = XSockets.Core.Configuration.ConfigurationSettings;

namespace XSockets.Windows.Service.Configuration
{
    [Export(typeof(IConfigurationLoader))]
    public class ConfigurationLoader : IConfigurationLoader
    {
        public IConfigurationSettings _settings = null;

        public Uri GetUri(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IPEndPoint CreateIPEndpoint(Uri uri)
        {
            IPAddress ipAddress;
            IPEndPoint ipEndPoint = null;
            if (IPAddress.TryParse(uri.Host, out ipAddress))
                ipEndPoint = new IPEndPoint(ipAddress, uri.Port);

            else
            {
                var addr = Dns.GetHostAddresses(uri.Host);
                if (addr.Any())
                    ipEndPoint = new IPEndPoint(addr[0], uri.Port);
            }

            return ipEndPoint;
        }

        public IConfigurationSettings ConfigurationSettings
        {
            get
            {
                if (_settings == null)
                {
                    var uri = GetUri(ConfigurationManager.AppSettings["XSockets.Url"]); // Reading from app.config

                    _settings = new ConfigurationSettings
                    {
                        
                        Port = uri.Port,
                        //Origin = new List<string> { "*" },  // Specify your origins here e.g http://xsockets.net
                        Origin = ConfigurationManager.AppSettings["XSockets.Origins"].Split(',').ToList(),  // Reading from app.config  
                        Location = uri.Host,
                        Scheme = uri.Scheme,
                        Uri = uri,
                        BufferSize = 8192,
                        RemoveInactiveStorageAfterXDays = 7,
                        RemoveInactiveChannelsAfterXMinutes = 30,
                        NumberOfAllowedConections = -1,
                        Endpoint = CreateIPEndpoint(uri)
                    };
                }
                return _settings;
            }
        }
    }
}