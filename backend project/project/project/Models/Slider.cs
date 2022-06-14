using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string Image { get; set; }
        [StringLength(maximumLength: 20)]
        public string Titles { get; set; }
        [StringLength(maximumLength: 20)]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string More { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
