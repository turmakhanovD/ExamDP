namespace PCConf
{
    public class VideoCard : PCDecorator
    {
        public VideoCard(PC p)
            : base("GTX 1050Ti", p)
        { }

        public override int GetCost()
        {
            return pc.GetCost() + 120000;
        }
    }
}
