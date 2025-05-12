namespace WebApplication11.Models
{
    public class DialogModel
    {
        public string Sentence { get; set; }
        public string Sentence1 { get; set; } // İkinci cümle için
        public List<string> MissingParts { get; set; }
        public List<string> DragOptions { get; set; }
        public List<string> DropZoneIds { get; set; }

    }
}
