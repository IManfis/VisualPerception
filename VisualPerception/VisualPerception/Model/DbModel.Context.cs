﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VisualPerception.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VisualPerceptionContext : DbContext
    {
        public VisualPerceptionContext()
            : base("name=VisualPerceptionContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Experiment1Result> Experiment1Result { get; set; }
        public virtual DbSet<Experiment2Result> Experiment2Result { get; set; }
        public virtual DbSet<Experiment3Result> Experiment3Result { get; set; }
        public virtual DbSet<Experiment4Result> Experiment4Result { get; set; }
        public virtual DbSet<Experiment5Result> Experiment5Result { get; set; }
        public virtual DbSet<ExperimentData> ExperimentData { get; set; }
        public virtual DbSet<ExperimentSetting> ExperimentSetting { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
