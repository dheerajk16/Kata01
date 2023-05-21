using FillForm.Data;
using FillForm.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FillForm.Data.Repositories
{
    public interface IFormDataRepository
    {
        Task AddFormDataAsync(FormData formData);

        Task<FormData?> GetFormDataAsync();

        Task<bool> DeleteFormDataAsync();
    }

    public class FormDataRepository : IFormDataRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FormDataRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFormDataAsync(FormData formData)
        {
            var existingData = await this.GetFormDataAsync();

            if (existingData != null)
            {
                existingData.FirstName = formData.FirstName;
                existingData.LastName = formData.LastName;
                existingData.YearOfJoin = formData.YearOfJoin;
            }
            else
            {
                _dbContext.FormDatas.Add(formData);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FormData?> GetFormDataAsync()
        {
            return await _dbContext.FormDatas.FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteFormDataAsync()
        {
            var allFormData = _dbContext.FormDatas.ToList();

            foreach (var fd in allFormData)
            {
                _dbContext.FormDatas.Remove(fd);
            }
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
