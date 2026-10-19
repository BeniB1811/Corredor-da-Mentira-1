using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class FindMissingLie {
    static void Main() {
        string[] files = Directory.GetFiles(".", "temp_*.lua");
        foreach (var file in files) {
            string text = File.ReadAllText(file, Encoding.UTF8);
            var matches = Regex.Matches(text, @"Nome\s*=\s*""(?<name>[^""]+)""\s*,\s*Alternativas\s*=\s*\{(?<alts>.*?)\}", RegexOptions.Singleline);
            foreach (Match m in matches) {
                string name = m.Groups["name"].Value;
                string alts = m.Groups["alts"].Value;
                int lies = Regex.Matches(alts, @"Falsa\s*=\s*true").Count;
                if (lies != 1) {
                    Console.WriteLine(string.Format("FOUND: File {0} -> Question '{1}' has {2} lies!", file, name, lies));
                }
            }
        }
    }
}
