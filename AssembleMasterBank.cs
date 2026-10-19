using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class AssembleMasterBank {
    static void Main() {
        Console.WriteLine("=== ASSEMBLING MASTER BANK ===");

        // Read all parts
        string geoPart1 = File.ReadAllText("temp_geo_part1.lua", Encoding.UTF8);
        string geoPart2 = File.ReadAllText("temp_geo_levels_3_4.lua", Encoding.UTF8);
        string geoPart3 = File.ReadAllText("temp_geo_levels_5_6.lua", Encoding.UTF8);
        string geoPart4 = File.ReadAllText("temp_geo_levels_7_10.lua", Encoding.UTF8);

        string hisPart1 = File.ReadAllText("temp_his_levels_1_2.lua", Encoding.UTF8);
        string hisPart2 = File.ReadAllText("temp_his_levels_3_6.lua", Encoding.UTF8);
        string hisPart3 = File.ReadAllText("temp_his_levels_7_10.lua", Encoding.UTF8);

        var sb = new StringBuilder();
        sb.AppendLine("--!strict");
        sb.AppendLine("export type Alternativa = {");
        sb.AppendLine("\tTexto: string,");
        sb.AppendLine("\tFalsa: boolean,");
        sb.AppendLine("}");
        sb.AppendLine("");
        sb.AppendLine("export type Questao = {");
        sb.AppendLine("\tNome: string,");
        sb.AppendLine("\tAlternativas: { Alternativa },");
        sb.AppendLine("}");
        sb.AppendLine("");
        sb.AppendLine("export type NivelQuiz = {");
        sb.AppendLine("\tDados: { Questao },");
        sb.AppendLine("}");
        sb.AppendLine("");
        sb.AppendLine("local QuizBancoQuestoes: { [string]: { [number]: NivelQuiz } } = {");
        sb.AppendLine("\t[\"Geografia\"] = {");
        sb.Append(CleanChunk(geoPart1));
        sb.Append(CleanChunk(geoPart2));
        sb.Append(CleanChunk(geoPart3));
        sb.Append(CleanChunk(geoPart4));
        sb.AppendLine("\t},");
        sb.AppendLine("\t[\"História\"] = {");
        sb.Append(CleanChunk(hisPart1));
        sb.Append(CleanChunk(hisPart2));
        sb.Append(CleanChunk(hisPart3));
        sb.AppendLine("\t},");
        sb.AppendLine("}");
        sb.AppendLine("");
        sb.AppendLine("return QuizBancoQuestoes");

        string fullContent = sb.ToString();

        // VALIDATION
        ValidateMasterLua(fullContent);

        // Write to destination files
        string targetFile = "src/ServerStorage/QuizBancoQuestoes.lua";
        File.WriteAllText(targetFile, fullContent, new UTF8Encoding(false));
        Console.WriteLine(string.Format("Successfully wrote {0} ({1} bytes, {2} lines)", targetFile, fullContent.Length, fullContent.Split('\n').Length));
    }

    static string CleanChunk(string s) {
        // Ensure proper indentation if needed, but the chunks are already indented
        var sb = new StringBuilder();
        using (var reader = new StringReader(s)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(line)) continue;
                sb.AppendLine(line);
            }
        }
        return sb.ToString();
    }

    static void ValidateMasterLua(string lua) {
        Console.WriteLine("Validating generated Lua master bank...");

        // Count occurrences of Nome = "..."
        var nomeMatches = Regex.Matches(lua, @"Nome\s*=\s*""([^""]+)""");
        Console.WriteLine(string.Format("Total questions found (Nome = \"...\"): {0}", nomeMatches.Count));
        if (nomeMatches.Count != 1001) {
            throw new Exception(string.Format("Expected 1001 questions, but found {0}", nomeMatches.Count));
        }



        // Count Falsa = true vs Falsa = false
        var falseMatches = Regex.Matches(lua, @"Falsa\s*=\s*true");
        var trueMatches = Regex.Matches(lua, @"Falsa\s*=\s*false");
        Console.WriteLine(string.Format("Lies (Falsa = true): {0}, Truths (Falsa = false): {1}", falseMatches.Count, trueMatches.Count));
        if (falseMatches.Count != 1001) {
            throw new Exception(string.Format("Expected 1001 lies (Falsa = true), but found {0}", falseMatches.Count));
        }
        if (trueMatches.Count != 2002) {
            throw new Exception(string.Format("Expected 2002 truths (Falsa = false), but found {0}", trueMatches.Count));
        }

        // Check levels for Geografia and História
        // Geografia: [0]..[10]
        // História: [1]..[10]
        int geoIndex = lua.IndexOf("[\"Geografia\"] = {");
        int hisIndex = lua.IndexOf("[\"História\"] = {");
        if (geoIndex == -1 || hisIndex == -1) {
            throw new Exception("Missing Geografia or História table headers!");
        }

        string geoSection = lua.Substring(geoIndex, hisIndex - geoIndex);
        string hisSection = lua.Substring(hisIndex);

        for (int i = 0; i <= 10; i++) {
            string lvlHeader = string.Format("[{0}] = {{", i);
            int idx = geoSection.IndexOf(lvlHeader);
            if (idx == -1) throw new Exception(string.Format("Geografia missing level [{0}]", i));
            // Find next level
            int nextIdx = (i < 10) ? geoSection.IndexOf(string.Format("[{0}] = {{", i + 1)) : geoSection.Length;
            string lvlSection = geoSection.Substring(idx, nextIdx - idx);
            var qInLvl = Regex.Matches(lvlSection, @"Nome\s*=\s*""");
            int expected = (i == 0) ? 1 : 50;
            if (qInLvl.Count != expected) {
                throw new Exception(string.Format("Geografia level {0} has {1} questions, expected {2}!", i, qInLvl.Count, expected));
            }
        }
        Console.WriteLine("Geografia levels 0-10 verified successfully (1 + 10x50 = 501 questions)");

        for (int i = 1; i <= 10; i++) {
            string lvlHeader = string.Format("[{0}] = {{", i);
            int idx = hisSection.IndexOf(lvlHeader);
            if (idx == -1) throw new Exception(string.Format("História missing level [{0}]", i));
            int nextIdx = (i < 10) ? hisSection.IndexOf(string.Format("[{0}] = {{", i + 1)) : hisSection.Length;
            string lvlSection = hisSection.Substring(idx, nextIdx - idx);
            var qInLvl = Regex.Matches(lvlSection, @"Nome\s*=\s*""");
            if (qInLvl.Count != 50) {
                throw new Exception(string.Format("História level {0} has {1} questions, expected 50!", i, qInLvl.Count));
            }
        }
        Console.WriteLine("História levels 1-10 verified successfully (10x50 = 500 questions)");

        // Check that Dados = { is present in each level
        var dadosMatches = Regex.Matches(lua, @"Dados\s*=\s*\{");
        Console.WriteLine(string.Format("Dados blocks found: {0} (expected 21: 11 for Geo + 10 for His)", dadosMatches.Count));
        if (dadosMatches.Count != 21) {
            throw new Exception(string.Format("Expected 21 'Dados = {{' blocks, but found {0}", dadosMatches.Count));
        }

        Console.WriteLine("=== ALL 1,001 QUESTIONS VALIDATED 100% PERFECTLY! ===");
    }
}
