using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_renamer
{
    public class StackManager
    {
        private List<Type> m_nodes;
        public List<FileString> m_files;

        public StackManager()
        {
            m_nodes = new List<Type>();
            m_nodes.Add(typeof(ReplaceNode));
            m_nodes.Add(typeof(CaseNode));
            m_nodes.Add(typeof(SubstringNode));
            m_nodes.Add(typeof(ClearNode));
            m_nodes.Add(typeof(InsertNode));
            m_nodes.Add(typeof(RemoveNode));
            GetFiles();
        }

        public List<Type> Nodes { get { return m_nodes; } }
        public List<FileString> Files { get { return m_files; } }

        public List<FileString> GetFiles()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\tmp\frogdist\frog");
            m_files = WalkDirectoryTree(di);

            return m_files;
        }

        List<FileString> WalkDirectoryTree(DirectoryInfo root)
        {
            List<FileString> filenames = new List<FileString>();
            FileInfo[] files = null;
            

            files = root.GetFiles("*.*");
            foreach (System.IO.FileInfo fi in files)
            {
                filenames.Add(new FileString(fi));
            }

            System.IO.DirectoryInfo[] subdirs = null;
            subdirs = root.GetDirectories();
            foreach (System.IO.DirectoryInfo dirinfo in subdirs) {
                filenames.AddRange(WalkDirectoryTree(dirinfo));
            }

            return filenames;
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
    }
}
