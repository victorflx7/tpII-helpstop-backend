using HelpApp.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelpApp.Application.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task <CategoryDTO> GetbyId(int? id);
        Task Add(CategoryDTO categoryDTO);
        Task Remove(int? id);
        Task Update(CategoryDTO categoryDTO);
    }
}
