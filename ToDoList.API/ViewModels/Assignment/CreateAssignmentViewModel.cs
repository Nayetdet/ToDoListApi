using System.ComponentModel.DataAnnotations;
using ToDoList.Application.DTOs.Assignment;

namespace ToDoList.API.ViewModels.Assignment
{
    public class CreateAssignmentViewModel
    {
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255, ErrorMessage = "Description must not exceed 255 characters")]
        public string Description { get; set; } = null!;

        public Guid? AssignmentListId { get; set; }

        public DateTime? Deadline { get; set; }

        public AssignmentDto ToDto()
        {
            return new AssignmentDto
            {
                Description = Description,
                AssignmentListId = AssignmentListId,
                Deadline = Deadline,
            };
        }
    }
}