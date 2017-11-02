using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public FoodType FoodType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int RotationFrequency { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        [Required, Display(Name = "Food Type")]
        public FoodType FoodType { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Half Order Price")]
        public string HalfOrderPrice { get; set; }
        [Required, Display(Name = "Whole Order Price")]
        public string WholeOrderPrice { get; set; }
    }

    public class BuffetRotatingWeek
    {
        public int Id { get; set; }
        [Required]
        public DateTime SundayDate { get; set; }
        [Required]
        public BuffetItemSchedule Meat { get; set; }
        [Required]
        public BuffetItemSchedule Casserole { get; set; }
        [Required]
        public BuffetItemSchedule Corn { get; set; }
        [Required]
        public BuffetItemSchedule Beans { get; set; }
    }

    public class BuffetItemSchedule
    {
        public int Id { get; set; }
        public FoodType FoodType { get; set; }
        public BuffetItem BuffetItem { get; set; }
        public BuffetItemSchedule NextItem { get; set; }
    }
}