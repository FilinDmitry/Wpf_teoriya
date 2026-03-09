using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfApp1
{
    
    static internal class SelectedComponents
    {
        public static basepart cpu;
        public static basepart gpu;
        public static basepart motherboard;
        public static basepart @case;
        public static basepart processorcooler;
        public static basepart ram;
        public static basepart powersupply;
        public static basepart storagedevice;
        static public List<basepart> lst;
        static public void set_part(basepart part)
        {
            switch (part.parttypeid)
            {
                case 1:
                    cpu = part;
                    break;
                case 2:
                    gpu = part;
                    break;
                case 3:
                    ram = part;
                    break;
                case 4:
                    motherboard = part;
                    break;
                case 5:
                    @case = part;
                    break;
                case 6:
                    powersupply = part;
                    break;
                case 7:
                   processorcooler = part;
                    break;
                case 8:
                    storagedevice = part;
                    break;
            }
        }
        public static bool all_component_selected()
        {
            if (cpu == null)
            {
                MessageBox.Show("Необходимо выбрать процессор");
                return false;
            }
            if (gpu == null)
            {
                MessageBox.Show("Необходимо выбрать видеокарты");
                return false;
            }
            if (motherboard == null)
            {
                MessageBox.Show("Необходимо выбрать материнскую плату");
                return false;
            }
            if (ram == null)
            {
                MessageBox.Show("Необходимо выбрать оперативную память");
                return false;
            }
            if (@case == null)
            {
                MessageBox.Show("Необходимо выбрать корпус");
                return false;
            }
            if (powersupply == null)
            {
                MessageBox.Show("Необходимо выбрать блок питания");
                return false;
            }
            if (processorcooler == null)
            {
                MessageBox.Show("Необходимо выбрать кулер процессора");
                return false;
            }
            if (storagedevice == null)
            {
                MessageBox.Show("Необходимо выбрать накопитель");
                return false;
            }
            lst = new List<basepart> { cpu, gpu, ram, motherboard, @case, powersupply, processorcooler, storagedevice };
            return true;
        }

    }

    
}
