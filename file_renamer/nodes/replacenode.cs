using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace file_renamer
{
    class ReplaceNode : INode
    {
        public string Name { get { return "Replace"; } }
        public string Description { get { return "Replaces stuff";  } }
        public static string Foo = "Something";
        public string Run(FileString filename) {
            if (Source != null && Dest != null)
            {
                try
                {
                    Regex re = new Regex(Source, RegexOptions.IgnoreCase);
                    return re.Replace(filename.Preview, Dest);
                }
                catch
                {

                }
            }
            return filename.Preview;
        }

        public string Source { get; set; }
        public string Dest { get; set; }
    }
}
