using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace file_renamer
{
    public class FileString : BindableBase
    {
        public FileString(FileInfo fi)
        {
            _fileinfo = fi;
            _value = fi.FullName;
            _preview = fi.FullName;
        }
        public string Value { get { return _value; } set { _value = value; } }
        public string Preview { get { return _preview; } set { SetProperty(ref _preview, value); } }
        private FileInfo File { get { return _fileinfo; } }
        
        string _value;
        string _preview;
        FileInfo _fileinfo;
    }
}
