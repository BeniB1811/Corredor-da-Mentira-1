using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class SplitModularBank {
    static void Main() {
        Console.WriteLine("=== SPLITTING MODULAR MASTER BANK ===");

        // Read all parts
        string geoPart1 = File.ReadAllText("temp_geo_part1.lua", Encoding.UTF8); // 0, 1, 2
        string geoPart2 = File.ReadAllText("temp_geo_levels_3_4.lua", Encoding.UTF8); // 3, 4
        string geoPart3 = File.ReadAllText("temp_geo_levels_5_6.lua", Encoding.UTF8); // 5, 6
        string geoPart4 = File.ReadAllText("temp_geo_levels_7_10.lua", Encoding.UTF8); // 7, 8, 9, 10

        string hisPart1 = File.ReadAllText("temp_his_levels_1_2.lua", Encoding.UTF8); // 1, 2
        string hisPart2 = File.ReadAllText("temp_his_levels_3_6.lua", Encoding.UTF8); // 3, 4, 5, 6
        string hisPart3 = File.ReadAllText("temp_his_levels_7_10.lua", Encoding.UTF8); // 7, 8, 9, 10

        // Split geoPart3 into level 5 and level 6
        int geoLvl6Idx = geoPart3.IndexOf("[6] = {");
        if (geoLvl6Idx == -1) throw new Exception("Could not find [6] = { in geoPart3");
        string geoLvl5 = geoPart3.Substring(0, geoLvl6Idx);
        string geoLvl6 = geoPart3.Substring(geoLvl6Idx);

        // Split hisPart2 into levels 3..5 and level 6
        int hisLvl6Idx = hisPart2.IndexOf("[6] = {");
        if (hisLvl6Idx == -1) throw new Exception("Could not find [6] = { in hisPart2");
        string hisLvl3to5 = hisPart2.Substring(0, hisLvl6Idx);
        string hisLvl6 = hisPart2.Substring(hisLvl6Idx);

        // Submodule 1: Geo_1_5 (Levels 0, 1, 2, 3, 4, 5)
        var sbGeo1 = new StringBuilder();
        sbGeo1.AppendLine("--!strict");
        sbGeo1.AppendLine("return {");
        sbGeo1.Append(geoPart1);
        sbGeo1.Append(geoPart2);
        sbGeo1.Append(geoLvl5);
        sbGeo1.AppendLine("}");
        string geo1_5 = sbGeo1.ToString();

        // Submodule 2: Geo_6_10 (Levels 6, 7, 8, 9, 10)
        var sbGeo2 = new StringBuilder();
        sbGeo2.AppendLine("--!strict");
        sbGeo2.AppendLine("return {");
        sbGeo2.Append(geoLvl6);
        sbGeo2.Append(geoPart4);
        sbGeo2.AppendLine("}");
        string geo6_10 = sbGeo2.ToString();

        // Submodule 3: His_1_5 (Levels 1, 2, 3, 4, 5)
        var sbHis1 = new StringBuilder();
        sbHis1.AppendLine("--!strict");
        sbHis1.AppendLine("return {");
        sbHis1.Append(hisPart1);
        sbHis1.Append(hisLvl3to5);
        sbHis1.AppendLine("}");
        string his1_5 = sbHis1.ToString();

        // Submodule 4: His_6_10 (Levels 6, 7, 8, 9, 10)
        var sbHis2 = new StringBuilder();
        sbHis2.AppendLine("--!strict");
        sbHis2.AppendLine("return {");
        sbHis2.Append(hisLvl6);
        sbHis2.Append(hisPart3);
        sbHis2.AppendLine("}");
        string his6_10 = sbHis2.ToString();

        // Master init.lua
        var sbInit = new StringBuilder();
        sbInit.AppendLine("--!strict");
        sbInit.AppendLine("export type Alternativa = {");
        sbInit.AppendLine("\tTexto: string,");
        sbInit.AppendLine("\tFalsa: boolean,");
        sbInit.AppendLine("}");
        sbInit.AppendLine("");
        sbInit.AppendLine("export type Questao = {");
        sbInit.AppendLine("\tNome: string,");
        sbInit.AppendLine("\tAlternativas: { Alternativa },");
        sbInit.AppendLine("}");
        sbInit.AppendLine("");
        sbInit.AppendLine("export type NivelQuiz = {");
        sbInit.AppendLine("\tDados: { Questao },");
        sbInit.AppendLine("}");
        sbInit.AppendLine("");
        sbInit.AppendLine("local function carregarModulo(nome: string)");
        sbInit.AppendLine("\tlocal filho = script:FindFirstChild(nome) or (script.Parent and script.Parent:FindFirstChild(nome))");
        sbInit.AppendLine("\tif filho then");
        sbInit.AppendLine("\t\treturn require(filho)");
        sbInit.AppendLine("\tend");
        sbInit.AppendLine("\twarn('[QuizBancoQuestoes] Submódulo não encontrado:', nome)");
        sbInit.AppendLine("\treturn {}");
        sbInit.AppendLine("end");
        sbInit.AppendLine("");
        sbInit.AppendLine("local Geo1 = carregarModulo('Geo_1_5')");
        sbInit.AppendLine("local Geo2 = carregarModulo('Geo_6_10')");
        sbInit.AppendLine("local His1 = carregarModulo('His_1_5')");
        sbInit.AppendLine("local His2 = carregarModulo('His_6_10')");
        sbInit.AppendLine("");
        sbInit.AppendLine("local QuizBancoQuestoes: { [string]: { [number]: NivelQuiz } } = {");
        sbInit.AppendLine("\t[\"Geografia\"] = {},");
        sbInit.AppendLine("\t[\"História\"] = {},");
        sbInit.AppendLine("}");
        sbInit.AppendLine("");
        sbInit.AppendLine("for lvl, dados in pairs(Geo1) do QuizBancoQuestoes[\"Geografia\"][lvl] = dados end");
        sbInit.AppendLine("for lvl, dados in pairs(Geo2) do QuizBancoQuestoes[\"Geografia\"][lvl] = dados end");
        sbInit.AppendLine("for lvl, dados in pairs(His1) do QuizBancoQuestoes[\"História\"][lvl] = dados end");
        sbInit.AppendLine("for lvl, dados in pairs(His2) do QuizBancoQuestoes[\"História\"][lvl] = dados end");
        sbInit.AppendLine("");
        sbInit.AppendLine("return QuizBancoQuestoes");
        string initLua = sbInit.ToString();

        // Validate lengths
        Console.WriteLine(string.Format("Geo_1_5 length: {0} chars (< 200,000: {1})", geo1_5.Length, geo1_5.Length < 200000));
        Console.WriteLine(string.Format("Geo_6_10 length: {0} chars (< 200,000: {1})", geo6_10.Length, geo6_10.Length < 200000));
        Console.WriteLine(string.Format("His_1_5 length: {0} chars (< 200,000: {1})", his1_5.Length, his1_5.Length < 200000));
        Console.WriteLine(string.Format("His_6_10 length: {0} chars (< 200,000: {1})", his6_10.Length, his6_10.Length < 200000));
        Console.WriteLine(string.Format("init.lua length: {0} chars", initLua.Length));

        if (geo1_5.Length >= 200000 || geo6_10.Length >= 200000 || his1_5.Length >= 200000 || his6_10.Length >= 200000) {
            throw new Exception("One of the submodules exceeds Roblox's 200,000 character limit!");
        }

        // Validate question counts
        int qGeo1 = Regex.Matches(geo1_5, @"Nome\s*=\s*""").Count;
        int qGeo2 = Regex.Matches(geo6_10, @"Nome\s*=\s*""").Count;
        int qHis1 = Regex.Matches(his1_5, @"Nome\s*=\s*""").Count;
        int qHis2 = Regex.Matches(his6_10, @"Nome\s*=\s*""").Count;

        Console.WriteLine(string.Format("Questions: Geo1={0} (expected 251), Geo2={1} (expected 250), His1={2} (expected 250), His2={3} (expected 250)", qGeo1, qGeo2, qHis1, qHis2));
        if (qGeo1 != 251 || qGeo2 != 250 || qHis1 != 250 || qHis2 != 250) {
            throw new Exception("Question count mismatch in submodules!");
        }

        int totalLies = Regex.Matches(geo1_5 + geo6_10 + his1_5 + his6_10, @"Falsa\s*=\s*true").Count;
        int totalTruths = Regex.Matches(geo1_5 + geo6_10 + his1_5 + his6_10, @"Falsa\s*=\s*false").Count;
        Console.WriteLine(string.Format("Total Lies: {0} (expected 1001), Total Truths: {1} (expected 2002)", totalLies, totalTruths));
        if (totalLies != 1001 || totalTruths != 2002) {
            throw new Exception("Lie/Truth count mismatch in submodules!");
        }

        // Target directory: src/ServerStorage/QuizBancoQuestoes
        string targetDir = "src/ServerStorage/QuizBancoQuestoes";
        if (!Directory.Exists(targetDir)) {
            Directory.CreateDirectory(targetDir);
        }

        // Remove old standalone src/ServerStorage/QuizBancoQuestoes.lua if it exists
        string oldFile = "src/ServerStorage/QuizBancoQuestoes.lua";
        if (File.Exists(oldFile)) {
            File.Delete(oldFile);
            Console.WriteLine("Deleted old monolithic QuizBancoQuestoes.lua");
        }

        var utf8NoBom = new UTF8Encoding(false);
        File.WriteAllText(Path.Combine(targetDir, "init.lua"), initLua, utf8NoBom);
        File.WriteAllText(Path.Combine(targetDir, "Geo_1_5.lua"), geo1_5, utf8NoBom);
        File.WriteAllText(Path.Combine(targetDir, "Geo_6_10.lua"), geo6_10, utf8NoBom);
        File.WriteAllText(Path.Combine(targetDir, "His_1_5.lua"), his1_5, utf8NoBom);
        File.WriteAllText(Path.Combine(targetDir, "His_6_10.lua"), his6_10, utf8NoBom);

        Console.WriteLine("=== MODULAR BANK SUCCESSFULLY WRITTEN & VERIFIED! ===");
    }
}
