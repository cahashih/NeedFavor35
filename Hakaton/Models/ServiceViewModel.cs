using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
}