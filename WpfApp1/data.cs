using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    static internal class data
    {
        static public List<cpu> CPU_lst = Core.Context.basepart.Where(i => i.parttype.name == "CPU").ToList()
            .ConvertAll(new Converter<basepart, cpu>(base_to_CPU));
        static public List<gpu> GPU_lst = Core.Context.basepart.Where(i => i.parttype.name == "GPU").ToList()
            .ConvertAll(new Converter<basepart, gpu>(base_to_GPU));
        static public List<ram> RAM_lst = Core.Context.basepart.Where(i => i.parttype.name == "RAM").ToList()
            .ConvertAll(new Converter<basepart, ram>(base_to_RAM));
        static public List<motherboard> Motherboard_lst = Core.Context.basepart.Where(i => i.parttype.name == "Motherboard").ToList()
            .ConvertAll(new Converter<basepart, motherboard>(base_to_Motherboard));
        static public List<@case> Case_lst = Core.Context.basepart.Where(i => i.parttype.name == "Case").ToList()
            .ConvertAll(new Converter<basepart, @case>(base_to_Case));
        static public List<powersupply> PowerSupply_lst = Core.Context.basepart.Where(i => i.parttype.name == "PowerSupply").ToList()
            .ConvertAll(new Converter<basepart, powersupply>(base_to_power));
        static public List<processorcooler> ProcessorCooler_lst = Core.Context.basepart.Where(i => i.parttype.name == "ProcessorCooler").ToList()
            .ConvertAll(new Converter<basepart, processorcooler>(base_to_cooler));
        static public List<storagedevice> StorageDevice_lst = Core.Context.basepart.Where(i => i.parttype.name == "StorageDevice").ToList()
            .ConvertAll(new Converter<basepart, storagedevice>(base_to_storage));

        static cpu base_to_CPU(basepart basep)
        {
            return (cpu)basep;
        }

        static gpu base_to_GPU(basepart basep)
        {
            return (gpu)basep;
        }

        static ram base_to_RAM(basepart basep)
        {
            return (ram)basep;
        }

        static motherboard base_to_Motherboard(basepart basep)
        {
            return (motherboard)basep;
        }

        static @case base_to_Case(basepart basep)
        {
            return (@case)basep;
        }

        static powersupply base_to_power(basepart basep)
        {
            return (powersupply)basep;
        }

        static processorcooler base_to_cooler(basepart basep)
        {
            return (processorcooler)basep;
        }
        static storagedevice base_to_storage(basepart basep)
        {
            return (storagedevice)basep;
        }
    }
}
