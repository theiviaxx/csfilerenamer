using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace file_renamer
{
    public class StackManager : BindableBase
    {
        private List<Type> m_nodes;
        private ObservableCollection<FileString> m_files;

        public StackManager()
        {
            m_nodes = new List<Type>();
            m_nodes.Add(typeof(ReplaceNode));
            m_nodes.Add(typeof(CaseNode));
            m_nodes.Add(typeof(SubstringNode));
            m_nodes.Add(typeof(ClearNode));
            m_nodes.Add(typeof(InsertNode));
            m_nodes.Add(typeof(RemoveNode));

            m_files = new ObservableCollection<FileString>();
            //GetFiles();
        }

        public List<Type> Nodes { get { return m_nodes; } }
        public ObservableCollection<FileString> Files { get { return m_files; } private set {SetProperty(ref m_files, value);} }

        public void GetFiles(string root)
        {
            DirectoryInfo di = new DirectoryInfo(root);
            WalkDirectoryTree(di);
        }

        public void Add(FileString filename)
        {
            if (!m_files.Contains(filename)) {
                m_files.Add(filename);
            }
        }

        ObservableCollection<FileString> WalkDirectoryTree(DirectoryInfo root)
        {
            
            FileInfo[] files = null;
            

            files = root.GetFiles("*.*");
            foreach (System.IO.FileInfo fi in files)
            {
                m_files.Add(new FileString(fi));
            }

            System.IO.DirectoryInfo[] subdirs = null;
            subdirs = root.GetDirectories();
            foreach (System.IO.DirectoryInfo dirinfo in subdirs) {
                WalkDirectoryTree(dirinfo);
            }

            return m_files;
        }

        public void RunTransforms(IEnumerable<INode> stack)
        {
            for (int i = 0; i < m_files.Count; i++)
            {
                m_files[i].Preview = m_files[i].Value;
            }
            foreach (INode node in stack)
            {
                for (int i = 0; i < m_files.Count; i++)
                {
                    m_files[i].Preview = node.Run(m_files[i]);
                }
            }
        }
        public void ExecuteTransforms()
        {
            int success, errors;
            success = 0;
            errors = 0;
            for (int i = 0; i < m_files.Count; i++)
            {
                string current = m_files[i].Value;
                if (m_files[i].MoveTo(m_files[i].Preview).FullName == current)
                {
                    errors++;
                }
                else
                {
                    m_files[i].Value = m_files[i].Preview;
                    success++;
                }
            }

            Console.Write(String.Format("{0} successes and {1} errors", success, errors));
        }
    }
}
