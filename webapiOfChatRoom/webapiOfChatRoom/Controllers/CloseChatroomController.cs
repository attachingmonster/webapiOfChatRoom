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
    public class CloseChatroomController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostCloseChatroom")]
        public ViewModelInformation CloseChatroom(ViewModelLoginJournal viewModelLoginJournal)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {
                viewModelInformation = new ViewModelInformation();
                var sysUser = unitOfWork.LoginJournalRepository.Get().Where(s => s.UserAccount.Equals(viewModelLoginJournal.UserAccount)).FirstOrDefault();
                sysUser.MacAddress = viewModelLoginJournal.MacAddress;
                unitOfWork.LoginJournalRepository.Update(sysUser);//更改密码
                unitOfWork.Save();
                throw new Exception("关闭聊天界面信息传输成功");
            }
            catch (Exception ex)
            {
                viewModelInformation.Message = ex.Message;
                return viewModelInformation;
            }
        }

    }
}
