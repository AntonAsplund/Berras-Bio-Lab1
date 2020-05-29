
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berras_Bio_Lab1.Models
{
    public class TicketModel
    {
        public int TicketModelId { get; set; }
        public DateTime OrderDateTime { get; set; }
        [Range(1, 12)]
        public int NumberOfViewingTickets { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public int? ViewingModelId { get; set; }
        public ViewingModel Viewing { get; set; }
    }
}
