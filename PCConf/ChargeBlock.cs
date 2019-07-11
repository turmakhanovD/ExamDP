namespace PCConf
{
    public class ChargeBlock : PCDecorator
    {
        public ChargeBlock(PC p)
            : base("AeroCool XPyse", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 80000;
        }
    }
}
