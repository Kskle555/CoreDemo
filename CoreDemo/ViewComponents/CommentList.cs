using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                 new UserComment
                {
                    ID = 1,
                    Username="Oguzhan"
                }, 
                
                new UserComment
                {
                    ID = 2,
                    Username="Yagmur"
                },

                 new UserComment
                {
                    ID = 3,
                    Username="Kskle"
                },
            };
               
               
        
            return View(commentValues);
        }
    }
}
