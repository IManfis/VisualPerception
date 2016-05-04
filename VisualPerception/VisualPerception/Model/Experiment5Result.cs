namespace VisualPerception.Model
{
    public class Experiment5Result
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string ProvidedIncentive { get; set; }
        public string ReproducedIncentive { get; set; }
        public int NumberReproducedOfIncentive { get; set; }
        public int NumberGroupsWithWord { get; set; }
        public double RelativeDistributionWord { get; set; }
        public int NumberGroupsHallmark { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }
        public string Hallmark { get; set; }

        public virtual User User { get; set; }
    }
}
