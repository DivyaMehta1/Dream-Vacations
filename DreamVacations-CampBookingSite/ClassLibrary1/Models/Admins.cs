using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Admins
    {
        /// <summary>
        /// Model Basis for Admins Entity in DB
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string  Username { get; set; }
        public string  Password { get; set; }
        
    }
}