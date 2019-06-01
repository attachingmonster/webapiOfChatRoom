using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapiOfChatRoom.DAL;
using webapiOfChatRoom.Methods;
using webapiOfChatRoom.ViewModels;

namespace webapiOfChatRoom.Controllers
{
    public class ChangePswController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostChangePsw")]
        public ViewModelInformation ChangePsw(ViewModelChangePsw viewModelChangePsw)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {
                viewModelInformation = new ViewModelInformation();
                string OldPassword = CreateMD5.EncryptWithMD5(viewModelChangePsw.OldPassword);     //原密码
                string NewPassword = CreateMD5.EncryptWithMD5(viewModelChangePsw.NewPassword);     //新密码

                var u = unitOfWork.SysUserRepository.Get().Where(s => s.UserAccount.Equals(viewModelChangePsw.Account.Trim()) && s.UserPassword.ToLower().Equals(viewModelChangePsw.OldPassword)).FirstOrDefault();//账号是否存在与密码是否相等
                if (u != null)
                {
                    u.UserPassword = viewModelChangePsw.NewPassword;
                    unitOfWork.SysUserRepository.Update(u);//更改密码
                    unitOfWork.Save();
                    throw new Exception("修改成功！");
                }
                else
                {
                    throw new Exception("用户名不存在或原密码输入错误！");
                }

            }
            catch (Exception ex)
            {
                viewModelInformation.Message = ex.Message;
                return viewModelInformation;
            }

        }
    }
}
