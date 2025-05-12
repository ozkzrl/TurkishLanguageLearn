namespace WebApplication11.Models
{
    public class ConjugationModel
    {
        public string InputWord { get; set; }
        public Dictionary<string, string> ConjugatedWords { get; set; } = new Dictionary<string, string>();

    }
}
