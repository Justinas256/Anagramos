using Anagram.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Web.Utils
{
    public class LogActivity
    {

        IUserLogService UsersLogService;

        public LogActivity(IUserLogService usersLogService)
        {
            UsersLogService = usersLogService;
        }

        public void LogWordViewed(string word)
        {
            string ip = GetIPAddress();
            DateTime time = GetTime();
            UsersLogService.AddNewLogView(ip, time, word);
        }

        public void LogWordAdded(string word)
        {
            string ip = GetIPAddress();
            DateTime time = GetTime();
            UsersLogService.AddNewLogAdded(ip, time, word);
        }

        public void LogWordUpdated(string word)
        {
            string ip = GetIPAddress();
            DateTime time = GetTime();
            UsersLogService.AddNewLogUpdated(ip, time, word);
        }

        public void LogWordDeleted(string word)
        {
            string ip = GetIPAddress();
            DateTime time = GetTime();
            UsersLogService.AddNewLogDeleted(ip, time, word);
        }

        public string GetIPAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
        }

        private DateTime GetTime()
        {
            return DateTime.Now; 
        }
    }
}