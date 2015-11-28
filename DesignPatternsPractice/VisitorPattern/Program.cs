using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var netInventoryVisitor = new NetInventoryVisitor();
            var showroom = new Showroom();
            showroom.Accept(netInventoryVisitor);
            Console.WriteLine("Your current inventory is:" + netInventoryVisitor.TotalInventory);
            Console.ReadKey();
        }
    }
}
