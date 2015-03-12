using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_renamer
{
    class RemoveNode : INode
    {
        public string Name { get { return "Insert"; } }
        public string Description { get { return "Only work on a substring"; } }
        public string Run(FileString filename)
        {
            return filename.Preview.Remove(Start, End);
        }

        public ushort Start { get; set; }
        public ushort End { get; set; }
    }
}
