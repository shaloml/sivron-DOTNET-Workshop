namespace EF.demo.Model
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Samurai Samurai { get; set; }
    }
}