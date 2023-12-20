using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fridge
{
    internal class operat
    {
        public object id { get; set; }
        public object name { get; set; }
        public object time { get; set; }
        public object action { get; set; }

        //конструкторы класса
        public operat() { }
        public operat(object _id, object _name, object _time, object _action)
        {
            id = _id;
            name = _name;
            time = _time;
            action = _action;
        }

        //методы класса
        public void DataChange(object _id, object _name, object _time, object _action)
        {
            id = _id;
            name = _name;
            time = _time;
            action = _action;
        }


    }
}
