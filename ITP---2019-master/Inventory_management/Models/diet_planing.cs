//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory_management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class diet_planing
    {
        public int dietID { get; set; }
        public string name { get; set; }
        public string pdf { get; set; }
        public Nullable<float> bmi { get; set; }
        public string age_range { get; set; }
        public string category { get; set; }
        public string food_type { get; set; }
    }
}