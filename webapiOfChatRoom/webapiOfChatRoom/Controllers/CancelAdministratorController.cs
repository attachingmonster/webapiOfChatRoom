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
    public class CancelAdministratorController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostCancelAdministrator")]
        public ViewModelInformation CancelAdministrator(ViewModelChatUserMessage viewModelChatUserMessage)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {
                viewModelInformation = new ViewModelInformation();
                var sysUser = unitOfWork.ChatRoomUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelChatUserMessage.Administrator)).FirstOrDefault();
                sysUser.UserPermission = "0";
                unitOfWork.ChatRoomUserRepository.Update(sysUser);
                unitOfWork.Save();
                throw new Exception("取消" + " " + viewModelChatUserMessage.Administrator + " " + "的管理员身份成功");

            }
            catch (Exception ex)
            {
                viewModelInformation.Message = ex.Message;
                return viewModelInformation;
            }
        }
    }
}
