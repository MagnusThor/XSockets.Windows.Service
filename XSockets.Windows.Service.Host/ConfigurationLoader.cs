using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using XSockets.Core.Common.Configuration;
using XSockets.Plugin.Framework.Core.Attributes;

namespace XSockets.Windows.Service.Host
{
    /// <summary>
    /// Get the XSockets.NET Server configuration
    /// </summary>
    [Export(typeof(IConfigurationLoader))]
    public class ConfigurationLoader : IConfigurationLoader
    {
        public IConfigurationSettings _settings = null;

        public Uri GetUri(string location)
        {
            try
            {
                return new Uri(location);
            }
            catch (Exception)
            {

                return new Uri(string.Format("ws://{0}", location));
            }

        }

        /// <summary>
        /// Get server settings from config file.
        /// </summary>
        public IConfigurationSettings ConfigurationSettings
        {
            get
            {
                if (this._settings == null)
                {
                    var uri = GetUri(ConfigurationManager.AppSettings["XSockets.Url"]);

                    this._settings = new XSockets.Core.Configuration.ConfigurationSettings
                    {
                        Port = uri.Port,
                        Origin = new HashSet<string>(ConfigurationManager.AppSettings["XSockets.Origins"].Split(',').ToArray()),
                        Location = uri.Host,
                        Scheme = uri.Scheme,
                        Uri = uri,
                        BufferSize = 8192,
                        RemoveInactiveStorageAfterXDays = 7,
                        RemoveInactiveChannelsAfterXMinutes = 30,
                        NumberOfAllowedConections = -1
                    };
                }
                return this._settings;
            }
        }
    }
}