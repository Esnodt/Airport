//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdditionalInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdditionalInformation()
        {
            this.MainInfo = new HashSet<MainInfo>();
        }
    
        public int ID { get; set; }
        public System.DateTime DateAndTimeOfDeparture { get; set; }
        public System.DateTime DateAndTimeOfArrival { get; set; }
        public int NumberOfTicketsSold { get; set; }
        public int AircraftOccupancy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MainInfo> MainInfo { get; set; }
    }
}