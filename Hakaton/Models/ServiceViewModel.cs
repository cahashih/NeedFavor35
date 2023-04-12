using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hakaton.Models
{
    public class CategoryServiceViewModel
    {
        public int CategoryServiceId { get; set; }
        public ICollection<ServiceFavor> ServicesFavor { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ServiceFavor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Description { get; set; }
        public CategoryServiceViewModel CategoryServiceViewModel { get; set; }
        
    }
    public class AddServiceCustomerExecutor
    {
        
        public string CustomerId { get; set; }
        [Required]
        [Display(Name = "заголовок")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "желаемая стоимость от")]
        public float HaveCostStart { get; set; }
        [Required]
        [Display(Name = "желаемая стоимость до")]
        public float HaveCost { get; set; }
        [Display(Name = "сроки оказания")]
        [Required]
        public string Period { get; set; }
        [Required]
        [Display(Name = "место оказания услуги")]
        public string Position { get; set; }
    }



}