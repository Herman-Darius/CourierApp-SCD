using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementUI_CourierApp.Services
{
    public static class AuthTokenService
    {
        private static string _token;

        public static string Token
        {
            get => _token;
            set => _token = value;
        }

        public static bool IsAuthenticated => !string.IsNullOrEmpty(_token);

        public static void ClearToken()
        {
            _token = null;
        }
    }
}
