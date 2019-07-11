namespace PCConf
{
    public class MotherBoard : PCDecorator
    {
        public MotherBoard(PC p)
            : base("Asus Monster 200R", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 70000;
        }
    }
}
