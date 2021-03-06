﻿using Anagram.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Core
{
    public interface IUserLogRepository
    {
        void AddUserLog(UserLogFull userLog);
        List<UserLogFull> GetUserLogs();
        int CountActionsByIP(string ip_address, string action);
    }
}
