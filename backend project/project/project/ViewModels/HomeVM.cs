using project.Models;
using System.Collections.Generic;

namespace project.ViewModels
{
    public class HomeVM
    {
        public List<Details> details { get; set; }

        public List<Information> Information { get; set; }

        public List<Slider> sliders { get; set; }
    }
}
