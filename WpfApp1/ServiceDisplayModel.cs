using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ServiceDisplayModel
    {
        public Service service { get; set; }

        public string Date => "Дата: " + service.Date.ToString("dd.MM.yy");
        public string Time => "Время: " + service.Date.ToString("HH:mm");
        public string Type => service.ServiceType.Name;
        
    }
}
