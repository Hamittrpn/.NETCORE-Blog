using System;
using System.Collections.Generic;
using HamitTirpanBlog.Data;
using HamitTirpanBlog.Model.Entities;

namespace HamitTirpanBlog.Service
{
    public interface ICategoryService
    {
        void Insert(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void Delete(Guid id);
        Category Find(Guid id);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAllByName(string name);
        IEnumerable<Category> Search(string name);
    }
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
        }

        public void Delete(Category entity)
        {
            categoryRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var deleteToCategory = categoryRepository.Find(id);
            if (deleteToCategory != null)
            {
                categoryRepository.Delete(deleteToCategory);
                unitOfWork.SaveChanges();
            }
        }

        public Category Find(Guid id)
        {
            return categoryRepository.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAllByName(string name)
        {
            return categoryRepository.GetAll(c => c.Name.Contains(name));
        }

        public void Insert(Category entity)
        {
            categoryRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Category> Search(string name)
        {
            return categoryRepository.GetAll(c => c.Name.Contains(name));
        }

        public void Update(Category entity)
        {
            var category = categoryRepository.Find(entity.Id);
            category.Name = entity.Name;
            category.Description = entity.Description;
            categoryRepository.Update(category);
            unitOfWork.SaveChanges();
        }
    }
}
