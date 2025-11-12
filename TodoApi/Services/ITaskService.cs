using TodoApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<TaskDto> CreateAsync(CreateTaskDto createDto);
        Task<bool> MarkCompleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
