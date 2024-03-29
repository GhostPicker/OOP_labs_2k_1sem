﻿using STPMS5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPMS5
{
    class Program
    {
        static void Main(string[] args)
        {
            Train tr1 = new Train("голубой", 540);
            Train tr2 = new Train("зеленый", 80);
            Train tr3 = new Train("желтый", 14);

            Vehicle carriage1 = new Carriage("голубой", 4);
            Vehicle carriage2 = new Carriage("зеленый", 2);
            Vehicle carriage3 = new Carriage("желтый", 5);

            carriage1.Move();
            tr1.Move();
            if (carriage1 is Train)
            {
                Console.WriteLine("Вагон - часть поезда!");
            }

            Print.IamPrinting(carriage2);
            Print.IamPrinting(tr3);
            tr1.ShowTrain(tr1.n, tr1.color);
            tr2.ShowTrain(tr2.n, tr2.color);
            tr3.ShowTrain(tr3.n, tr3.color);

            Car car1 = new Car("BMW", 5283);
            Car car2 = new Car("Lada", 8603);
            Car car3 = new Car("Audi", 1110);
            car1.ShowCar(car1.mark, car1.number);
            car2.ShowCar(car2.mark, car2.number);
            car3.ShowCar(car3.mark, car3.number);

            if (car1 is Train)
            {
                Console.WriteLine("Ложь!");
            }
            else
                Console.WriteLine("Машина - не поезд!");

            Console.ReadKey();
        }
    }

    public static class Print
    {
        public static void IamPrinting(object obj)
        {
            Console.WriteLine("Это объект типа " + obj.GetType());
        }
    }
    //1 8 19
    //картинка иерархии
    public abstract class Vehicle //Абстрактный класс "Транспортное средство"
    {
        protected float Speed; //наследуемое значение скорости
        public abstract void Move(); //абстрактный метод "движение"
        internal bool PartOfVehicle; // методы для всех производных абстрактного класса
       
        public float GetCurrentSpeed()
        {
            return Speed;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Train : Vehicle
    {
        public string color;
        public int n;
        public Train(string color, int n)
        {
            this.color = color;
            this.n = n;
        }

        public override void Move()//переопределяем метод "движение" класса-родителя
        {
            Console.WriteLine("Поезд движется.");
        }
        public virtual void TrainsCarriage() // виртуальный метод, так как потом мы можем его переопределять как вагоны поезда, но пока он просто поезд
        {
            Console.WriteLine("Это некий поезд.");
        }
        public override string ToString()
        {
            return base.ToString() + "Переопределение toString() выполнено.";
        }
        public virtual void ShowTrain(int n, string col)
        {
            Console.WriteLine($"Поезд с номером {n} имеет {col} цвет!");
        }
    }


}
interface Istop // интерфейс, в котором есть метод "остановиться", если мы пропишем этот интерфейс какому-нибудь классу, этот класс выполнит это

{
    void Stopping();
}

// бесплодный класс, от которого невозможно наследование
// но он наследуется от класса мяч.
// и он будет наследовать интерфейс для тенниса.
sealed class Carriage : Train, Istop
{
    int numberOfCarriage;

    public Carriage(string color, int n) : base(color, n)
    {
        this.color = color;
        this.PartOfVehicle = true;
        this.numberOfCarriage = n;
    }


    public override void TrainsCarriage() // сейчас этот метод уже не виртуальый
    {
        Console.WriteLine("Поезд имеет несколько вагонов.");
    }


    public void Stopping() // реализация интерфейса
    {
        Console.WriteLine("Транспорт остановился");
    }


    // использование as 

    public override bool Equals(object obj)
    {
        if (obj == null) // проверка, а есть ли вообще что-то в объекте, если все ок, то дальше...
        {
            Console.WriteLine("Что-то не так");
            return false;
        }

        obj = obj as Carriage; //AS служит для перевода объекта к указанному типу, 
                               // в случае невозможности
                               //привести объект к указанному типу мы вместо исключения получим null.
                               // был какой-то объект, мы превратили в вагон.
                               // если у нас получилось, то объект не равен нулю и следовательно вагон.
        if (obj != null)
        {
            Console.WriteLine("Это действительно вагон поезда.");
            return true;
        }

        Console.WriteLine("Это не вагон!");
        return false;
    }



    public override int GetHashCode()
    {
        return base.GetHashCode() + numberOfCarriage;
    }


    public override string ToString()
    {
        return base.ToString() + " Это вагон" + ", вагон поезда";
    }


}

public class Car : Vehicle
{
    public string mark;
    public int number;
    public Car(string mark, int number)
    {
        this.mark = mark;
        this.number = number;
    }
    public override void Move()//переопределяем метод "движение" класса-родителя
    {
        Console.WriteLine("Машина движется.");
    }

    public override string ToString()
    {
        return base.ToString() + "Переопределение toString() выполнено.";
    }
    public void ShowCar(string mark, int number)
    {
        Console.WriteLine($"Машина {mark} с номером {number}");
    }
    interface IDrive
    {
        void Driving();
    }
    sealed class Dvig : Car, IDrive
    {
        int numberOfDvig;

        public Dvig(string mark, int n) : base(mark, n)
        {
            this.mark = mark;
            this.PartOfVehicle = true;
            this.numberOfDvig = n;

        }

        // использование as 

        public override bool Equals(object obj)
        {
            if (obj == null) // проверка, а есть ли вообще что-то в объекте, если все ок, то дальше...
            {
                Console.WriteLine("Что-то не так");
                return false;
            }

            obj = obj as Dvig; //AS служит для перевода объекта к указанному типу, 
                               // в случае невозможности
                               //привести объект к указанному типу мы вместо исключения получим null.
                               // был какой-то объект, мы превратили в вагон.
                               // если у нас получилось, то объект не равен нулю и следовательно вагон.
            if (obj != null)
            {
                Console.WriteLine("Двигатель - часть авто.");
                return true;
            }

            Console.WriteLine("Двигатель не подходит к контексту.");
            return false;

        }
        public void Driving() // реализация интерфейса
        {
            Console.WriteLine("Транспорт остановился");
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + numberOfDvig;
        }


        public override string ToString()
        {
            return base.ToString() + " Это двигатель авто.";
        }

    }

}