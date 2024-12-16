using System.ComponentModel.DataAnnotations;
using ToDoList.Application.DTOs.AssignmentList;

namespace ToDoList.API.ViewModels.AssignmentList
{
    public class CreateAssignmentListViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters")]
        public string Name { get; set; } = null!;
        
        public Guid UserId { get; set; }

        public AssignmentListDto ToDto()
        {
            return new AssignmentListDto
            {
                Name = Name,
                UserId  = UserId
            };
        }
    }
}