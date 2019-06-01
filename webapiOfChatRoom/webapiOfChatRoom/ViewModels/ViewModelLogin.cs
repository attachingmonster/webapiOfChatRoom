using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapiOfChatRoom.ViewModels
{
    public class ViewModelLogin
    {
        /// <summary>
        /// 登录界面的信息
        /// </summary>
        public String Account { get; set; }

        public String Password { get; set; }
        public String RememberPassword { get; set; }
    }
}