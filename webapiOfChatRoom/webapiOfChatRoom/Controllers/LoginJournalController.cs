using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapiOfChatRoom.DAL;
using webapiOfChatRoom.Models;
using webapiOfChatRoom.ViewModels;

namespace webapiOfChatRoom.Controllers
{
    public class LoginJournalController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostLoginJournal")]
        public ViewModelInformation LoginJournal(ViewModelLoginJournal viewModelLoginJournal)
        {
            ViewModelInformation viewModelInformation = null;
            try
            {
                viewModelInformation = new ViewModelInformation();
                var sysUser = unitOfWork.LoginJournalRepository.Get().Where(s => s.UserAccount.Equals(viewModelLoginJournal.UserAccount)).FirstOrDefault();
                if (sysUser == null)
                {
                    var loginJournal = new LoginJournal();
                    loginJournal.UserAccount = viewModelLoginJournal.UserAccount;
                    loginJournal.MacAddress = viewModelLoginJournal.MacAddress;
                    unitOfWork.LoginJournalRepository.Insert(loginJournal);    //增加新LoginJournal
                    unitOfWork.Save();
                    throw new Exception("允许登录");
                }
                else
                {
                    if(sysUser.MacAddress== viewModelLoginJournal.MacAddress|| sysUser.MacAddress =="1111")
                    {
                        sysUser.MacAddress = viewModelLoginJournal.MacAddress;
                        unitOfWork.LoginJournalRepository.Update(sysUser);//更新用户的Mac地址
                        unitOfWork.Save();
                        throw new Exception("允许登录");
                    }
                    else
                    {
                        throw new Exception("您的账号已经在异地登录！");
                    }
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