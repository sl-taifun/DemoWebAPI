using FakeDAL.Entities;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(150, ErrorMessage = "First name cannot exceed 150 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(150, ErrorMessage = "Last name cannot exceed 150 characters")]
        [RegularExpression(@"^[\p{L} \-]+$", ErrorMessage = "Seules les lettres, espaces et tirets sont autorisés")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        [DataType(DataType.Date, ErrorMessage = "Birth date must be a valid date")]
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
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(150, ErrorMessage = "First name cannot exceed 150 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(150, ErrorMessage = "Last name cannot exceed 150 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birth date is required")]
        [DataType(DataType.Date, ErrorMessage = "Birth date must be a valid date")]
        public DateTime BirthDate { get; set; }
        public bool OnVacation { get; set; }

        public static Trainer ToEntity( UpdateTrainerDTO dto)
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
