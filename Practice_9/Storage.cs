using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    public abstract class Storage
    {
        protected string name;
        protected string model;

        public string Name { get { return name; } }
        public string Model { get { return model; } }

        public Storage(string name, string model)
        {
            this.name = name;
            this.model = model;
        }


        /// <summary>
        /// Абстрактные методы: получение объема памяти, копирование данных, получение информации о свободном объеме памяти, получение общей информации об устройстве
        /// </summary>
        /// <returns></returns>
        public abstract double GetMemorySize();
        public abstract void CopyData(double dataSize);
        public abstract double GetFreeMemorySize();
        public abstract void GetDeviceInfo();
    }
}
