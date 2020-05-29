
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berras_Bio_Lab1.Models
{
    public class ViewingModel
    {
        public int ViewingModelId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public int AvaibleSeats { get; set; }
        [Required]
        public int TotalSeats { get; set; }
        public bool IsShowing { get; set; }

        public int? TheaterModelId { get; set; }
        public TheaterModel Theater { get; set; }

        public int? MovieModelId { get; set; }
        public MovieModel Movie { get; set; }

        public ICollection<TicketModel> tickets { get; set; }
    }
}
