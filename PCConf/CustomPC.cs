namespace PCConf
{
    public class CustomPC : PC
    {
        public CustomPC() : base("Своя сборка")
        { }
        public override int GetCost()
        {
            return 30000;
        }
    }

}
