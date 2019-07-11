using System;
using System.Collections.Generic;

namespace PCConf
{
    /*            Console.WriteLine("Конфигуратор компьютера приветсвует вас!\n1.Домашняя сборка\n2.Pro сборка\n3.Своя сборка");
            int choose = 0;
            while(!int.TryParse(Console.ReadLine(), out choose))
            {
                Console.WriteLine("Введите конкретное число!");
            }*/

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

    public class CustomPC : PC
    {
        public CustomPC() : base("Своя сборка")
        { }
        public override int GetCost()
        {
            return 30000;
        }
    }

    //Декоратор
    public abstract class PCDecorator : PC
    {
        protected PC pc;

        public PCDecorator(string n, PC pc) : base(n)
        {
            this.pc = pc;
        }
    }

    #region Конкретные декораторы
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
    #endregion

    //Добавлен фасад
    public class Facade
    {
#region Нужные переменные
        protected PC pc;

        protected HomePC _homePC;

        protected ProPC _proPC;

        List<PCDecorator> decorators = new List<PCDecorator>();

        protected VideoCard _videoCard;

        protected Processor _processor;

        protected MotherBoard _motherBoard;

        protected ChargeBlock _chargeBlock;

        private int _price = 0;

#endregion
        //конструктор
        public Facade(PC pc)
        {
            this.pc = pc;
            _price = pc.GetCost();
        }

        //если в наличии есть стандартные сборки
        public Facade(HomePC homePC, ProPC proPC)
        {
            _homePC = homePC;
            _proPC = proPC;
        }

        //инициализация всех компонентов(декораторов)
        public Facade(PC pc, VideoCard videoCard, Processor processor, MotherBoard motherBoard, ChargeBlock chargeBlock)
        {
            this.pc = pc;
            _videoCard = videoCard;
            _processor = processor;
            _motherBoard = motherBoard;
            _chargeBlock = chargeBlock;
            //добавление каждого декоратора в лист
            decorators.Add(videoCard);
            decorators.Add(processor);
            decorators.Add(motherBoard);
            decorators.Add(chargeBlock);
        }
        //покупка домашней сборки
        public void BuyHomePC()
        {
            Console.WriteLine($"Вы купили компьютер домашней сборки!\n С вас {_homePC.GetCost()}");
        }
        //покупка про компа
        public void BuyProPC()
        {
            Console.WriteLine($"Вы купили компьютер проф. сборки!\n С вас {_proPC.GetCost()}");
        }
        //сборка своего и покупка пк
        public void BuyOwnPC()
        {
            _price = pc.GetCost();
            int counter = 1;
            Console.WriteLine("Выберите компоненты: \n");
            foreach (var decorator in decorators)
            {
                
                Console.WriteLine($"{counter}.{decorator.Name}| {decorator.GetCost()}");
                counter++;
            }
            Console.WriteLine("5.Buy\n6.Exit");

            int choose = 0;
            while (choose != 6)
            {              
              while (!int.TryParse(Console.ReadLine(), out choose) || choose < 0 || choose > 6)
                {
                    Console.WriteLine("Введите корректное число!");
                }

                switch (choose)
                {
                    case 1:
                        _price += _videoCard.GetCost();
                        break;
                    case 2:
                        _price += _processor.GetCost();
                        break;
                    case 3:
                        _price += _motherBoard.GetCost();
                        break;
                    case 4:
                        _price += _chargeBlock.GetCost();
                        break;
                    case 5:
                        Console.WriteLine($"Стоимость вашего пк: {_price}");
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PC pc = new CustomPC();
            HomePC hPC = new HomePC();
            ProPC pPC = new ProPC();
            var readyPc = new Facade(hPC, pPC);
            var videoCard = new VideoCard(pc);
            var proc = new Processor(pc);
            var mb = new MotherBoard(pc);
            var chargeBlock = new ChargeBlock(pc);
            var ownPc = new Facade(pc,videoCard,proc,mb,chargeBlock);
            // ownPc.BuyOwnPC();
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
