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
    public class DataModelReturnController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpGet]
        [ActionName("GetDataModel")]
        public List<ViewModelDataReturn> ViewModelData()
        {
            var data = (from us in unitOfWork.DataModelRepository.Get()
                        select new ViewModelDataReturn { UserAccount = us.UserAccount, Message = us.Message }).ToList();
            return data;
        }
    }
}
