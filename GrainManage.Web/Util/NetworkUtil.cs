using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Web.Util
{
    public class NetworkUtil
    {
        /// <summary>
        /// 获取本机所有IPv4地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIP()
        {
            string hostName = Dns.GetHostName();    //得到计算机名  
            var ipEntry = Dns.GetHostEntry(hostName); //得到本机IP地址数组  
            return ipEntry.AddressList.Where(f => f.AddressFamily == AddressFamily.InterNetwork).Select(s => s.ToString()).ToList();
        }
        /// <summary>
        /// 获取本机所有IPv4网关地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetGateway()
        {
            var gatewayList = new List<string>();
            foreach (var netWork in NetworkInterface.GetAllNetworkInterfaces())    //获取所有网卡  
            {
                var ipProperties = netWork.GetIPProperties();   //单个网卡的IP对象  
                foreach (var gateWay in ipProperties.GatewayAddresses)  //获取该IP对象的网关  
                {
                    if (gateWay.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        gatewayList.Add(gateWay.Address.ToString());   //得到网关地址  
                    }
                }
            }
            return gatewayList;
        }
        public static bool Ping(string ip)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(ip, 1000);
            return reply != null && reply.Status == IPStatus.Success;
        }
    }
}
