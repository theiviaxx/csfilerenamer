using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace file_renamer
{
    public class FileString : BindableBase, IEquatable<FileString>
    {
        private string m_value;
        private string m_preview;
        private bool m_iserror;
        private string m_errormessage;
        FileInfo m_fileinfo;

        public FileString(FileInfo fi)
        {
            m_fileinfo = fi;
            m_value = fi.FullName;
            m_preview = fi.FullName;
        }
        public FileString(string fi)
        {
            m_fileinfo = new FileInfo(fi);
            m_value = m_fileinfo.FullName;
            m_preview = m_fileinfo.FullName;
        }
        public bool Equals(FileString other)
        {
            return m_value == other.Value;
        }
        public bool IsError { get { return m_iserror; } }
        public string ErrorMessage { get { return m_errormessage; } }
        public string Value { get { return m_value; } set { m_value = value; } }
        public string Preview { get { return m_preview; } set {

            SetProperty(ref m_preview, value);
        } }
        private FileInfo File { get { return m_fileinfo; } }
        public FileInfo MoveTo(string dest)
        {
            try
            {
                m_fileinfo.MoveTo("fooc:/foo");
            }
            catch (Exception ex) {
                SetProperty(ref m_iserror, true);
                SetProperty(ref m_errormessage, ex.Message);
                return m_fileinfo;
            }
            
            return new FileInfo(dest);
        }
        
        
    }
}
