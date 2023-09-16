using EnisBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using MiracleTransportathon.BusinessLayer.Concrete;
using System.Net.Http;

namespace MiracleTransportathon.WebUI.ViewComponents.User
{
    [ViewComponent(Name = "_HeadPartial")]
    public class _HeadPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
        //private readonly MessageManager _messageManager;

        //public _HeadPartial(EfMessageDal messageDal)
        //{
        //    _messageManager = new MessageManager(messageDal);
        //}

        //public IViewComponentResult Invoke()
        //{
        //    string userEmail = "deneme@gmail.com"; // Kullanıcı e-posta adresi
        //    var inboxMessages = _messageManager.GetInboxListByUser(userEmail);
        //    return View(inboxMessages);
        //}



        //private readonly EfMessageDal _messageDal;

        //MessageManager mm = new MessageManager(new EfMessageDal());

        //public UserMessageNotification(EfMessageDal messageDal)
        //{
        //    _messageDal = messageDal;
        //}

        //public IViewComponentResult Invoke()
        //{
        //    string p = "deneme@gmail.com";
        //    var values = _messageDal.GetInboxListByUser(p);
        //    return View(values);
        //}


        //MessageManager mm = new MessageManager(new EfMessageDal());

        ////private readonly EfMessageDal _messageDal;

        //public IViewComponentResult Invoke()
        //{
        //    string p;
        //    p = "deneme@gmail.com";
        //    var values = mm.GetInboxListByUser(p);
        //    return View(values);
        //}


    }
}
