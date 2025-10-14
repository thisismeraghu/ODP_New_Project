using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class ModifiedInfo
    {
        public Guid Fcb { get; set; }
        public Guid Lub { get; set; }
        public DateTime Fcd { get; set; }
        public DateTime Lud { get; set; }

        public ModifiedInfo() { }
        public ModifiedInfo(Guid fcb,Guid lub, DateTime fcd, DateTime lud) { 
            Fcb = fcb;
            Lub = lub;
            Fcd = fcd;
            Lud = lud;
        } // Parameterless constructor for EF Core
        
    }

}
