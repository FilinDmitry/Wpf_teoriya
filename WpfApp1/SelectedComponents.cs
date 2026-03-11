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
        static basepart previous_detail;
        static public List<basepart> lst;
        static public void set_part(basepart part)
        {
            switch (part.parttypeid)
            {
                case 1:
                    previous_detail = cpu;
                    cpu = part;
                    if (!Checkers.SocketCheck())
                    { cpu = previous_detail; }
                    break;
                case 2:
                    previous_detail = gpu;
                    gpu = part;
                    if (!Checkers.PowerCheck())
                    { gpu = previous_detail; }
                    break;
                case 3:
                    previous_detail = ram;
                    ram = part;
                    if (!Checkers.RamTypeCheck())
                    { ram = previous_detail; }
                    break;
                case 4:
                    previous_detail = motherboard;
                    motherboard = part;
                    if (!Checkers.MotherboardChecks())
                    { motherboard = previous_detail; }
                    break;
                case 5:
                    previous_detail = @case;
                    @case = part;
                    if (!Checkers.FormFactorCheck())
                    { @case = previous_detail; }
                    break;
                case 6:
                    previous_detail = powersupply;
                    powersupply = part;
                    if (!Checkers.PowerCheck())
                    { powersupply = previous_detail; }
                    break;
                case 7:
                    previous_detail = processorcooler;
                    processorcooler = part;
                    if (!Checkers.SocketCheck())
                    { processorcooler = previous_detail; }
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
                return false;
            }
            if (gpu == null)
            {
                return false;
            }
            if (motherboard == null)
            {
                return false;
            }
            if (ram == null)
            {
                return false;
            }
            if (@case == null)
            {
                return false;
            }
            if (powersupply == null)
            {
                return false;
            }
            if (processorcooler == null)
            {
                return false;
            }
            if (storagedevice == null)
            {
                return false;
            }
            lst = new List<basepart> { cpu, gpu, ram, motherboard, @case, powersupply, processorcooler, storagedevice };
            return true;
        }

    }

    
}
