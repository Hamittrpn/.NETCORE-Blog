using System;
using System.Collections.Generic;
using HamitTirpanBlog.Data;
using HamitTirpanBlog.Model.Entities;

namespace HamitTirpanBlog.Service
{
    public interface IPageService
    {
        void Insert(Page page);
        void Update(Page page);
        void Delete(Page page);
        void Delete(Guid id);
        Page Find(Guid id);
        Page FindByTitle(string title);

        IEnumerable<Page> GetAll();
        IEnumerable<Page> GetAllByTitle(string title);
        IEnumerable<Page> Search(string title);
    }

    public class PageService : IPageService
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IUnitOfWork unitOfWork;
        public PageService(IUnitOfWork unitOfWork, IRepository<Page> pageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.pageRepository = pageRepository;
        }

        public void Delete(Page page)
        {
            unitOfWork.BeginTransaction();
            try
            {
                pageRepository.Delete(page);
                unitOfWork.SaveChanges();
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
            }
        }

        public void Delete(Guid id)
        {
            var page = pageRepository.Find(id);
            if (page != null)
            {
                this.Delete(page);
            }
        }

        public Page Find(Guid id)
        {
            return pageRepository.Find(id);
        }

        public Page FindByTitle(string title)
        {
            title = title.ToLower();
            return pageRepository.Find(e => e.Title.ToLower() == title);
        }

        public IEnumerable<Page> GetAll()
        {
            return pageRepository.GetAll();
        }

        public IEnumerable<Page> GetAllByTitle(string title)
        {
            return pageRepository.GetAll(w => w.Title.Contains(title));
        }

        public void Insert(Page page)
        {
            pageRepository.Insert(page);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Page> Search(string title)
        {
            return pageRepository.GetAll(e => e.Title.Contains(title));
        }

        public void Update(Page page)
        {
            var uppost = pageRepository.Find(page.Id);
            uppost.Title = page.Title;
            uppost.Description = page.Description;
            pageRepository.Update(uppost);
            unitOfWork.SaveChanges();
        }
    }
}
