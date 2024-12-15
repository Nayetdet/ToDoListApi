using System.ComponentModel.DataAnnotations;
using ToDoList.Application.DTOs.AssignmentList;

namespace ToDoList.API.ViewModels.AssignmentList
{
    public class UpdateAssignmentListViewModel
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters")]
        public string Name { get; set; } = null!;

        public AssignmentListDto ToDto()
        {
            return new AssignmentListDto
            {
                Id = Id,
                Name = Name
            };
        }
    }
}