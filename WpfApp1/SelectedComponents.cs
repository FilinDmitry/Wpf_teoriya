using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfApp1
{
    static internal class SelectedComponents
    {
        static basepart cpu;
        static basepart gpu;
        static basepart motherboard;
        static basepart @case;
        static basepart processorcooler;
        static basepart ram;
        static basepart powersupply;
        static basepart storagedevice;
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
    }

    
}
