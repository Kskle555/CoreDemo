using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{

    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writername;
            return View();
        }


        public IActionResult WriterProfile()
        {
            return View();
        }

        [Authorize]
        public IActionResult WriterMail()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbar()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooter()
        {
            return PartialView();
        }

        
        [HttpGet]
        public async Task< IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
            model.mail = values.Email;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
           // Context c = new Context();
           // var username = User.Identity.Name;
           // var usermail = c.Users.Where(x=>x.UserName==username).Select(y => y.Email).FirstOrDefault();
           //var id = c.Users.Where(x=>x.Email==usermail).Select(y => y.Id).FirstOrDefault();
           // var values = userManager.TGetById(id);
           // return View(values);
           return View(model);
        }
      
        [HttpPost]
        public async Task< IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PasswordHash=_userManager.PasswordHasher.HashPassword(values,model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage!=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/WriterImageFiles/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;

            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
       
    }
}
