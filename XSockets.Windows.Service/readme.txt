
================================================
This is an simple example that shows how to run XSockets.NET as 
Windows Service.  

After successfull build Install the service by using the InstalUtil.exe


Register (install) the service:

InstallUtil.exe XSockets.Windows.Service.exe

Unregister (Uninstall) the service

InstallUtil.exe XSockets.Windows.Service.exe /u

================================================

Note:

Do you have dependencies on external assemblies in your "controllers"?
You must then make sure to refer them to in the XSockets.Windows.Service 
project as this is the "host" of the plugin (controller)

To change configuration settings such as endpoint (location of your XSockets Service)
then apply your changes to "XSockets.Windows.Service.Configuration"

The example configuration is defined to answer on the following url;

ws://127.0.0.1:9090/Generic

As we included the XSockets.Extensibility.Handlers plugin you will be able
to use the "Generic" Controller.   Just remove that assebly from the references to disable that functionallity.

================================================

Kind regards
	Team XSockets.NET