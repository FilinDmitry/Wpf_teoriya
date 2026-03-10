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
            if (gpu != null || powersupply != null)
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
        static public bool FormFactor()
        {
            motherboard motherboard = SelectedComponents.motherboard as motherboard;
            @case @case = SelectedComponents.@case as @case;
            if (motherboard != null || @case != null)
            {
                //if (motherboard.formfactorid != @case.boardformfactorcase)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Формфактор материнской платы и корпуса не совпадает", "Предупреждение", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.No)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
