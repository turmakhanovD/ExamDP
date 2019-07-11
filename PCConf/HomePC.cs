namespace PCConf
{
    //конкретный пк, домашней сборки
    public class HomePC : PC
    {
        public HomePC() : base("Домашняя сборка")
        { }
        public override int GetCost()
        {
            return 100000;
        }
    }
}
