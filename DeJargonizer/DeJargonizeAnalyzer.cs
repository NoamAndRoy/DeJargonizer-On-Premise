﻿using DeJargonizerOnPremise.Configs;
using DeJargonizerOnPremise.ExtensionMethods;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeJargonizerOnPremise.DeJargonizer
{
    public class DeJargonizeAnalyzer : IDeJargonizer
    {
        private readonly Lazy<Dictionary<string, int>> wordsCount;
        private readonly WordsCountThresholdsConfig wordsCountThresholds;

        public DeJargonizeAnalyzer(IWordsCountLoader wordsCountLoader, IOptions<WordsCountThresholdsConfig> wordsCountThresholdsConfig)
        {
            wordsCountThresholds = wordsCountThresholdsConfig.Value;
            wordsCount = new Lazy<Dictionary<string, int>>(wordsCountLoader.Load);
        }

        public DeJargonizerResult Analyze(IEnumerable<string> words)
        {
            var allWords = words.ToList();
            var commonWords = GetCommonWords(allWords);
            var normalWords = GetNormalWords(allWords);
            var rareWords = GetRareWords(allWords);

            return new DeJargonizerResult(allWords, commonWords, normalWords, rareWords);
        }

        public IEnumerable<string> GetCommonWords(IEnumerable<string> words) => words.Where(w => GetWordCount(w) >= wordsCountThresholds.CommonWordsThreshold);

        public IEnumerable<string> GetNormalWords(IEnumerable<string> words)
        {
            return words.Where(w =>
            {
                var wordCount = GetWordCount(w);

                return wordCount >= wordsCountThresholds.NormalWordsThreshold &&
                        wordCount < wordsCountThresholds.CommonWordsThreshold;
            });
        }

        public IEnumerable<string> GetRareWords(IEnumerable<string> words)
        {
            return words.Where(w =>
            {
                var wordCount = GetWordCount(w);

                return wordCount < wordsCountThresholds.NormalWordsThreshold;
            });
        }

        private int GetWordCount(string word)
        {
            var searchWord = word.ToLower().RemoveApostrophe();
            var wordExist = wordsCount.Value.TryGetValue(searchWord, out var count);

            return wordExist ? count : 0;
        }
    }
}
