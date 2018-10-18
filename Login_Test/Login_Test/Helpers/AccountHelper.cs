using Login_Test.Models;
using Newtonsoft.Json;
using System.Web;
using System.Web.Security;

namespace Login_Test.Helpers
{
    public class AccountHelper
    {
        public static string Name
        {
            get
            {
                var userData = GetUserData();
                return userData != null ? userData.Name : string.Empty;
            }
        }

        public static string Company
        {
            get
            {
                var userData = GetUserData();
                return userData != null ? userData.Company : string.Empty;
            }
        }

        public static UserData GetUserData()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // 先取得該使用者的 FormsIdentity
                FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
                // 再取出該使用者的 FormsAuthenticationTicket
                FormsAuthenticationTicket ticket = id.Ticket;
                var userData = JsonConvert.DeserializeObject<UserData>(id.Ticket.UserData);

                return userData;
            }
            return null;
        }
    }
}