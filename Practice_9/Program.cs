using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage[] storages = new Storage[3];

            storages[0] = new Flash("Kingston", "DT50", 100, 32);
            storages[1] = new DVD("Verbatim", "DVD-R", 10, "односторонний");
            storages[2] = new HDD("Seagate", "Expansion", 60, 2, new double[] { 250, 250 });

            // Выводим информацию об устройствах
            foreach (Storage s in storages)
            {
                s.GetDeviceInfo();
                Console.WriteLine();
            }

            // Рассчитываем общий объем памяти всех устройств
            double totalMemorySize = 0;
            foreach (Storage s in storages)
            {
                totalMemorySize += s.GetMemorySize();
            }
            Console.WriteLine("Общий объем памяти всех устройств: {0} Гб", totalMemorySize);
            Console.WriteLine();

            // Копируем информацию на устройства
            double dataSize = 565;
            foreach (Storage s in storages)
            {
                s.CopyData(dataSize);
                Console.WriteLine();
            }

            // Рассчитываем время, необходимое для копирования
            double time = 0; // время в секундах
            foreach (Storage s in storages)
            {
                if (s is Flash) // если устройство - флешка
                {
                    Flash f = (Flash)s;
                    time = dataSize * 1024 / f.UsbSpeed;
                }
                else if (s is DVD) // если устройство - диск
                {
                    DVD d = (DVD)s;
                    time = dataSize * 1024 / d.ReadWriteSpeed;
                }
                else if (s is HDD) // если устройство - HDD
                {
                    HDD h = (HDD)s;
                    time = dataSize * 1024 / h.UsbSpeed;
                }
                Console.WriteLine("Время, необходимое для копирования {0} Гб данных на устройство {1} {2}: {3} секунд", dataSize, s.Name, s.Model, time);
            }
            Console.WriteLine();

            // Рассчитываем необходимое количество носителей информации представленных типов для переноса информации
            int flashCount = 0;
            int dvdCount = 0;
            int hddCount = 0;
            foreach (Storage s in storages)
            {
                if (s is Flash) // если устройство - флешка
                {
                    Flash f = (Flash)s;
                    flashCount = (int)Math.Ceiling(dataSize / f.GetMemorySize());
                }
                else if (s is DVD) // если устройство - диск
                {
                    DVD d = (DVD)s;
                    dvdCount = (int)Math.Ceiling(dataSize / d.GetMemorySize());
                }
                else if (s is HDD) // если устройство - HDD
                {
                    HDD h = (HDD)s;
                    hddCount = (int)Math.Ceiling(dataSize / h.GetMemorySize());
                }
            }
            Console.WriteLine("Необходимое количество носителей информации для переноса {0} Гб данных:", dataSize);
            Console.WriteLine("Флешек: {0}", flashCount);
            Console.WriteLine("Дисков: {0}", dvdCount);
            Console.WriteLine("HDD: {0}", hddCount);
        }
    }
}