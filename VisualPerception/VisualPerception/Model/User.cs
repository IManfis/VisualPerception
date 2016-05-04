using System.Collections.Generic;

namespace VisualPerception.Model
{
    public class User
    {
        public User()
        {
            this.Experiment1Result = new HashSet<Experiment1Result>();
            this.Experiment2Result = new HashSet<Experiment2Result>();
            this.Experiment3Result = new HashSet<Experiment3Result>();
            this.Experiment4Result = new HashSet<Experiment4Result>();
            this.Experiment5Result = new HashSet<Experiment5Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? GroupNumber { get; set; }
        public string Password { get; set; }

        
        public virtual ICollection<Experiment1Result> Experiment1Result { get; set; }

        public virtual ICollection<Experiment2Result> Experiment2Result { get; set; }

        public virtual ICollection<Experiment3Result> Experiment3Result { get; set; }

        public virtual ICollection<Experiment4Result> Experiment4Result { get; set; }

        public virtual ICollection<Experiment5Result> Experiment5Result { get; set; }
    }
}
