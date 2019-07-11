namespace PCConf
{
    public class Processor : PCDecorator
    {
        public Processor(PC p)
            : base("Intel Core I7 7700K", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 140000;
        }
    }

}
