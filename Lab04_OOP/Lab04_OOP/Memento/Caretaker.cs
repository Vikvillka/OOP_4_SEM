using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_OOP.Memento
{
    public class Caretaker
    {
        public Stack<ProductMemento> UndoHistory { get; private set; }
        public Stack<ProductMemento> RedoHistory { get; private set; }
        public Caretaker()
        {
            UndoHistory = new Stack<ProductMemento>();
            RedoHistory = new Stack<ProductMemento>();
        }
    }
}
