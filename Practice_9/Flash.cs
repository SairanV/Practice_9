using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice_9
{
    public class Flash : Storage
    {
        private double usbSpeed;
        private double memorySize;

        public double UsbSpeed { get { return usbSpeed; } }

        public Flash(string name, string model, double usbSpeed, double memorySize):base(name, model)
        {
            this.name = name;
            this.model = model;
            this.usbSpeed = usbSpeed;
            this.memorySize = memorySize;
        }

        /// <summary>
        /// Переопределенный метод GetMemorySize(): возвращает объем памяти флешки
        /// </summary>
        /// <returns></returns>
        public override double GetMemorySize()
        {
            return memorySize;
        }

        /// <summary>
        /// Переопределенный метод CopyData(): копирует данные на флешку, если есть достаточно свободного места, иначе выводит сообщение об ошибке
        /// </summary>
        /// <param name="dataSize"></param>
        public override void CopyData(double dataSize)
        {
            if (dataSize <= GetFreeMemorySize())
            {
                memorySize -= dataSize;
                Console.WriteLine("Скопировано {0} Гб данных на флешку {1} {2}", dataSize, name, model);
            }
            else
            {
                Console.WriteLine("Недостаточно свободного места на флешке {0} {1}", name, model);
            }
        }

        /// <summary>
        /// Переопределенный метод GetFreeMemorySize(): возвращает свободный объем памяти на флешке
        /// </summary>
        /// <returns></returns>
        public override double GetFreeMemorySize()
        {
            return memorySize;
        }

        /// <summary>
        /// Переопределенный метод GetDeviceInfo(): выводит информацию об устройстве
        /// </summary>
        public override void GetDeviceInfo()
        {
            Console.WriteLine("Флеш-память {0} {1}", name, model);
            Console.WriteLine("Скорость USB 3.0: {0} Мб/с", usbSpeed);
            Console.WriteLine("Объем памяти: {0} Гб", memorySize);
        }
    }
}
