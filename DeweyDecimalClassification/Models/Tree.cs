using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalClassification
{
    class Tree
    {
        // The root of the tree
        public Node root;

        
        public Tree()
        {
            this.root = null;
        }

        // A method that inserts a new node into the tree
        public void Insert(int mainClass, int division, int section, string description)
        {
            // If the tree is empty, create a new node as the root
            if (this.root == null)
            {
                this.root = new Node(mainClass, division, section, description);
                return;
            }

            // Start from the root and traverse the tree
            Node current = this.root;
            Node parent = null;
            while (current != null)
            {
                // If the main class, division, and section are equal to the current node, update the description
                if (mainClass == current.mainClass && division == current.division && section == current.section)
                {
                    current.description = description;
                    return;
                }

                // If the main class is smaller than the current node, go to the left child
                if (mainClass < current.mainClass)
                {
                    parent = current;
                    current = current.children[0];
                }
                // If the main class is larger than the current node, go to the right child
                else if (mainClass > current.mainClass)
                {
                    parent = current;
                    current = current.children[1];
                }
                // If the main class is equal to the current node, compare the division
                else
                {
                    // If the division is smaller than the current node, go to the left child
                    if (division < current.division)
                    {
                        parent = current;
                        current = current.children[0];
                    }
                    // If the division is larger than the current node, go to the right child
                    else if (division > current.division)
                    {
                        parent = current;
                        current = current.children[1];
                    }
                    // If the division is equal to the current node, compare the section
                    else
                    {
                        // If the section is smaller than the current node, go to the left child
                        if (section < current.section)
                        {
                            parent = current;
                            current = current.children[0];
                        }
                        // If the section is larger than the current node, go to the right child
                        else if (section > current.section)
                        {
                            parent = current;
                            current = current.children[1];
                        }
                        // If the section is equal to the current node, this should not happen
                        else
                        {
                            throw new Exception("Duplicate node");
                        }
                    }
                }
            }

            // If the node is not found, create a new node and attach it to the parent
            Node newNode = new Node(mainClass, division, section, description);
            if (mainClass < parent.mainClass || (mainClass == parent.mainClass && division < parent.division) || (mainClass == parent.mainClass && division == parent.division && section < parent.section))
            {
                parent.AddChild(newNode);
            }
            else
            {
                parent.AddChild(newNode);
            }
        }

        // A method that searches for a node in the tree
        public Node Search(int mainClass, int division, int section)
        {
            // Start from the root and traverse the tree
            Node current = this.root;
            while (current != null)
            {
                // If the main class, division, and section are equal to the current node, return the node
                if (mainClass == current.mainClass && division == current.division && section == current.section)
                {
                    return current;
                }

                // If the main class is smaller than the current node, go to the left child
                if (mainClass < current.mainClass)
                {
                    current = current.children[0];
                }
                // If the main class is larger than the current node, go to the right child
                else if (mainClass > current.mainClass)
                {
                    current = current.children[1];
                }
                // If the main class is equal to the current node, compare the division
                else
                {
                    // If the division is smaller than the current node, go to the left child
                    if (division < current.division)
                    {
                        current = current.children[0];
                    }
                    // If the division is larger than the current node, go to the right child
                    else if (division > current.division)
                    {
                        current = current.children[1];
                    }
                    // If the division is equal to the current node, compare the section
                    else
                    {
                        // If the section is smaller than the current node, go to the left child
                        if (section < current.section)
                        {
                            current = current.children[0];
                        }
                        // If the section is larger than the current node, go to the right child
                        else if (section > current.section)
                        {
                            current = current.children[1];
                        }
                        // If the section is equal to the current node, return an exception
                        else
                        {
                            throw new Exception("Duplicate node");
                        }
                    }
                }
            }

            // If the node is not found, return null
            return null;
        }
    }
}
