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
    
    public partial class Activity
    {
        public int IdActivity { get; set; }
        public Nullable<int> IdModerator { get; set; }
        public Nullable<int> IdJury_1 { get; set; }
        public Nullable<int> IdJury_2 { get; set; }
        public Nullable<int> IdJury_3 { get; set; }
        public Nullable<int> IdJury_4 { get; set; }
        public Nullable<int> IdJury_5 { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<int> IdActivEvent { get; set; }
        public string ActivName { get; set; }
        public string Time { get; set; }
    
        public virtual Jury Jury { get; set; }
        public virtual Jury Jury1 { get; set; }
        public virtual Jury Jury2 { get; set; }
        public virtual Jury Jury3 { get; set; }
        public virtual Jury Jury4 { get; set; }
        public virtual Moderator Moderator { get; set; }
    }
}