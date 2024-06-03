using System.IO;
using UnityEngine;

namespace Francespo.Loggers
{
    public class LogFile
    {
        string name;
        string path;

        public LogFile(string name, string path = "/Logs")
        {
            this.name = name;
            this.path = Application.dataPath + path + "/" + name + ".txt";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Log \n\n");
            }
        }

        public void Add(string toAdd, bool newLineBefore = true)
        {
            string content = newLineBefore ? $"\n{toAdd}" : toAdd;
            File.AppendAllText(path, content);
        }
    }
}

