using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace parkingApp.Models
{
    [Table("parking")]
    public class Parking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Driver { get; set; }

        [Required(ErrorMessage = "Please enter date")]
        [DataType(DataType.DateTime)]
        public DateTime _Date { get; set; }

        
        public string _Status { get; set; }
        public Parking()
        {
            _Status = "purchased";
        }
    }
}