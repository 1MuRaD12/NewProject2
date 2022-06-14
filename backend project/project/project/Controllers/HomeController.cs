using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.DAL;
using project.Models;
using project.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {

            HomeVM homeVM = new HomeVM
            {
                Information = await context.Information.ToListAsync(),
                details = await context.details.ToListAsync()
            };
            return View(homeVM);
        }
    }
}
