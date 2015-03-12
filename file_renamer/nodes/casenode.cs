using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_renamer
{
    class CaseNode : INode
    {
        public string Name { get { return "Case"; } }
        public string Description { get { return "Changes the case"; } }
        public string Run(FileString filename)
        {
            string[] parts = filename.Preview.Split('.');
            if (UpperCase)
            {
                parts[parts.Length - 1] = parts[parts.Length - 1].ToUpper();
            }
            else
            {
                parts[parts.Length - 1] = parts[parts.Length - 1].ToLower();
            }
            return string.Join(".", parts);
        }

        public bool UpperCase { get; set; }
    }
}
