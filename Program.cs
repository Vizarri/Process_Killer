using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Process_Killer
{
    class Program
    {
        static void Main(string[] args)
        {
            Watcher watcher = new Watcher(args[0], int.Parse(args[1]));
            bool flag = true;

            //реализация постоянной проверки через каждые X минут , которые были заданы 
            while (flag)
            {
                System.Threading.Thread.Sleep(int.Parse(args[2]) * 60000);
                watcher.Wiewer();
            }

        }
    }
}
    



