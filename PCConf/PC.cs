namespace PCConf
{
    //Фабричный метод
    // абстрактный класс строительной компании
    public abstract class PC
    {
        public string Name { get; protected set; }

        public PC(string name)
        {
            Name = name;
        }
        //фабричный метод
        public abstract int GetCost();
    }
}
