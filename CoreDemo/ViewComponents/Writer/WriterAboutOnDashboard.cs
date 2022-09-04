﻿using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
      
        Context c = new Context();

       

        public   IViewComponentResult Invoke()
        {
         
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();
            ViewBag.mail = usermail;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterByID(writerID);

            return View(values);
        }
    }
}
