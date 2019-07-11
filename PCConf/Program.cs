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

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
