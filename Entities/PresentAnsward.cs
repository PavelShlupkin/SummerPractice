using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PresentAnsward
    {
        public int ID { get; set; }
        public int ID_User { get; set; }    
        public int ID_Answard { get; set; }

        public PresentAnsward()
        { }
        public PresentAnsward(int id_User, int id_Answard)
        {
            ID_User = id_User;
            ID_Answard = id_Answard;
        }
        public override string ToString()
        {
            return $"{ID}. ID User: {ID_User}, ID_Answard: {ID_Answard}";
        }
    }
}
