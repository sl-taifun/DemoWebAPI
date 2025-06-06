using FakeDAL.Entities;
using FakeDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDAL.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private static List<Trainer> _trainers = new List<Trainer>
        {
            new Trainer { Id = 1, FirstName = "Aude", LastName = "Beurive", BirthDate = new DateTime(1989,11,11), OnVacation = true },
            new Trainer { Id = 2, FirstName = "Aurelien", LastName = "Strimelle", BirthDate = new DateTime(1985,5,23), OnVacation = false },
            new Trainer { Id = 3, FirstName = "Bob", LastName = "Johnson", BirthDate = new DateTime(1990,2,14), OnVacation = false },
            new Trainer { Id = 4, FirstName = "Eve", LastName = "Taylor", BirthDate = new DateTime(1992,8,30), OnVacation = true },
            new Trainer { Id = 5, FirstName = "Charlie", LastName = "Brown", BirthDate = new DateTime(1987,3,12), OnVacation = false },
            new Trainer { Id = 6, FirstName = "Diana", LastName = "Miller", BirthDate = new DateTime(1983,7,19), OnVacation = true }

        };

        private static int _nextId = 7;
        public Trainer Add(Trainer trainer)
        {
            trainer.Id = ++_nextId;
            _trainers.Add(trainer);
            return trainer;
        }

        public IEnumerable<Trainer> GetAll()
        {
            return _trainers;
        }

        public Trainer? GetById(int id)
        {
            return _trainers.FirstOrDefault(t => t.Id == id);
        }

        public Trainer? Update(int id, Trainer trainer)
        {
            Trainer? trainerToUpdate = _trainers.FirstOrDefault(t => t.Id == id);
            if (trainerToUpdate != null)
            {
                trainerToUpdate.FirstName  = trainer.FirstName;
                trainerToUpdate.LastName   = trainer.LastName;
                trainerToUpdate.BirthDate  = trainer.BirthDate;
                trainerToUpdate.OnVacation = trainer.OnVacation;

                return trainerToUpdate;
            }
            return trainerToUpdate;
        }

        public bool Delete(int id)
        {
            Trainer? trainer = _trainers.FirstOrDefault(t => t.Id == id);
            return _trainers.Remove(trainer);
           
        }

    }
}
