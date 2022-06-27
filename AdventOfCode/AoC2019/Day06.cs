using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class Day06 : Day
    {
        override public void Solve()
        {
            List<TreeNode> fragments = new List<TreeNode>();

            foreach(string s in Input)
            {
                string[] splitted = s.Split(new char[] { ')' });

                TreeNode t1 = new TreeNode(splitted[0]);
                TreeNode t2 = new TreeNode(splitted[1]);

                t1.AddChild(t2);
                fragments.Add(t1);
            }

            while(fragments.Count > 1)
            {
                TreeNode f = fragments[0];
                fragments.RemoveAt(0);
                bool added = false;
                foreach(TreeNode t in fragments)
                {
                    TreeNode t1 = t.GetTreeNodeByName(f.Name);
                    if (t1 != null)
                    {
                        foreach(TreeNode c in f.Children)
                        {
                            t1.AddChild(c);
                            added = true;
                        }
                        break;
                    }
                }
                if (!added)
                {
                    fragments.Add(f);
                }
            }

            fragments[0].SetOrbits(0);
            Part1Solution = fragments[0].GetOrbits().ToString();

            TreeNode startOrbit = fragments[0].GetTreeNodeByName("YOU").Parent;

            int orbitalTransfers = 0;
            TreeNode currentOrbit = startOrbit;

            bool searchOrbit = true;
            while(searchOrbit)
            {
                if (currentOrbit.GetTreeNodeByName("SAN") != null)
                {
                    foreach (TreeNode c in currentOrbit.Children)
                    {
                        if (c.Name.Equals("SAN"))
                        {
                            searchOrbit = false;
                            break;
                        }
                        if (c.GetTreeNodeByName("SAN") != null)
                        {
                            orbitalTransfers++;
                            currentOrbit = c;
                        }
                    }
                }
                else
                {
                    currentOrbit = currentOrbit.Parent;
                    orbitalTransfers++;
                }
            }
            Part2Solution = orbitalTransfers.ToString();
        }
    }

    class TreeNode
    {
        public TreeNode Parent { get; set; }
        public List<TreeNode> Children { get; set; }
        public string Name { get; set; }
        public int Orbits { get; set; }

        public TreeNode(string name)
        {
            Parent = null;
            Name = name;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public TreeNode GetTreeNodeByName(string name)
        {
            if (Name.Equals(name))
            {
                return this;
            }
            else
            {
                foreach (TreeNode t in Children)
                {
                    TreeNode r = t.GetTreeNodeByName(name);
                    if (r != null)
                    {
                        return r;
                    }
                }
                return null;
            }
        }

        public void SetOrbits(int parentOrbits)
        {
            Orbits = parentOrbits;
            foreach(TreeNode c in Children)
            {
                c.SetOrbits(parentOrbits + 1);
            }
        }

        public int GetOrbits()
        {
            int orbits = Orbits;
            foreach (TreeNode c in Children)
            {
                orbits += c.GetOrbits();
            }
            return orbits;
        }
    }
}
