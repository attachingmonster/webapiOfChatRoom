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
    public class TransferGroupManagerController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostTransferGroupManager")]
        public ViewModelInformation TransferGroupManager(ViewModelChatUserMessage viewModelChatUserMessage)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {

                viewModelInformation = new ViewModelInformation();
                var sysUser = unitOfWork.ChatRoomUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelChatUserMessage.UserAccount)).FirstOrDefault();
                sysUser.UserPermission = "0";
                unitOfWork.ChatRoomUserRepository.Update(sysUser);
                unitOfWork.Save();

                var user = unitOfWork.ChatRoomUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelChatUserMessage.TransferManagerUserAccount)).FirstOrDefault();
                user.UserPermission = "2";
                unitOfWork.ChatRoomUserRepository.Update(user);//保存状态
                unitOfWork.Save();
                throw new Exception("转让群主给"+" "+ viewModelChatUserMessage.TransferManagerUserAccount+" "+"成功");
            }
            catch (Exception ex)
            {
                viewModelInformation.Message = ex.Message;
                return viewModelInformation;
            }
        }

    }
}
