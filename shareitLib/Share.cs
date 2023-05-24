using System.Net;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
namespace shareitLib;

public class Share
{
    const string icon = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAq9QTFRFAAAAkFqhkFqij1qhf0mXgUuYgEqXk1ifSxNwgUqYgEqYiVSdkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkVqhkFqhkFqhkFqhkFugkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkFqhkVmgkFqhkFqhkFqhkFqhjligkFqhg02Zf0mXgEqXf0mXf0mXgEmXf0mXgEqYkFqif0mXhlKbf0mXgEqXf0mXgUuYkFqhf0mXf0qXf0mXf0mXf0mXf0mXgUuZf0mXkFqhf0mXgUuYkVqggEqXhE2akFqhiVOdgEqYgEmXgUqYkFqhkFqhkFqhkVuhiFOckFqhjligjlefj1igj1mhlGCkr4i7v5/JrYW5k16jkFmhlmOmzrfW08DbvaHJ1sTdyrDSvJzGzrnXhVKcfEWVh1We0sDbr4q8jVefj1mgz7jXq4i7f0mXtpfEuZzGhE2a0rzZvKDJfUaVfUeWxazQspLBhlCbnm+ty7LT3Mzi3tDknnawu57I2Mffj2CkfkiWmGaooHKvmWepjlegl2Sn3c3jjFuhl2uqxq7R18bfw6rOlGeot5TC28rh1MLcvZ3Hsoy92sjgyrTUl2urfkeWg06afkiXqX+23M3inHOvhFCbmGyrpH61gUyZy7HTupzHfEWUspHAwqnOspLAw6nOqH623c7jnXSvmG2rpX+2tJDAsZC/zbjWlGKlk2WniVefh1Sd2cngv6TLyLHT1sXelWipiVOdgEqXwafN2svh3c/ktZbDnXSwt5nF2MjfkGGlilSegEqYy7XVvJ/IxKvPrIi7uZvGiFaepoC3f0iXxa3Q1cPd18bewqjNg0+bg0+ao3y0tpfDoHiygk2ZfUaWgUuY////xe2OYQAAAF50Uk5TAAAAAAAAAAAAAAAAAx9ThairCUea1vbXm0gIATnzNgFq5eMNjvf7OuQ3p/JGAZUBIFSEd5mqqqqcefZW2CEBmAL0SKUI4uM2+Gz7jgoNaeQKATUBRdeYRwl4mZgfA9qZF9AAAAABYktHROQvYjspAAAACXBIWXMAAA7EAAAOxAGVKw4bAAACQUlEQVQ4y2NggAFGHl4+fgFBQQF+Pl4eRgZ0wCgkLCIqFgcGYuISklKoShilZQRl45CArICcPCOydgXFODSgpCAEV8GorKIahwFUVZShKhilVNRQ5eITEoGkmgrEDEYmBVT9SckpqWnpGUAzFJhBKhjVNVDkMzKzsnNy85KBTA1NRpADBVHNT8wvKCwqLiktA7K1gL5llJRFVVBeUVlUVVRdU5sUF6etw8igK4Imn1FXX9TQ2NTc0AJUoafPYCAKs7scKJCR2NrW3lHd2dXd01sFVCHKy2AIDd/yvv4J5RMnpU7OmTJ12vQZM3urqoAqxPgYjKAGzJo9Z/bcefMXLOztXVS1eMmiqiqwCmMGAYjTly5bvmJlR8eq1RAZGGgxYTCFKFiztqhq3foNRVVowAymIA+kYOMmDAXmMCs2b9m6YltHx3Y0K6os4I7c0V0yfef2Obu2gR1ZBVNnifDm7j17exv2rd9/YMrKg4emHe4Fy1tZIwXUkaNVVUsae44dP3Hy1OkzZ8EqbGwZ7BBBfe48UKi398LFooaGS80NIAX2DiiRBVFx8DIosq6AFDg6sQDTk1YciorG9QWFjVfnXAMpcHZhBSYIOVcUFdcLb9xccOv2HaC8mzsbKEWxIyc5oIreu/fuP3i4pKrKw5ODFTPRgmx51NAI1O/l7cOJLdmDXQoEHt6+LIiM46eIrsLfM4AVKWsFymkh+fZxlaNzUDAnWuYN0ROHZd7QsPAILsz8zcNrGBklKBgdaRgTyw0XBgCjY16uTzs2mQAAACV0RVh0ZGF0ZTpjcmVhdGUAMjAxOS0wNC0wOVQxMjo0MDowOSswMTowMICvGzoAAAAldEVYdGRhdGU6bW9kaWZ5ADIwMTktMDQtMDlUMTI6NDA6MDkrMDE6MDDx8qOGAAAARnRFWHRzb2Z0d2FyZQBJbWFnZU1hZ2ljayA2LjcuOC05IDIwMTktMDItMDEgUTE2IGh0dHA6Ly93d3cuaW1hZ2VtYWdpY2sub3JnQXviyAAAABh0RVh0VGh1bWI6OkRvY3VtZW50OjpQYWdlcwAxp/+7LwAAABh0RVh0VGh1bWI6OkltYWdlOjpoZWlnaHQANTEywNBQUQAAABd0RVh0VGh1bWI6OkltYWdlOjpXaWR0aAA1MTIcfAPcAAAAGXRFWHRUaHVtYjo6TWltZXR5cGUAaW1hZ2UvcG5nP7JWTgAAABd0RVh0VGh1bWI6Ok1UaW1lADE1NTQ4MTAwMDkvwnqoAAAAE3RFWHRUaHVtYjo6U2l6ZQAyOS4zS0JClj8uAgAAAE90RVh0VGh1bWI6OlVSSQBmaWxlOi8vLi91cGxvYWRzLzU2LzQ3Q1ZoeGgvMTg4MC9pY29uZmluZGVyLXNoYXJlLTQzNDEzMjNfMTIwNTQ2LnBuZ38H+t8AAAAASUVORK5CYII=";

    public async Task shareFile(string fileShare, string ipAddress = "", string port = "")
    {
        string ipLAN = ipAddress;
        string puerto = port;
        if (string.IsNullOrEmpty(ipAddress))
            ipLAN = Util.GetIPAddress().ToString();
        if (string.IsNullOrEmpty(port))
            puerto = "8080";

        var fileInfo = new FileInfo(fileShare);
        string ruta = string.Format("http://{0}:{1}", ipLAN, puerto);
        Console.WriteLine("El url compartir: {0}/{1}", ruta, fileInfo.Name);

        var host = new WebHostBuilder().UseKestrel().UseUrls(ruta).Configure(app =>
        {
            app.Map( "/" + fileInfo.Name, app =>
            {
                app.Run(async context =>
                {
                    var file = fileShare;
                    var fileName = Path.GetFileName(file);

                    if (!File.Exists(file))
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        return;
                    }

                    var provider = new FileExtensionContentTypeProvider();
                    if (!provider.TryGetContentType(file, out var mimeType))
                    {
                        mimeType = "application/octet-stream";
                    }

                    context.Response.ContentType = mimeType;
                    context.Response.ContentLength = new FileInfo(file).Length;

                    using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        await stream.CopyToAsync(context.Response.Body);
                    }
                });
            });
        }).Build();
        await host.RunAsync();
    }

    public void shareFolder(string folderPath, string ipAddress = "", string port = "")
    {
        var directoryPath = folderPath;
        var prefix = string.Format("http://{0}:{1}/", ipAddress, port);

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine($"La carpeta no existe: {directoryPath}");
            return;
        }

        var listener = new HttpListener();
        listener.Prefixes.Add(prefix);
        listener.Start();
        Console.WriteLine($"Servidor iniciado en {prefix}");

        while (true)
        {
            var context = listener.GetContext();
            var request = context.Request;
            var response = context.Response;
            if (request.HttpMethod == "GET")
            {
                var path = request.Url.AbsolutePath;

                if (path.EndsWith("/"))
                {
                    response.ContentType = "text/html";
                    using (var writer = new StreamWriter(response.OutputStream))
                    {
                        var files = Directory.GetFiles(directoryPath);
                        int count = 1;
                        writer.WriteLine("<!DOCTYPE html>");
                        writer.WriteLine("<html>");
                        writer.WriteLine("<head>");
                        writer.WriteLine("<meta charset=\"UTF-8\">");
                        writer.WriteLine("<title>Compartir Archivos</title>");
                        writer.WriteLine($"<link rel=\"icon\" href=\"{icon}\">");
                        writer.WriteLine("<style>");
                        writer.WriteLine("body { font-family: Arial, sans-serif; background-color: #f8f8f8; }");
                        writer.WriteLine("h1 { color: #333; text-align: center; }");
                        writer.WriteLine(".table-container { margin: 20px auto; width: 80%; }");
                        writer.WriteLine(".table-container table { border-collapse: collapse; width: 100%; }");
                        writer.WriteLine(".table-container th, .table-container td { border: 1px solid #ddd; padding: 12px; text-align: center; }");
                        writer.WriteLine(".table-container th { background-color: #333; color: white; }");
                        writer.WriteLine(".table-container tr:nth-child(even) { background-color: #f2f2f2; }");
                        writer.WriteLine(".table-container a { color: #333; text-decoration: none; }");
                        writer.WriteLine(".table-container a:hover { color: #f00; }");
                        writer.WriteLine("</style>");

                        writer.WriteLine("</head>");
                        writer.WriteLine("<body>");
                        writer.WriteLine("<h1>Compartir Archivos</h1>");

                        writer.WriteLine("<div class=\"table-container\">");
                        writer.WriteLine("<table>");
                        writer.WriteLine("<thead>");
                        writer.WriteLine("<tr>");
                        writer.WriteLine("<th>#</th>");
                        writer.WriteLine("<th>Nombre de archivo</th>");
                        writer.WriteLine("<th>Tamaño</th>");
                        writer.WriteLine("<th>Fecha de creación</th>");
                        writer.WriteLine("</tr>");
                        writer.WriteLine("</thead>");

                        writer.WriteLine("<tbody>");
                        foreach (var file in files)
                        {
                            var fileInfo = new FileInfo(file);
                            writer.WriteLine("<tr>");
                            writer.WriteLine("<td>" + count++ + "</td>");
                            writer.WriteLine("<td><a href=\"" + fileInfo.Name + "\">" + fileInfo.Name + "</a></td>");
                            double Mb = (double)fileInfo.Length / 1048576;
                            writer.WriteLine("<td>" + Mb.ToString("F2") + " MB</td>");
                            writer.WriteLine("<td>" + fileInfo.CreationTime + "</td>");
                            writer.WriteLine("</tr>");
                        }

                        writer.WriteLine("</tbody>");
                        writer.WriteLine("</table>");
                        writer.WriteLine("</div>");

                        writer.WriteLine("</body>");
                        writer.WriteLine("</html>");
                    }
                }

                var filePath = Path.Combine(directoryPath, HttpUtility.UrlDecode(path.TrimStart('/')));
                if (File.Exists(filePath))
                {
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var buffer = new byte[5000000];
                    var responseStream = response.OutputStream;

                    var provider = new FileExtensionContentTypeProvider();
                    if (!provider.TryGetContentType(filePath, out var mimeType))
                    {
                        mimeType = "application/octet-stream";
                    }
                    response.ContentType = mimeType;

                    while (true)
                    {
                        var bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                        if (bytesRead == 0)
                        {
                            break;
                        }
                        try
                        {
                            responseStream.Write(buffer, 0, bytesRead);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }

                    fileStream.Close();
                    responseStream.Close();
                }
                else
                {
                    Console.WriteLine("No encontrado {0}", HttpUtility.UrlDecode(filePath));
                    //response.StatusCode = 404;
                    //response.Close();
                }
            }
            else
            {
                response.StatusCode = 405;
                Console.Error.WriteLine("Statuscode: {0}",response.StatusCode);
                response.Close();
            }
        }
    }
}
