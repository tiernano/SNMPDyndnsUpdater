using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SNMPDyndnsUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new List<Variable>();

            string ifaceIPs = "1.3.6.1.2.1.4.20.1.1";
            //.3.6.1.2.1.4.20.1.2
            string ifaceNumbers = "1.3.6.1.2.1.4.20.1.2";

            string ifaceNames = "1.3.6.1.2.1.2.2.1.2";

            Dictionary<string, string> ipAddresses = new Dictionary<string, string>();
            
            var data = Messenger.WalkAsync(VersionCode.V1,
                        new IPEndPoint(IPAddress.Parse("192.168.1.249"), 161),
                        new OctetString("public"),
                        new ObjectIdentifier(ifaceIPs),
                        result,
                        60000,
                        WalkMode.WithinSubtree).Result;

            foreach (var x in result)
            {
                Console.WriteLine("{0} - {1}", x.Id, x.Data);
                string identifier = ifaceNumbers + "." + x.Data;

                var ifaceId = Messenger.GetAsync(VersionCode.V1,
                    new IPEndPoint(IPAddress.Parse("192.168.1.249"), 161),
                        new OctetString("public"),
                        new List<Variable> { new Variable(new ObjectIdentifier(identifier)) }).Result.First().Data.ToString();
                
                string ifnaceNameId = ifaceNames + "." + ifaceId;

                var ifacenameData = Messenger.GetAsync(VersionCode.V1,
                    new IPEndPoint(IPAddress.Parse("192.168.1.249"), 161),
                        new OctetString("public"),
                        new List<Variable> { new Variable(new ObjectIdentifier(ifnaceNameId)) }).Result.First().Data.ToString();

                Console.WriteLine("Iface: {0} IP: {1}", ifacenameData, x.Data);

            }
            

            Console.ReadLine();
        }
    }
}
