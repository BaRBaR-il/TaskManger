using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManger
{
    public class Tasks
    {
        private string name;
        private DateTime date;
        private string priorty;

        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Priorty { get => priorty; set => priorty = value; }
        public override string ToString()
        {
            return $"{name} (דחיפות: {priorty}) - תאריך יעד: {date:dd/MM/yyyy}";
        }
    }

}
