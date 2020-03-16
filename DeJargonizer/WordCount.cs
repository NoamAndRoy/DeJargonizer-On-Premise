using CsvHelper.Configuration.Attributes;

namespace DeJargonizerOnPremise.DeJargonizer
{
	public class WordCount
	{
		[Index(0)]
		public string Word { get; set; }

		[Index(1)]
		public int Count { get; set; }
	}
}
