using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LocalNetwork.UserClasses;

namespace LocalNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Device Net = CreateNet();

            TreeToConsole(Net);

            //Console.Write(treeView);
            Console.ReadKey();
        }

        public static Device CreateNet()
        {
            Device root = new Router(0, "Router", "192.168.0.1");
            Device sw1 = new Switch(1, "Switch");
            Device sw2 = new Switch(2, "Switch");
            Device pc1_1 = new Computer(11, "Computer", "192.168.0.11");
            Device pc1_2 = new Computer(12, "Computer", "192.168.0.12");
            Device pc2_1 = new Computer(21, "Computer", "192.168.0.21");
            Device pc2_2 = new Computer(22, "Computer", "192.168.0.22");

            root.Link.Add(sw1);
            root.Link.Add(sw2);
            sw1.Link.Add(pc1_1);
            sw1.Link.Add(pc1_2);
            sw2.Link.Add(pc2_1);
            sw2.Link.Add(pc2_2);

            Device sw3 = new Switch(3, "Switch");
            Device sw4 = new Switch(4, "Switch");
            Device pc3_1 = new Computer(31, "Computer", "192.168.0.31");
            Device pc3_2 = new Computer(32, "Computer", "192.168.0.32");
            Device pc4_1 = new Computer(41, "Computer", "192.168.0.41");
            Device pc4_2 = new Computer(52, "Computer", "192.168.0.42");

            sw1.Link.Add(sw3);
            sw3.Link.Add(sw4);
            sw3.Link.Add(pc3_1);
            sw3.Link.Add(pc3_2);
            sw4.Link.Add(pc4_1);
            sw4.Link.Add(pc4_2);

            return root;
        }

        public static string TreeToString(Device root, int depth = 0)
        {
            StringBuilder treeView = new StringBuilder();

            treeView.Append(root.ToString() + "\n");

            for (int i = 0; i < root.Link.Count; ++i)
            {
                for (int j = 0; j < depth; ++j)
                {
                    treeView.Append("   ");
                }
                treeView.Append("|\n");

                for (int j = 0; j < depth; ++j)
                {
                    treeView.Append("   ");
                }

                treeView.Append("---");

                treeView.Append(TreeToString(root.Link[i], depth + 1));
            }

            return treeView.ToString();
        }

        public static void TreeToConsole(Device root, int depth = 0)
        {
            Console.WriteLine(root.ToString());

            for (int i = 0; i < root.Link.Count; ++i)
            {
                AddTabs(depth, true);
                AddTabs(depth, false);

                TreeToConsole(root.Link[i], depth + 1);
            }
        }

        public static void AddTabs(int tabsCount, bool isFirstCall)
        {
            for (int j = 0; j < tabsCount; ++j)
            {
                Console.Write("   ");
            }

            if (isFirstCall)
            {
                Console.WriteLine("|");
            }
            else
            {
                Console.Write("---");
            }
        }

    }
}
