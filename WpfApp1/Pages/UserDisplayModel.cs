using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Pages
{
    public class UserDisplayModel
    {
        public User User { get; set; }
        public List<string> AvailableRoles { get; set; }
        public string SelectedRole { get; set; }

        public int ID => User.ID;
        public string Phone => User.Phone;
        public string FIO => User.FIO;
        
    }
    public class RolesDisplayModel
    {
        public List<string> aroles { get; set; }
    }
}
