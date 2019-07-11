namespace PCConf
{

    abstract class PC
    {
        public string Name { get; protected set; }

        public PC(string name)
        {
            Name = name;
        }
        
        public abstract int GetCost();
    }

    class HomePC : PC
    {
        public HomePC() : base("Домашняя сборка")
        { }
        public override int GetCost()
        {
            return 100000;
        }
    }
    class ProPC : PC
    {
        public ProPC() : base("Проф. сборка")
        { }
        public override int GetCost()
        {
            return 450000;
        }
    }

    abstract class PCDecorator : PC
    {
        protected PC pc;

        public PCDecorator(string n, PC pc) : base(n)
        {
            this.pc = pc;
        }
    }

    class VideoCard : PCDecorator
    {
        public VideoCard(PC p)
            : base(p.Name + ", GTX 1050Ti", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 120000;
        }
    }

    class Processor : PCDecorator
    {
        public Processor(PC p)
            : base(p.Name + ", Intel Core I7 7700K", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 140000;
        }
    }

    class MotherBoard : PCDecorator
    {
        public MotherBoard(PC p)
            : base(p.Name + ", Asus Monster 200R", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 70000;
        }
    }

    class ChargeBlock : PCDecorator
    {
        public ChargeBlock(PC p)
            : base(p.Name + ", AeroCool XPyse", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 80000;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
