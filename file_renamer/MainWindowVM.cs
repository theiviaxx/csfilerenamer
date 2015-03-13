using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace file_renamer
{
    public class MainWinVM : BindableBase
    {
        private StackManager m_manager;
        private ObservableCollection<INode> m_stack;
        private Type m_selectedType;
        private INode m_selectedItem;

        public MainWinVM()
        {
            m_manager = new StackManager();
            m_stack = new ObservableCollection<INode>();
            RemoveItem = new Command(
                p =>
                {
                    m_stack.Remove(m_selectedItem);
                    m_manager.RunTransforms(m_stack);
                }
            );
            AddItem = new Command(
                p =>
                {
                    NodeDialog dlg = new NodeDialog(this);
                    if (dlg.ShowDialog() == true)
                    {
                        Type t = (Type)dlg.nodeList.SelectedItem;
                        dynamic n = Activator.CreateInstance(t);
                        m_stack.Add(n);
                        m_manager.RunTransforms(m_stack);
                    }
                }
            );
            MoveItem = new Command(
                p =>
                {
                    int index = m_stack.IndexOf(m_selectedItem);
                    if ((string)p == "up")
                    {
                        if (index > 0) {
                            m_stack.Move(index, index - 1);
                        }
                    }
                    else
                    {
                        if (index < m_stack.Count() - 1)
                        {
                            m_stack.Move(index, index + 1);
                        }
                    }
                    m_manager.RunTransforms(m_stack);
                }
            );
            NodePropertyChange = new Command(
                p =>
                {
                    m_manager.RunTransforms(m_stack);
                }
            );
            Execute = new Command(
                p =>
                {
                    m_manager.ExecuteTransforms();
                }
            );
            OpenFiles = new Command(
                p =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == true)
                    {
                        foreach (string filename in openFileDialog.FileNames)
                        {
                            m_manager.Add(new FileString(filename));
                        }
                    }
                }
            );
            OpenFolder = new Command(
                p =>
                {
                    var dlg = new CommonOpenFileDialog();
                    dlg.IsFolderPicker = true;
                    CommonFileDialogResult result = dlg.ShowDialog();
                    if (result == CommonFileDialogResult.Ok)
                    {
                        m_manager.GetFiles(dlg.FileName);
                    }
                }
            );
        }
        public StackManager Manager 
        { 
            get 
            { 
                return m_manager; 
            }
            private set
            {
                SetProperty(ref m_manager, value);
            }
        }
        public ObservableCollection<INode> Stack { get { return m_stack; } }
        public Type SelectedType
        {
            get
            {
                return m_selectedType;
            }
            set
            {
                SetProperty(ref m_selectedType, value);
            }
        }
        public INode SelectedItem
        {
            get
            {
                return m_selectedItem;
            }
            set
            {
                SetProperty(ref m_selectedItem, value);
            }
        }
        public Command RemoveItem { get; private set; }
        public Command AddItem { get; private set; }
        public Command MoveItem { get; private set; }
        public Command NodePropertyChange { get; private set; }
        public Command Execute { get; private set; }
        public Command OpenFiles { get; private set; }
        public Command OpenFolder { get; private set; }
    }
}
