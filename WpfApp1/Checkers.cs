using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    static internal class Checkers
    {
        static public bool PowerCheck()
        {
            gpu gpu = SelectedComponents.gpu as gpu;
            powersupply powersupply = SelectedComponents.powersupply as powersupply;
            if (gpu != null && powersupply != null)
            {
                if (gpu.recommendpower > powersupply.power)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Мощность видеокарты больше мощности блока питания. Вы уверены что хотите продолжить?", "Предупреждение", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.No)
                    { 
                        return false;
                    }
                }
            }
            return true;
        }
        static public bool FormFactorCheck()
        {
            motherboard motherboard = SelectedComponents.motherboard as motherboard;
            @case @case = SelectedComponents.@case as @case;
            if (motherboard != null && @case != null)
            {
                boardformfactorcase condition = Core.Context.boardformfactorcase.FirstOrDefault(i => i.caseid == @case.id && i.formfactorid == motherboard.formfactorid);
                if (condition == null)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Формфактор материнской платы и корпуса не совпадает. Хотите продолжить?", "Предупреждение", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.No)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static public bool SocketCheck()
        {
            motherboard motherboard = SelectedComponents.motherboard as motherboard;
            cpu cpu = SelectedComponents.cpu as cpu;
            processorcooler processorcooler = SelectedComponents.processorcooler as processorcooler;
            if (cpu != null && motherboard != null)
            {
                if (cpu.socketid != motherboard.socketid)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Сокет на материнской плате и сокет процессора не совпадают. Вы уверены что хотите продолжить?", "Предупреждение", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.No)
                    {
                        return false;
                    }
                }
                
            }
            else if (cpu != null && processorcooler != null)
            {
                var l_1 = cpu.socket.socketprocessorcooler;
                var l_2 = processorcooler.socketprocessorcooler;
                foreach (socketprocessorcooler item in l_1)
                {
                    if (l_2.Contains(item))
                    { return true; }
                }
                MessageBoxResult dialogResult = MessageBox.Show("Кулер не подходит к данному процессору. Вы уверены что хотите продолжить?", "Предупреждение", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.No)
                {
                    return false;
                }
            }
            return true;
        }
        
        static public bool RamTypeCheck()
        {
            ram ram = SelectedComponents.ram as ram;
            motherboard motherboard = SelectedComponents.motherboard as motherboard;
            if (ram != null && motherboard != null)
            {
                if (ram.memorytypeid != motherboard.memorytypeid)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Тип памяти в материнской плате и в оперативной памяти не совпдают. Хотите продолжить?", "Предупреждение", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.No)
                    {
                        return false;
                    }
                }
            }
            return true;
            
        }

        static public bool MotherboardChecks()
        {
            if (SocketCheck())
            { 
                if (RamTypeCheck())
                { 
                    return FormFactorCheck();
                }
            }
            return false;
        }

        static public bool FinalCheck()
        {
            ram ram = SelectedComponents.ram as ram;
            motherboard motherboard = SelectedComponents.motherboard as motherboard;
            cpu cpu = SelectedComponents.cpu as cpu;
            processorcooler processorcooler = SelectedComponents.processorcooler as processorcooler;
            gpu gpu = SelectedComponents.gpu as gpu;
            powersupply powersupply = SelectedComponents.powersupply as powersupply;
            @case @case = SelectedComponents.@case as @case;
            if (ram.memorytypeid != motherboard.memorytypeid)
            {

                return false;
            }
            if (cpu.socketid != motherboard.socketid)
            {
                return false;
            }
            
            if ((Core.Context.boardformfactorcase.FirstOrDefault(i => i.caseid == @case.id && i.formfactorid == motherboard.formfactorid) == null))
            {
                return false;
            }
            if ((Core.Context.socketprocessorcooler.FirstOrDefault(i => i.processorcoolerid == processorcooler.id && i.socketid == cpu.socket.id) == null))
            {
                return false;
            }
            if (gpu.recommendpower > powersupply.power)
            {
                return false;
            }
            return true;
        }   

    }
}
