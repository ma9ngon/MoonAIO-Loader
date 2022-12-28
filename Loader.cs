using System;
using System.IO;
using System.Net;
using System.Reflection;
using EnsoulSharp.SDK;

namespace Main
{
    internal class MoonAIO
    {
        private static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }

        private static void OnGameLoad()
        {
            LoadAssembly("https://raw.githubusercontent.com/moonsharpisnotreal/moon321/main/MoonInvoker.exe", "Loader");
        }

        private static void LoadAssembly(string line, string type)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                byte[] load = new System.Net.WebClient().DownloadData(line);
                Assembly assembly = Assembly.Load(load);
                if (assembly != null)
                {
                    if (assembly.EntryPoint != null)
                    {
                        assembly.EntryPoint.Invoke(null, new object[]
                        {
                            new string[1]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}