using System.Data.Entity;

namespace VisualPerception.Model
{
    public class VisualPerceptionContext : DbContext
    {
        public VisualPerceptionContext()
            : base("VisualPerception")
        {
            
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
