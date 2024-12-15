using System.ComponentModel.DataAnnotations;
using ToDoList.Application.DTOs.Assignment;

namespace ToDoList.API.ViewModels.Assignment
{
    public class UpdateAssignmentViewModel
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255, ErrorMessage = "Description must not exceed 255 characters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "UserId is required")]
        public Guid UserId { get; set; }

        public Guid? AssignmentListId { get; set; }

        public bool Concluded { get; set; }

        public DateTime? ConcludedAt { get; set; }

        public DateTime? Deadline { get; set; }

        public AssignmentDto ToDto()
        {
            return new AssignmentDto
            {
                Id = Id,
                Description = Description,
                UserId = UserId,
                AssignmentListId = AssignmentListId,
                Concluded = Concluded,
                Deadline = Deadline,
            };
        }
    }
}