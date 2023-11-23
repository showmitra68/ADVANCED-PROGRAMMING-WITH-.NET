//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHungerAssignment.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CollectRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CollectRequest()
        {
            this.FoodDistributions = new HashSet<FoodDistribution>();
        }
    
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public System.DateTime PreservationTime { get; set; }
        public System.DateTime CollectionDate { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodDistribution> FoodDistributions { get; set; }
    }
}
