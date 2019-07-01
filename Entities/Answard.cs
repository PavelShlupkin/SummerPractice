using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Answard
    {
        public int ID { get; set; }
        public int ID_user { get; set; }
        public string Title { get; set; }
      
        public Answard()
        { }
        public Answard(int id, int id_user, string title)
        {
            ID = id;
            ID_user = id_user;
            Title = title;
        }
        public override string ToString()
        {
            return $"{ID}. Название: {Title}";
        }
    }
}
