namespace PCConf
{
    //Декоратор
    public abstract class PCDecorator : PC
    {
        protected PC pc;

        public PCDecorator(string n, PC pc) : base(n)
        {
            this.pc = pc;
        }
    }

}
