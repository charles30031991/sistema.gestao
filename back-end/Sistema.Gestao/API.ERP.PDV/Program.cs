using Sistema.Gestao.API.Helper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Net;
using System.Net.Sockets;

namespace Sistema.Gestao.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static string RetornarEnderecoIpLocal()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("nenhum adaptador com um endereço IPv4 foi encontrado no sistema!");
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var ip = RetornarEnderecoIpLocal();
            var hostUrl = $"http://{ip}:5000";

            return WebHost.CreateDefaultBuilder(args)
                     .UseUrls(hostUrl)
                    .UseStartup<Startup>();
        }
    }
}
