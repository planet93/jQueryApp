using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace jQueryAppBD.Models
{
    public class Computer
    {
        public int Id { get; set; }

        [Display(Name ="Модель")]
        [Required]
        [MaxLength(20,ErrorMessage ="Превышена допустимая длина строки")]
        public string Model { get; set; }

        [Display(Name ="Год выпуска")]
        [Required]
        [Range(1970,2014,ErrorMessage ="Недопустимый год")]
        public int Year { get; set; }
    }
    public class CompContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }

}