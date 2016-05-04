namespace VisualPerception.Model
{
    public class Experiment4Result
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string ProvidedIncentive { get; set; }
        public string ReproducedIncentive { get; set; }
        public int NumberReproducedOfIncentive { get; set; }
        public double PossessesHallmark { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }
        public string Hallmark { get; set; }

        public virtual User User { get; set; }
    }
}
