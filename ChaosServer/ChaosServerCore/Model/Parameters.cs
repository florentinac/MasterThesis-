namespace ChaosServerCore.Model
{
    public class Parameters : IIndexable
    {
        public string Id { get; set; }
        public double X { get; set; }
        public double Lambda { get; set; }
        public int C0 { get; set; }
        public int T { get; set; }
        public int A { get; set; }
        public int B { get; set; }
    }
}
