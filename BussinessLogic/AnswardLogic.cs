using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BussinessLogic.Interface;
using DAL;

namespace BussinessLogic
{
    public class AnswardLogic : IAnswardLogic
    {
        private AnswardDAO answardDao = new AnswardDAO();
        public void Add(Answard value)
        {
            answardDao.Add(value);
        }

        public void Present(PresentAnsward value)
        {
            answardDao.Present(value);
        }

        public IEnumerable<Answard> GetAll()
        {
            return answardDao.GetAll();
        }
        public IEnumerable<Answard> GetPresentAnsward()
        {
            return answardDao.GetPresentAnsward();
        }

        public Answard GetByID(int ID)
        {
            return answardDao.GetByID(ID);
        }

        public void Remove(int ID)
        {
            answardDao.RemoveByID(ID);
        }

        public void UpdateAnsward(Answard value)
        {
            answardDao.UpdateAnsward(value);
        }

        public IEnumerable<Answard> GetUserAnsward(int ID_user)
        {
            return (IEnumerable<Answard>)answardDao.GetUserAnsward(ID_user);
        }

        public void findAnsward(string Answard)
        {
            answardDao.findAnsward(Answard);
        }

    }
}
