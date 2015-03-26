using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TopTal.Core.Models;

namespace TopTal.Core
{
    public static class ConfigurationProvider
    {
        public static Credentials GetLoginCredentials()
        {
            XDocument xml = XDocument.Load("./config.xml");


            var credentials = (from e in xml.Root.Elements("authorization")
                               let l = e.Element("login")
                               let p = e.Element("password")

                               select new Credentials
                               {
                                   Login = l.Value,
                                   Password = p.Value,
                               });

            return new Credentials()
            {
                Login = credentials.First().Login,
                Password = credentials.First().Password
            };
        }

        public static HostConfigs GetHostConfigurations()
        {
            XDocument xml = XDocument.Load("./config.xml");

            var hostConfigs = (from e in xml.Root.Elements("host")
                               let u = e.Element("url")
                               let l = e.Element("login")
                               let p = e.Element("password")

                               select new HostConfigs
                               {
                                   Login = l.Value,
                                   Password = p.Value,
                                   Url = u.Value
                               });
            
            return new HostConfigs()
            {
                Login = hostConfigs.First().Login,
                Password = hostConfigs.First().Password,
                Url = hostConfigs.First().Url
            };
        }
    }
}
