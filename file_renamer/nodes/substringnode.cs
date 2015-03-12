using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_renamer
{
    class SubstringNode : INode
    {
        public string Name { get { return "Substring"; } }
        public string Description { get { return "Only work on a substring"; } }
        public string Run(FileString filename)
        {
            int end = End;
            if (end < 0)
            {
                end += filename.Preview.Length;
            }
            if (end == 0)
            {
                end = filename.Preview.Length - Start;
            }
            return filename.Preview.Substring(Start, end);
        }

        public ushort Start { get; set; }
        public short End { get; set; }
    }
}
