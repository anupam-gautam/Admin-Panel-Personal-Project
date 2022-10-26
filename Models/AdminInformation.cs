using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelProject.Models
{
    public partial class AdminInformation
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public int? MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? Pincode { get; set; }
    }
}
