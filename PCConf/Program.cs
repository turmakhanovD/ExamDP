using System;

namespace PCConf
{

    public class Program
    {
        static void Main(string[] args)
        {
            //Создание экземпляров
            PC pc = new CustomPC();
            HomePC hPC = new HomePC();
            ProPC pPC = new ProPC();
            var readyPc = new Facade(hPC, pPC);
            var videoCard = new VideoCard(pc);
            var proc = new Processor(pc);
            var mb = new MotherBoard(pc);
            var chargeBlock = new ChargeBlock(pc);
            var ownPc = new Facade(pc,videoCard,proc,mb,chargeBlock);
 
            //Менюшка
            Console.WriteLine("Конфигуратор компьютера приветсвует вас!\n1.Домашняя сборка\n2.Pro сборка\n3.Своя сборка");
            int choose = 0;
            while (!int.TryParse(Console.ReadLine(), out choose) || choose > 3)
            {
                Console.WriteLine("Введите конкретное число!");
            }

            switch(choose)
            {
                case 1:
                    readyPc.BuyHomePC();
                    break;
                case 2:
                    readyPc.BuyProPC();
                    break;
                case 3:
                    ownPc.BuyOwnPC();
                    break;
            }

            Console.ReadLine();
        }
    }
}
