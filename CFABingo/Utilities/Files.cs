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
}
