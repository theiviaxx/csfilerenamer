using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_renamer
{
    public interface INode
    {
        string Name { get; }
        string Description { get; }
        string Run(FileString filename);
    }
}
