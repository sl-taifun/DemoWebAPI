using FakeDAL.Entities;

namespace DemoWebAPI.DTO
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool OnVacation { get; set; }

        public TrainerDTO(Trainer entity)
        {
            Id = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            OnVacation = entity.OnVacation;
        }
    }



    public class CreateTrainerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public static Trainer ToEntity(CreateTrainerDTO dto)
        {
            return new Trainer
            {
                Id = 0, // Id will be set by the repository
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                OnVacation = false // Default value
            };
        }
    }

    public class UpdateTrainerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool OnVacation { get; set; }

        public static Trainer ToEntity(int id, UpdateTrainerDTO dto)
        {
            return new Trainer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                OnVacation = dto.OnVacation
            };
        }
    }

   
}
