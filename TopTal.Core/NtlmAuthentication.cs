using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using TopTal.Core;
using TopTal.Core.Models;

namespace TopTal.Utilities
{
    public class NtlmAuthentication
    {
        AutoItX3 _autoIT;

        public NtlmAuthentication()
        {
            _autoIT = new AutoItX3();
        }

        public void InsertCredenntialsAndLogin(string login, string password)
        {
             _autoIT.WinWait("Требуется Аутентификация", "Welcome to Toptal", 10);
             _autoIT.WinActivate("Authentication Required");

            _autoIT.Send(login); 
            _autoIT.Send("{TAB}");

            _autoIT.Send(password);
            _autoIT.Send("{ENTER}");
        }

    }
}
