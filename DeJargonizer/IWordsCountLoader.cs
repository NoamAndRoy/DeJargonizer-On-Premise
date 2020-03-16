using System.Collections.Generic;

namespace DeJargonizerOnPremise.DeJargonizer
{
	public interface IWordsCountLoader
	{
		Dictionary<string, int> Load();
	}
}
