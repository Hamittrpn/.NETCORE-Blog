using System;
using System.Collections.Generic;
using HamitTirpanBlog.Data;
using HamitTirpanBlog.Model.Entities;

namespace HamitTirpanBlog.Service
{
    public interface IPostService
    {
        void Insert(Post entity);
        void Update(Post entity);
        void Delete(Post entity);
        void Delete(Guid id);
        Post Find(Guid id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllByName(string name);
        IEnumerable<Post> Search(string name);
    }

    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Post> postRepository;

        public PostService(IUnitOfWork unitOfWork, IRepository<Post> postRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postRepository = postRepository;
        }

        public void Delete(Post entity)
        {
            postRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var deleteToCategory = postRepository.Find(id);
            if (deleteToCategory != null)
            {
                postRepository.Delete(deleteToCategory);
                unitOfWork.SaveChanges();
            }
        }

        public Post Find(Guid id)
        {
            return postRepository.Find(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return postRepository.GetAll();
        }

        public IEnumerable<Post> GetAllByName(string name)
        {
            return postRepository.GetAll(c => c.Title.Contains(name));
        }

        public void Insert(Post entity)
        {
            postRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Post> Search(string name)
        {
            return postRepository.GetAll(c => c.Title.Contains(name));
        }

        public void Update(Post entity)
        {
            var category = postRepository.Find(entity.Id);
            category.Title = entity.Title;
            category.Description = entity.Description;
            postRepository.Update(category);
            unitOfWork.SaveChanges();
        }
    }
}
