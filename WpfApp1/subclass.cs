using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    
    partial class PR15_BuilderPCEntities
    {
        public virtual DbSet<cpu> cpu { get; set; }
        public virtual DbSet<cpu> gpu { get; set; }
        public virtual DbSet<@case> @case { get; set; }
        public virtual DbSet<processorcooler> processorcooler { get; set; }
        public virtual DbSet<ram> ram { get; set; }
        public virtual DbSet<motherboard> motherboard { get; set; }
        public virtual DbSet<powersupply> powersupply { get; set; }
        public virtual DbSet<storagedevice> storagedevice { get; set; }
        

    }
}
