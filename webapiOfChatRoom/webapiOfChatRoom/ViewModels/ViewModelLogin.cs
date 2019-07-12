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

        /// <summary>
        /// 用户头像编号
        /// </summary>
        public string HeadImageNumber { get; set; }

        /// <summary>
        /// 用户状态(在线与否)
        /// </summary>
        public int UserState { get; set; }

        /// <summary>
        /// 用户权限(0代表无任何权限，1代表管理员权限，2代表群主权限)
        /// </summary>
        public string UserPermission { get; set; }
    }
}