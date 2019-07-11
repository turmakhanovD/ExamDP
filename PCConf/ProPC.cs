namespace PCConf
{
    //конкретный пк, про сборка
    public class ProPC : PC
    {
        public ProPC() : base("Проф. сборка")
        { }
        public override int GetCost()
        {
            return 450000;
        }
    }

}
