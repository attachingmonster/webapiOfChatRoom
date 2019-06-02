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
    public class DataModelController : ApiController
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [ActionName("PostDataModel")]
        public List<ViewModelDataReturn> DataModel(ViewModelData viewModelData)
        {
            //把从wpf传过来的数据信息加到DataModel表里
            var dataModel = new DataModel();
            dataModel.UserAccount = viewModelData.UserAccount;
            dataModel.Message= viewModelData.Message;   
            unitOfWork.DataModelRepository.Insert(dataModel);    //增加新DataModel
            unitOfWork.Save();
            //把DataModel表里的信息传回wpf
            var data = (from us in unitOfWork.DataModelRepository.Get()
                        select new ViewModelDataReturn { UserAccount = us.UserAccount, Message = us.Message}).ToList();
            return data;
        }

    }
}
