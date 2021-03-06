﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace HUALI_NETLOGIN_Netim
{
    class Netim
    {
        public Netim(string user, string password)
        {
            Socket netpro = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            netpro.Connect(IPAddress.Parse("219.136.125.139"), 80);
            string ip = ((IPEndPoint)netpro.LocalEndPoint).Address.ToString();
            List<string> poststring1 = new List<string>
            {
                "wlanuserip="+ip,
                "&wlanacname=gzhlxy",
                "&chal_id=",
                "&chal_vector=",
                "&auth_type=PAP",
                "&seq_id=",
                "&req_id=",
                "&wlanacIp=183.56.17.19",
                "&ssid=",
                "&vlan=",
                "&mac=",
                "&message=",
                "&bank_acct=",
                "&isCookies=",
                "&version=0",
                "&authkey=gzhlxy",
                "&url=",
                "&usertime=0",
                "&listpasscode=0",
                "&listgetpass=0",
                "&getpasstype=0",
                "&randstr=",
                "&domain=GDHLXY",
                "&isRadiusProxy=false",
                "&usertype=0",
                "&isHaveNotice=0",
                "&times=12",
                "&weizhi=0",
                "&smsid=0",
                "&freeuser=",
                "&freepasswd=",
                "&listwxauth=0",
                "&templatetype=1",
                "&tname=5",
                "&logintype=0",
                "&act=",
                "&is189=true",
                "&terminalType=",
                "&useridtemp="+user,
                "&userid="+user+"%40GDHLXY",
                "&passwd="+password,
            };

            string postString = string.Empty;
            foreach (string adpat in poststring1)
            {
                postString = postString + adpat;
            };
            string url = "http://219.136.125.139/portalAuthAction.do";
            var postData = Encoding.UTF8.GetBytes(postString);
            WebClient data_post = new WebClient();//webclient模拟表单提交
            data_post.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            data_post.UploadData(url, "POST", postData);
        }
    }
}
