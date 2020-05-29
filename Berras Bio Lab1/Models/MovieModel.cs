
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berras_Bio_Lab1.Models
{
    public class MovieModel
    {
        public int MovieModelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RunTime { get; set; }
        [Required]
        public string Category { get; set; }
        public ICollection<ViewingModel> viewings { get; set; }
    }
}
