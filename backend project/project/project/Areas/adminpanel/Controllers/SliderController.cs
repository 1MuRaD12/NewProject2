using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.DAL;
using project.Extent;
using project.Models;
using project.Utilits;
using project.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace project.Areas.adminpanel.Controllers
{
    [Area("adminpanel")]

    public class SliderController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment web;

        public SliderController(AppDbContext context, IWebHostEnvironment web)
        {
            this.context = context;
            this.web = web;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                sliders = await context.sliders.ToListAsync()
            };
            return View(homeVM);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if (slider.Photo != null)
            {
                if (!slider.Photo.Isexsted(1))
                {
                    ModelState.AddModelError("Photo", "Plase choose sported file");
                    return View();
                }

                string filestream = await slider.Photo.FileCreate(web.WebRootPath, @"C:\Users\User\Desktop\Newproject1\backend project\project\project\wwwroot\assets\images\");
                slider.Image = filestream;
                await context.sliders.AddAsync(slider);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choos file");
                return View();
            }
        }
        public async Task<IActionResult> Detiel(int id)
        {
            Slider slider = await context.sliders.FirstOrDefaultAsync(d => d.Id == id);
            if (slider == null) return View();
            return View(slider);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Slider slider = await context.sliders.FirstOrDefaultAsync(d => d.Id == id);
            if (slider == null) return View();
            return View(slider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider sliders = await context.sliders.FirstOrDefaultAsync(d => d.Id == id);
            if (slider.Photo != null)
            {
                if (!slider.Photo.Isexsted(1))
                {
                    ModelState.AddModelError("Photo", "Plase choose sported file");
                    return View();
                }

                string file = web.WebRootPath + @"C:\Users\User\Desktop\Newproject1\backend project\project\project\wwwroot\assets\images\" + slider.Image;
                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                };
                sliders.Image = file;
                await context.sliders.AddAsync(slider);
               
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choos file");
                return View();
            }
            sliders.Title = slider.Title;
            sliders.Titles = slider.Titles;
            sliders.SubTitle = slider.SubTitle;
            sliders.More = slider.More;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await context.sliders.FirstOrDefaultAsync(d => d.Id == id);
            if (slider == null) return View();
            return View(slider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Deleted(int id)
        {

            Slider slider = await context.sliders.FirstOrDefaultAsync(d => d.Id == id);
            if (slider == null) return NotFound();

            context.sliders.Remove(slider);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
