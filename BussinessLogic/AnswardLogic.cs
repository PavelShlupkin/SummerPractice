using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BussinessLogic.Interface;
using DAL;
using DAL.Interface;

namespace BussinessLogic
{
    public class AnswardLogic : IAnswardLogic
    {
        private IAnswardDAO answardDao;

        public AnswardLogic(IAnswardDAO answardDao)
        {
            this.answardDao = answardDao;
        }
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

        public void UpdateAnsward(int ID, string Title)
        {
            answardDao.UpdateAnsward(ID, Title);
        }

        public IEnumerable<Answard> GetUserAnsward(int ID_user)
        {
            return (IEnumerable<Answard>)answardDao.GetUserAnsward(ID_user);
        }

        public IEnumerable<Answard> findAnsward(int ID, string Name)
        {
            return answardDao.findAnsward(ID, Name);
        }

        public void Delete(int ID)
        {
            answardDao.Delete(ID);
        }
    }
}
