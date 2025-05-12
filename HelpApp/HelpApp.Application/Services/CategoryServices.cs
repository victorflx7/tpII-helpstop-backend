using HelpApp.Application.Interfaces;
using AutoMapper;
using HelpApp.Domain.Interfaces;
using HelpApp.Application.DTOs;
using HelpApp.Application.Interface;

namespace HelpApp.Application.Services
{
    public class CategoryServices : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Add(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}