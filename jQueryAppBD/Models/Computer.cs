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
        public string Model { get; set; }
        [Display(Name ="Год выпуска")]
        public int Year { get; set; }
    }
    public class CompContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }

}