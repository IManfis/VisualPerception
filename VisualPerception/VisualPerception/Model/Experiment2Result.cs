//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VisualPerception.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Experiment2Result
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string ProvidedIncentive { get; set; }
        public string ReproducedIncentive { get; set; }
        public int NumberReproducedOfIncentive { get; set; }
        public int NumberGroupsWithWord { get; set; }
        public double RelativeDistributionWord { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }
    
        public virtual User User { get; set; }
    }
}
