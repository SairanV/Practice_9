using Practice_9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice_9
{
    public class HDD : Storage
    {
        private double usbSpeed;
        private int partitions;
        private double[] partitionSizes;

        public double UsbSpeed { get { return usbSpeed; } }

        public HDD(string name, string model, double usbSpeed, int partitions, double[] partitionSizes):base(name, model)
        {
            this.name = name;
            this.model = model;
            this.usbSpeed = usbSpeed;
            this.partitions = partitions;
            this.partitionSizes = partitionSizes;
        }

        /// <summary>
        /// Переопределенный метод GetMemorySize(): возвращает суммарный объем памяти всех разделов
        /// </summary>
        /// <returns></returns>
        public override double GetMemorySize()
        {
            double totalSize = 0;
            foreach (double size in partitionSizes)
            {
                totalSize += size;
            }
            return totalSize;
        }

        /// <summary>
        /// Переопределенный метод CopyData(): копирует данные на HDD, если есть достаточно свободного места на одном из разделов, иначе выводит сообщение об ошибке
        /// </summary>
        /// <param name="dataSize"></param>
        public override void CopyData(double dataSize)
        {
            bool copied = false;
            for (int i = 0; i < partitions; i++)
            {
                if (dataSize <= partitionSizes[i])
                {
                    partitionSizes[i] -= dataSize;
                    Console.WriteLine("Скопировано {0} Гб данных на HDD {1} {2} на раздел {3}", dataSize, name, model, i + 1);
                    copied = true;
                    break;
                }
            }
            if (!copied)
            {
                Console.WriteLine("Недостаточно свободного места на HDD {0} {1}", name, model);
            }
        }

        /// <summary>
        /// Переопределенный метод GetFreeMemorySize(): возвращает свободный объем памяти на HDD
        /// </summary>
        /// <returns></returns>
        public override double GetFreeMemorySize()
        {
            double freeSize = 0;
            foreach (double size in partitionSizes)
            {
                freeSize += size;
            }
            return freeSize;
        }


        /// <summary>
        /// Переопределенный метод GetDeviceInfo(): выводит информацию об устройстве
        /// </summary>
        public override void GetDeviceInfo()
        {
            Console.WriteLine("Съемный HDD {0} {1}", name, model);
            Console.WriteLine("Скорость USB 2.0: {0} Мб / с", usbSpeed);
            Console.WriteLine("Количество разделов: {0}", partitions);
            Console.WriteLine("Объем разделов: "); for (int i = 0; i < partitions; i++)
            {
                Console.WriteLine("Раздел {0}: {1} Гб", i + 1, partitionSizes[i]);
            }
        }
    }
}