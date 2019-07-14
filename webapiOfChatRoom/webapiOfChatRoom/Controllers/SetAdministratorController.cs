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
    public class SetAdministratorController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostSetAdministrator")]
        public ViewModelInformation SetAdministrator(ViewModelChatUserMessage viewModelChatUserMessage)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {
                viewModelInformation = new ViewModelInformation();
                var sysUser = unitOfWork.ChatRoomUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelChatUserMessage.Administrator)).FirstOrDefault();
                sysUser.UserPermission = "1";
                unitOfWork.ChatRoomUserRepository.Update(sysUser);
                unitOfWork.Save();
                throw new Exception("设置" + " " + viewModelChatUserMessage.Administrator + " " + "为管理员成功");
            }
            catch (Exception ex)
            {
                viewModelInformation.Message = ex.Message;
                return viewModelInformation;
            }

        }
    }
}
