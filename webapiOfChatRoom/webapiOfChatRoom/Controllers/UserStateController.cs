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
    public class UserStateController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostUserState")]
        public ViewModelInformation ChangeUserState(ViewModelLogin viewModelLogin)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {
                viewModelInformation = new ViewModelInformation();
                var user = unitOfWork.SysUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelLogin.Account)).FirstOrDefault();
                user.UserState = 1;
                unitOfWork.Save();
                throw new Exception("更新用户状态成功");
            }
            catch (Exception ex)
            {
                viewModelInformation.Message = ex.Message;
                return viewModelInformation;
            }

        }
    }
}
