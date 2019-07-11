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


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
