using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace file_renamer
{
    class ClearNode : INode
    {
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get { return "Clear"; } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string Description { get { return "Changes the case"; } }
        
        public string Run(FileString filename)
        {
            string[] parts = filename.Preview.Split('\\');
            return string.Join("\\", parts, 0, parts.Length - 1) + "\\";
        }
    }
}
