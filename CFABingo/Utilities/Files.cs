using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CFABingo.Utilities;

public struct Files
{
    public static List<string> GetFilesInDir(string dir)
    {
        var fileEntries = Directory.GetFiles(dir);
        return fileEntries.Select(entry => entry.Split("/").Last().Replace(".json", "")).ToList();
    }

    public static string GetThemeFile(string id)
    {
        return File.ReadAllText("./Assets/Settings/Themes/" + id + ".json");
    }

    public static string ReadSettingsFile()
    {
        return File.ReadAllText("./Assets/Settings/Settings.json");
    }

    public static void WriteSettingsFile(string contents)
    {
        File.WriteAllText("./Assets/Settings/Settings.json", contents);
    }
}
