using DeJargonizerOnPremise.DeJargonizer;
using LexicalAnalyzer;
using Novacode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeJargonizerOnPremise
{
    public partial class MainWindow : Form
    {
        private readonly ILexer<eTokenType> lexer;
        private readonly IDeJargonizer deJargonizer;

        public MainWindow(ILexer<eTokenType> lexer, IDeJargonizer deJargonizer)
        {
            this.lexer = lexer;
            this.deJargonizer = deJargonizer;

            InitializeComponent();
        }

        private void addFilesBtn_Click(object sender, System.EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Multiselect = true,
                RestoreDirectory = true,
                Filter = "Word files(*.Docx)|*.Docx;*.Doc|Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 3
            };

            dialog.ShowDialog();

            var items = filesListBox.Items.Cast<string>().Concat(dialog.FileNames).Distinct().ToArray();
            filesListBox.Items.Clear();
            filesListBox.Items.AddRange(items);
            setAmountOfFiles(filesListBox.Items.Count);
        }

        private void clearFilesBtn_Click(object sender, EventArgs e)
        {
            filesListBox.Items.Clear();
            setAmountOfFiles(0);
        }

        private void removeFilesBtn_Click(object sender, EventArgs e)
        {

            foreach (int item in filesListBox.SelectedIndices)
            {
                filesListBox.Items.RemoveAt(item);
            }

            setAmountOfFiles(filesListBox.Items.Count);
        }

        private void deJargonizeBtn_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Step = (int)Math.Ceiling(100f / filesListBox.Items.Count);

            var results = AnalyzeArticles(filesListBox.Items.Cast<string>(), out var dashedWords);

            var csvResults = new StringBuilder();
            csvResults.AppendLine("File Name, Words ,Rare Words, Mid-Frequency Words, Rare Words List");
            var rareWordsCount = new Dictionary<string, int>();

            var i = 0;

            foreach (var result in results)
            {
                csvResults.AppendLine(
                    $"{GetFileName(filesListBox.Items[i++]!.ToString())},{result.AllWords.Count}, {result.RareWords.Count}, {result.NormalWords.Count}, " +
                    $"{(result.RareWords.Count > 0 ? result.RareWords.Aggregate((s1, s2) => $"{s1} , {s2}") : string.Empty)} ");

                foreach (var rareWord in result.RareWords.Select(rareWord => rareWord.ToLower()))
                {
                    if (rareWordsCount.ContainsKey(rareWord))
                    {
                        rareWordsCount[rareWord] = rareWordsCount[rareWord] + 1;
                    }
                    else
                    {
                        rareWordsCount[rareWord] = 1;
                    }
                }

                progressBar.PerformStep();
            }

            var csvRareWords = new StringBuilder();
            csvRareWords.AppendLine("Rare word, Amount");


            foreach (var (key, value) in rareWordsCount.ToList().OrderByDescending(k => k.Value))
            {
                csvRareWords.AppendLine($"{key}, {value}");
            }

            var csvDashedWords = new StringBuilder();
            csvDashedWords.AppendLine("Dashed Word, Formatted Word");

            foreach (var word in dashedWords)
            {
                csvDashedWords.AppendLine($"{word}, {string.Join(string.Empty, word.Split('-'))}");
            }

            using var directoryDialog = new FolderBrowserDialog();


            /*using var saveDialog = new SaveFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV files(*.csv)|*.csv",
                Title = "Save results file",
                FileName = "DeJargonizer Results " + DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss")
            };*/

            if (directoryDialog.ShowDialog() == DialogResult.OK)
            {
                var basicFileName = "DeJargonizer Results " + DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss");
                var ext = ".csv";
                File.WriteAllText(Path.Combine(directoryDialog.SelectedPath, basicFileName) + ext, csvResults.ToString());
                File.WriteAllText(Path.Combine(directoryDialog.SelectedPath, basicFileName + " Rare words") + ext,
                    csvRareWords.ToString());
                File.WriteAllText(Path.Combine(directoryDialog.SelectedPath, basicFileName + " Dashed words") + ext,
                    csvDashedWords.ToString());
            }

            progressBar.Visible = false;
        }

        private IEnumerable<DeJargonizerResult> AnalyzeArticles(IEnumerable<string> filePaths, out IEnumerable<string> dashedWords)
        {
            dashedWords = new List<string>();
            var results = new List<DeJargonizerResult>();

            foreach (var filePath in filePaths)
            {
                var text = filePath switch
                {
                    _ when filePath.EndsWith("docx") => DocX.Load(filePath).Text,
                    _ => new StreamReader(filePath).ReadToEnd()
                };

                var tokens = lexer.GetTokens(text);

                var words = tokens.Select(t => t.Value.ToString()).ToList();
                MergeDashedWords(words, out IEnumerable<string> articleDashedWords);

                dashedWords = dashedWords.Concat(articleDashedWords);

                results.Add(deJargonizer.Analyze(words));
            }

            dashedWords.Distinct();

            return results;
        }

        private void MergeDashedWords(List<string> words, out IEnumerable<string> dashedWords)
        {
            dashedWords = new List<string>();

            var dashedWordsIndexes =
                Enumerable.Range(0, words.Count).Where(i => words[i].Contains('-') && words[i] != "-");

            foreach(var index in dashedWordsIndexes)
            {
                ((List<string>)dashedWords).Add(words[index]);
                words[index] = string.Join(string.Empty, words[index].Split('-'));
            }

            dashedWords.Distinct();
        }

        private void setAmountOfFiles(int amount)
        {
            amountOfFilesLbl.Text = $"{amount} Files";

            if (amountOfFilesLbl.Right > Width)
            {
                amountOfFilesLbl.Left = Width - amountOfFilesLbl.Width;
            }
        }


        private string GetFileName(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath).TrimEnd('n');
            return fileName.Substring(fileName.IndexOf(' ') + 1);
        }
    }
}