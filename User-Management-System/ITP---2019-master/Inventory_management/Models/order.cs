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
    using System.ComponentModel.DataAnnotations;

    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            this.orderdetails = new HashSet<orderdetail>();
        }
    
        public int orderID { get; set; }
        public System.DateTime orderDate { get; set; }
        public string paymentType { get; set; }
        public string status { get; set; }
      //  [Required(ErrorMessage = "Name ID has to be filled")]
        
        public string customerName { get; set; }
      //  [Required(ErrorMessage = "Contact has to be filled")]
        public string customerPhone { get; set; }
      //  [Required(ErrorMessage = "Email has to be filled")]
        public string customerEmail { get; set; }
      //  [Required(ErrorMessage = "Address has to be filled")]
        public string customerAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderdetail> orderdetails { get; set; }
    }
}
