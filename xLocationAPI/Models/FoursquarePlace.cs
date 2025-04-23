namespace xLocationAPI.Models
{
    public class FoursquarePlace
    {
        public string FsqId { get; set; }
        public string ClosedBucket { get; set; }
        public int Distance { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public List<Chain> Chains
        {
            get; set;
        }
    }
}
