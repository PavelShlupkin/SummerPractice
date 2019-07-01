using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interface
{
    public interface IAnswardDAO
    {
        IEnumerable<Answard> GetAll();

        IEnumerable<Answard> GetPresentAnsward();

        void Add(Answard value);

        void Present(PresentAnsward value);

        void RemoveByID(int ID);

        Answard GetByID(int ID);

        void UpdateAnsward(int ID, string Title);

        IEnumerable<Answard> GetUserAnsward(int ID_user);

        void Delete(int ID);
        IEnumerable<Answard> findAnsward(int ID, string Name);
    }
}
