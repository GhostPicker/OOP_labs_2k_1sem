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
            Train tr1 = new Train("голубой", 540, 1000);
            Train tr2 = new Train("зеленый", 80, 900);
            Train tr3 = new Train("желтый", 14, 400);

         

           
            Print.IamPrinting(tr3);
            tr1.ShowTrain(tr1.n, tr1.color, tr1.price);
            tr2.ShowTrain(tr2.n, tr2.color, tr3.price);
            tr3.ShowTrain(tr3.n, tr3.color, tr3.price);

            Car car1 = new Car("BMW", 5283, 5000, 6, 220);
            Car car2 = new Car("Lada", 8603, 4000, 5, 160);
            Car car3 = new Car("Audi", 1110, 9800, 4, 120);
            Car car4 = new Car("BMW", 5683, 5600, 6, 240);
            Car car5 = new Car("Lada", 5603, 4800, 5, 300);
            Car car6 = new Car("Audi", 3110, 9100, 7, 180);
            car1.ShowCar(car1.mark, car1.number, car1.price, car1.dt, car1.speed);
            car2.ShowCar(car2.mark, car2.number, car2.price, car2.dt, car2.speed);
            car3.ShowCar(car3.mark, car3.number, car3.price, car3.dt, car3.speed);
            car4.ShowCar(car4.mark, car4.number, car4.price, car4.dt, car4.speed);
            car5.ShowCar(car5.mark, car5.number, car5.price, car5.dt, car5.speed);
            car6.ShowCar(car6.mark, car6.number, car6.price, car6.dt, car6.speed);

            if (car1 is Train)
            {
                Console.WriteLine("Ложь!");
            }
            else
                Console.WriteLine("Машина - не поезд!");

            int count = 0;
            object[] ListOfVehicle = new object[6];
            ListOfVehicle[0] = car1;
            ListOfVehicle[1] = car2;
            ListOfVehicle[2] = car3;
            ListOfVehicle[3] = car4;
            ListOfVehicle[4] = car5;
            ListOfVehicle[5] = car6;


            Console.WriteLine();
            Console.WriteLine("Машины с расходом топлива больше 5 литров на 100 км.");
            Console.WriteLine();

            foreach (Car ts in ListOfVehicle)
            {
                count++;
                if (ts.dt > 5) Console.WriteLine(count+ ")"+ ts.mark +" " + ts.number);
            }
            Console.WriteLine();
            Console.Write("Введите желаемую скорость: ");
            int max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Машины с заданной максимальной скоростью.");
            Console.WriteLine();
            count = 0;
            foreach (Car ts in ListOfVehicle)
            {
                count++;
                if (ts.speed > max) Console.WriteLine(count + ")" + ts.mark + " " + ts.number + " max скорость:" + ts.speed);
            }
            Console.WriteLine();
            Agent ag1 = new Agent();

            ag1.Add();
            ag1.Show();
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

   //шестая лаба класс-контейнер транспортное агенство
    
    public class Agent : Vehicle
    {
        object[] ListOfObject = new object[7];
        int count = 0;
        //ListOfObject[0] = tr1;
        //    ListOfObject[1] = tr2;
        //    ListOfObject[2] = tr3;
        //    ListOfObject[3] = train4;
        //    ListOfObject[4] = train5;
        //    ListOfObject[5] = train6;
        //    ListOfObject[6] = train7;
       
        public void Add()
        {
            count = 0;

            if (count == 0)
            {
                ListOfObject[count] = new Train("red", 10, 100);
                count++;
            }
            if (count == 1)
                {
                    ListOfObject[count] = new Train("blue", 12, 700);
                    count++;
                }
            if (count == 2)
            {
                ListOfObject[count] = new Train("green", 9, 890);
                count++;
            }
            if (count == 3)
            {
                ListOfObject[count] = new Train("yellow", 13, 876);
                count++;
            }
            if (count == 4)
            {
                ListOfObject[count] = new Car("mercedes", 123, 700, 7, 180);
                count++;
            }
            if (count == 5)
            {
                ListOfObject[count] = new Car("audi", 10, 600,8 , 90);
                count++;
            }
            if (count == 6)
            {
                ListOfObject[count] = new Car("bmw", 1, 654, 7, 220);
                count++;
            }          
        }
        public void Delete()
        {
            count = 0;
            while (count < 7)
            {
                ListOfObject[count] = null;
                count++;
            }
        }
        public void Show()
        {
            count = 0;
            while (count < 7)
            {
                Console.WriteLine(ListOfObject[count]); 
                count++;
            }
        }
        public override void Move()//переопределяем метод "движение" класса-родителя
        {
            Console.WriteLine("Поезд движется.");
        }
        public override string ToString()
        {
            return base.ToString() + "Переопределение toString() выполнено.";
        }
        public override void metod()
        {
            Console.WriteLine("Метод для абстрактного класса");
        }
    }
    public abstract class Vehicle //Абстрактный класс "Транспортное средство"
    {
        protected float Speed; //наследуемое значение скорости
        public abstract void Move(); //абстрактный метод "движение"
        internal bool PartOfVehicle; // методы для всех производных абстрактного класса
        public int price;

        public float GetCurrentSpeed()
        {
            return Speed;
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public abstract void metod();/////////////////////////////////////////////////////////в абстрактном классе
        //4 6 8
        struct speed
        {
            private int min; 
            private int average;
            private int max;

            public speed( int min, int average, int max)
            {
                this.min = min;
                this.average = average;
                this.max = max;
            }
            public void AvSpeed(int min, int average, int max)
            {
                int sum = min + average + max;
                sum = sum / 3;
                Console.WriteLine($"Average speed = {sum}");
            }
        }
        
        //класс контроллер
        partial class ControlElement
        {

            int id;
            int size;
            public bool isActive { get; set; }
            public ControlElement Next { get; set; }
            public ControlElement(bool isAct, int id, int size)
            {
                this.isActive = isAct;
                this.id = id;
                this.size = size;
            }
            public ControlElement NextElement()
            {
                return this.Next;
            }
            public void Switch()
            {
                if (isActive)
                {
                    isActive = false;
                }
                else
                {
                    isActive = true;
                }
            }
            public void Status()
            {
                Console.WriteLine($"Element is {this.GetType()}. Is active = {isActive}. Id = {id}. Size = {size}");
            }
            public override string ToString()
            {
                return $"Объект типа {this.GetType()}";
            }
        }

        enum speed_v : int
        {
            min = 1,
            average,
            max,
            super
        }
        speed op;
    }



    public class Train : Vehicle
    {
        public string color;
        public int n;
        public Train(string color, int n, int price)
        {
            this.color = color;
            this.n = n;
            this.price = price;

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
        public virtual void ShowTrain(int n, string col, int price)
        {
            Console.WriteLine($"Поезд с номером {n} имеет {col} цвет! цена {price} $");
        }
        /////////////////////////////////////////////////////////  инициализация абстрактноо метода
        public override void metod()
        {
            Console.WriteLine("Метод для абстрактного класса");
        }
    }


}
interface Istop // интерфейс, в котором есть метод "остановиться", если мы пропишем этот интерфейс какому-нибудь классу, этот класс выполнит это

{
    void Stopping();
    void metod();/////////////////////////////////////////////////////////  такой же метод как в интерфейсе
}

// бесплодный класс, от которого невозможно наследование
// но он наследуется от класса мяч.
// и он будет наследовать интерфейс для тенниса.


public partial class Car : Vehicle
{
    public string mark;
    public int number;
    public int dt;
    public int speed;
  
    

    public Car(string mark, int number, int price, int dt, int speed )
    {
        this.mark = mark;
        this.number = number;
        this.price = price;
        this.dt = dt;
        this.speed = speed;
    }
    /////////////////////////////////////////////////////////    переопределение метода
    public override void metod()
    {
        Console.WriteLine("Метод для абстрактного класса");
    }
    public override void Move()//переопределяем метод "движение" класса-родителя
    {
        Console.WriteLine("Машина движется.");
    }

    public override string ToString()
    {
        return base.ToString() + "Переопределение toString() выполнено.";
    }
    public void ShowCar(string mark, int number, int price, int dt, int speed)
    {
        Console.WriteLine($"Машина {mark} с номером {number} цена {price}$ расход топлива {dt} максимальная скорость {speed}");
    }
    interface IDrive
    {
        void Driving();
    }


        // использование as 

      
       

    

}