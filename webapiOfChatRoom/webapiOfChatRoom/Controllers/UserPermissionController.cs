using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapiOfChatRoom.DAL;
using webapiOfChatRoom.ViewModels;

namespace webapiOfChatRoom.Controllers
{
    public class UserPermissionController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostUserPermission")]
        public ViewModelInformation UserPermission(ViewModelLogin viewModelLogin)
        {
            ViewModelInformation viewModelInformation = null;
            viewModelInformation = new ViewModelInformation();
            var sysUser = unitOfWork.ChatRoomUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelLogin.Account)).FirstOrDefault();
            viewModelInformation.Message = sysUser.UserPermission;
            return viewModelInformation;
        }
    }
}
