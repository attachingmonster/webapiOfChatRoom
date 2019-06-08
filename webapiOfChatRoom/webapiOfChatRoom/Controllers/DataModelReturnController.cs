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
    public class DataModelReturnController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostDataModelReturn")]
        public List<ViewModelDataReturn> DataModelReturn(ViewModel viewModel)
        {
            var data = (from us in unitOfWork.DataModelRepository.Get()
                        select new ViewModelDataReturn { UserAccount = us.UserAccount, Message = us.Message }).ToList();
            return data;
        }
          

    }
}
