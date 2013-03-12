using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework.Core.Attributes;
using XSockets.Plugin.Framework.Helpers;

namespace XSockets.Windows.Service.Host
{
    public class Instance
    {
        [ImportOne(typeof(IXBaseServerContainer))]
        public IXBaseServerContainer wss { get; set; }

        public Instance()
        {
            this.ComposeMe();
            wss.StartServers();
        }
    }
}
