using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Models
{
    /// <summary>
    /// Model basis for Camps Entity in DB
    /// </summary>
    public class Camps
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool IsBooked { get; set; }
        public string Image { get; set; }
        public Guid AdminId { get; set; }
        public decimal? Rating { get; set; }

        [ForeignKey("AdminId")]
        public Admins Admins { get; set; }

    }
}