﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class ConferenceEntities : DbContext
    {
        public static ConferenceEntities _context;
        public ConferenceEntities()
            : base("name=ConferenceEntities")
        {
        }
        public static ConferenceEntities GetContext()
        {
            if (_context == null)
                _context = new ConferenceEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<ActivEvent> ActivEvent { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Dirictory> Dirictory { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Eventmoder> Eventmoder { get; set; }
        public virtual DbSet<Jury> Jury { get; set; }
        public virtual DbSet<Moderator> Moderator { get; set; }
        public virtual DbSet<Organizer> Organizer { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
    }
}
