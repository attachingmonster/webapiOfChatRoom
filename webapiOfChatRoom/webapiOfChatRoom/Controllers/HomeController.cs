using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapiOfChatRoom.DAL;

namespace webapiOfChatRoom.Controllers
{
    public class HomeController : Controller
    {
        private AccountContext db = new AccountContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            var user = unitOfWork.ChatRoomUserRepository.Get();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
