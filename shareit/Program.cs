using shareitLib;
var config = new ConfigurationBuilder().AddCommandLine(args).Build();
if (string.IsNullOrEmpty(config.GetValue<string>("help")) || string.IsNullOrWhiteSpace(config.GetValue<string>("h")))
{
    Console.WriteLine("Usos para: shareit [OPCIONES]");
    Console.WriteLine("Opciones:");
    Console.WriteLine("  --help, --h\tMuestra este mensaje de ayuda");
    Console.WriteLine("  --input, --i\tEspecifica el archivo para compartir");
    Console.WriteLine("  --folder, --f\tEspecifica el directorio para compartir");
    Console.WriteLine("  --ip\tEspecifica la dirección IP en la que escuchar (predeterminada: $(hostname -I | cut -d' ' -f1))");
    Console.WriteLine("  --port\tEspecifica el puerto en el que escuchar (predeterminado: 8080)");
    return;
}

string input = config.GetValue<string>("input") ?? config.GetValue<string>("i");
string folder = config.GetValue<string>("folder") ?? config.GetValue<string>("f");
string ip = config.GetValue<string>("ip", Util.GetIPAddress().ToString());
int port = config.GetValue<int>("port", 8080);
Console.WriteLine("Ruta : http://{0}:{1}\nCompartiendo: \"{2}\"", ip, port, input ?? folder);

shareitLib.Share sr = new Share();
if (!string.IsNullOrEmpty(input))
{
    await sr.shareFile(input, ip, port.ToString());
}
else if (!string.IsNullOrEmpty(folder))
{
    sr.shareFolder(folder, ip, port.ToString());
}
else
{
    Console.WriteLine("No hay nada que compartir");
    return;
}