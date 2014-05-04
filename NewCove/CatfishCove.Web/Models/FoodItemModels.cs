using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CatfishCove.Web.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MenuOrder { get; set; }
    }

    public class BuffetItem
    {
        public int Id { get; set; }
        public FoodType FoodType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RotationFrequency { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        [Required]
        public FoodType FoodType { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string HalfOrderPrice { get; set; }
        [Required]
        public string WholeOrderPrice { get; set; }
    }

    public class BuffetRotatingWeek
    {
        public int Id { get; set; }
        public DateTime SundayDate { get; set; }
        public BuffetItemSchedule Meat { get; set; }
        public BuffetItemSchedule Casserole { get; set; }
        public BuffetItemSchedule Corn { get; set; }
        public BuffetItemSchedule Beans { get; set; }
    }

    public class BuffetItemSchedule
    {
        public int Id { get; set; }
        public FoodType FoodType { get; set; }
        public BuffetItem BuffetItem { get; set; }
        public BuffetItemSchedule NextItem { get; set; }
    }

    public class CatfishCoveDatabase : DbContext
    {
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<BuffetItem> BuffetItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<BuffetRotatingWeek> BuffetRotatingWeeks { get; set; }
        public DbSet<BuffetItemSchedule> BuffetSchedules { get; set; }
    }
}