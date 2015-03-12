using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_renamer
{
    class InsertNode : INode
    {
        public string Name { get { return "Insert"; } }
        public string Description { get { return "Only work on a substring"; } }
        public string Run(FileString filename)
        {
            if (Value != null)
            {
                return filename.Preview.Insert(Index, Value);
            }
            return filename.Preview;
        }

        public string Value { get; set; }
        public ushort Index { get; set; }
    }
}
