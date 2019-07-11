using PCConf;
using System;
using System.Collections.Generic;


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
