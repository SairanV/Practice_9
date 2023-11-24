using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice_9
{
    public class DVD : Storage
    {
        private double readWriteSpeed;
        private string type;

        public double ReadWriteSpeed { get { return readWriteSpeed; } }

        public DVD(string name, string model, double readWriteSpeed, string type):base(name, model)
        {
            this.name = name;
            this.model = model;
            this.readWriteSpeed = readWriteSpeed;
            this.type = type;
        }

        /// <summary>
        /// Переопределенный метод GetMemorySize(): возвращает объем памяти диска в зависимости от типа
        /// </summary>
        /// <returns></returns>
        public override double GetMemorySize()
        {
            if (type == "односторонний")
            {
                return 4.7;
            }
            else if (type == "двусторонний")
            {
                return 9;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Переопределенный метод CopyData(): копирует данные на диск, если есть достаточно свободного места, иначе выводит сообщение об ошибке
        /// </summary>
        /// <param name="dataSize"></param>        
        public override void CopyData(double dataSize)
        {
            if (dataSize <= GetFreeMemorySize())
            {
                type = "записанный";
                Console.WriteLine("Скопировано {0} Гб данных на диск {1} {2}", dataSize, name, model);
            }
            else
            {
                Console.WriteLine("Недостаточно свободного места на диске {0} {1}", name, model);
            }
        }

        /// <summary>
        /// Переопределенный метод GetFreeMemorySize(): возвращает свободный объем памяти на диске, если он не записан, иначе возвращает 0
        /// </summary>
        /// <returns></returns>        
        public override double GetFreeMemorySize()
        {
            if (type == "записанный")
            {
                return 0;
            }
            else
            {
                return GetMemorySize();
            }
        }

        /// <summary>
        /// Переопределенный метод GetDeviceInfo(): выводит информацию об устройстве
        /// </summary>
        public override void GetDeviceInfo()
        {
            Console.WriteLine("DVD-диск {0} {1}", name, model);
            Console.WriteLine("Скорость чтения/записи: {0} Мб/с", readWriteSpeed);
            Console.WriteLine("Тип: {0}", type);
            Console.WriteLine("Объем памяти: {0} Гб", GetMemorySize());
        }
    }
}
