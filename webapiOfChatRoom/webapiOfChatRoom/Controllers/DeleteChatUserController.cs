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
    public class DeleteChatUserController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostDeleteChatUser")]
        public ViewModelInformation DeleteChatUser(ViewModelChatUserMessage viewModelChatUserMessage)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {
                viewModelInformation = new ViewModelInformation();
                var user = unitOfWork.ChatRoomUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelChatUserMessage.DeleteChatUserAccount)).FirstOrDefault();
                unitOfWork.ChatRoomUserRepository.Delete(user);
                unitOfWork.Save();
                throw new Exception("成功将" + " " + viewModelChatUserMessage.DeleteChatUserAccount + " " + "请出群聊");

            }
            catch (Exception ex)
            {
                viewModelInformation.Message = ex.Message;
                return viewModelInformation;
            }
        }
    }
}
