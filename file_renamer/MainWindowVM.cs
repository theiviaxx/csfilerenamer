using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        }
        public StackManager Manager { get { return m_manager; } }
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
    }
}
