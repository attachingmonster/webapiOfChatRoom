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
    public class UserListViewController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostUserListView")]
        public List<ViewModelChatUserMessage> UserListView(ViewModel viewModel)
        {

            var data = (from us in unitOfWork.ChatRoomUserRepository.Get()

                        select new ViewModelChatUserMessage {UserAccount = us.UserAccount, UserID =us.ID,UserPermission=us.UserPermission, HeadImageNumber = us.HeadImageNumber,UserState=us.UserState }).ToList();
            return data;

        }
    }
}
