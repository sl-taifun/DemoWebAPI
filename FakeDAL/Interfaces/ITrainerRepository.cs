using FakeDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDAL.Interfaces
{
    public interface ITrainerRepository
    {
        public IEnumerable<Trainer> GetAll();
        public Trainer? GetById(int id);
        public Trainer Add(Trainer trainer);
        public Trainer Update(int id, Trainer trainer);
        public bool Delete(int id);
    }
}
