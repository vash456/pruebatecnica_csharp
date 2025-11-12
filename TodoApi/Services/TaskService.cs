using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _db;

        public TaskService(TaskDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            return await _db.Tasks
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TaskDto {
                    Id = t.Id,
                    Title = t.Title,
                    IsCompleted = t.IsCompleted,
                    CreatedAt = t.CreatedAt
                }).ToListAsync();
        }

        public async Task<TaskDto> CreateAsync(CreateTaskDto createDto)
        {
            var model = new TaskItem {
                Title = createDto.Title
            };
            _db.Tasks.Add(model);
            await _db.SaveChangesAsync();
            return new TaskDto {
                Id = model.Id,
                Title = model.Title,
                IsCompleted = model.IsCompleted,
                CreatedAt = model.CreatedAt
            };
        }

        public async Task<bool> MarkCompleteAsync(int id)
        {
            var t = await _db.Tasks.FindAsync(id);
            if (t == null) return false;
            t.IsCompleted = true;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var t = await _db.Tasks.FindAsync(id);
            if (t == null) return false;
            _db.Tasks.Remove(t);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
