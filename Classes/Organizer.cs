//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConferenceApp.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organizer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organizer()
        {
            this.Event = new HashSet<Event>();
        }
    
        public int IdOrganizer { get; set; }
        public string Fio { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateBirthday { get; set; }
        public Nullable<int> IdCountry { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
    
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }
    }
}
