using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    public interface ICarAsset
    {
        void Accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        void Visit(CarA ca);
        void Visit(CarB cb);
        void Visit(CarC cc);
    }

    public class CarA : ICarAsset
    {
        public int TotalSold { get { return 10; } }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CarB : ICarAsset
    {
        public int Inventory { get { return 100; } }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CarC : ICarAsset
    {
        public int Damaged { get { return 10; } }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Showroom : ICarAsset
    {
        public List<ICarAsset> assets = new List<ICarAsset> { new CarA(), new CarB(), new CarC() };

        public void Accept(IVisitor visitor)
        {
            foreach(var asset in assets)
            {
                asset.Accept(visitor);
            }
        }
    }

    public class NetInventoryVisitor : IVisitor
    {
        private int totalCars = 0;
        public void Visit(CarA ca)
        {
            totalCars -= ca.TotalSold;
        }
       
        public void Visit(CarB cb)
        {
            totalCars += cb.Inventory;
        }

        public void Visit(CarC cc)
        {
            totalCars -= cc.Damaged;
        }

        public int TotalInventory { get { return totalCars; } }
    }
}
