using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalClassification
{
    class Node
    {
        // The main class of the node, which is the first digit of the Dewey Decimal number
        public int mainClass;
        // The division of the node, which is the second digit of the Dewey Decimal number
        public int division;
        // The section of the node, which is the third digit of the Dewey Decimal number
        public int section;
        // The description of the node, which is the name of the category or subcategory
        public string description;
        // The list of children of the node
        public List<Node> children;

        // A constructor that creates a new node with the given parameters
        public Node(int mainClass, int division, int section, string description)
        {
            this.mainClass = mainClass;
            this.division = division;
            this.section = section;
            this.description = description;
            this.children = new List<Node>();
        }

        // A method that adds a child node to the current node
        public void AddChild(Node child)
        {
            this.children.Add(child);
        }
    }
}
