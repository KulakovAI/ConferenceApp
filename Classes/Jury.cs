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
    
    public partial class Jury
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jury()
        {
            this.Activity = new HashSet<Activity>();
            this.Activity1 = new HashSet<Activity>();
            this.Activity2 = new HashSet<Activity>();
            this.Activity3 = new HashSet<Activity>();
            this.Activity4 = new HashSet<Activity>();
        }
    
        public int IdJury { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateBirthday { get; set; }
        public Nullable<int> IdCountry { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public Nullable<int> IdDirictory { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity4 { get; set; }
        public virtual Country Country { get; set; }
        public virtual Dirictory Dirictory { get; set; }
    }
}