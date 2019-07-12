using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapiOfChatRoom.ViewModels
{
    public class ViewModelChatUserMessage
    {
        public int UserID { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }
        // <summary>
        /// 转让后的群主所在账号
        /// </summary>
        public string TransferManagerUserAccount { get; set; }

        // <summary>
        /// 设置管理员的账号
        /// </summary>
        public string Administrator { get; set; }
        /// <summary>
        /// 用户头像编号
        /// </summary>
        public string HeadImageNumber { get; set; }

        /// <summary>
        /// 用户状态(0代表不在线，1代表在线)
        /// </summary>
        public int UserState { get; set; }
        /// <summary>
        /// 用户权限(0代表无任何权限，1代表管理员权限，2代表群主权限)
        /// </summary>
        public string UserPermission { get; set; }
    }
}