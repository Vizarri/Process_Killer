using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;

namespace Process_Killer
{
    // Класс проверяет есть ли процесс, который живет дольше чем нужно и убивает его , если находит такой.
    class Watcher
    {
        //Поля
        private string killsProcessName;
        private int maxTimeOfLifeProcess;

        //Свойства
        public string KillsProcessName{get { return killsProcessName; }}
        public int MaxTimeOfLifeProcess { get { return maxTimeOfLifeProcess; } }

        //Конструктор , принимающий 2 аргумента: 1.имя процесса , 2.сколько минут ему "можно жить"
        public Watcher (string killsProcessName, int maxTimeOfLifeProcess)
        {
           this.killsProcessName=killsProcessName;
           this.maxTimeOfLifeProcess=maxTimeOfLifeProcess;
    }


        //Метод, убивающий процесс , который живет "maxTimeOfLifeProces" минут.
        public void Wiewer()
        {
            Console.WriteLine("Проверка запущена");
            // перебор всех процессов запущенных на текущей машине
            foreach (Process process in Process.GetProcesses())
            {
                // try catch используется в роли ловушки idle , без нее значения StartTime не выводятся
                try
                {
                    // вычисляет в минутах разницу между текущим временем и временем старта процесса, т.е сколько процесс живет в минутах
                    DateTime NowTime = DateTime.Now;
                    int dateDiff = (int)(NowTime - process.StartTime).TotalMinutes;

                    // Проверка на совпадение , если имя процесса совпадает с условиями - убиваем процесс
                    if (process.ProcessName == KillsProcessName && dateDiff >= MaxTimeOfLifeProcess)
                    {
                        process.Kill();

                        // логирование в консоль
                        Console.WriteLine(KillsProcessName + " is killed");
                    }
                }
                catch (Exception)
                { }
            }
        }


    }

}

