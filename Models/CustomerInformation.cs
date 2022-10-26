using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminPanelProject.Models
{
    public partial class CustomerInformation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int? MobileNumber { get; set; }
        public string? BusinessType { get; set; }
        public double? LoanAmount { get; set; }
        public string? LoanPurpose { get; set; }
        public bool? FundAmount { get; set; }
    }
}
