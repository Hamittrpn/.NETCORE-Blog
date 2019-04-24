using System;
using System.Collections.Generic;
using HamitTirpanBlog.Data;
using HamitTirpanBlog.Model.Entities;
using HamitTirpanBlog.Service;

namespace HamitTirpanBlog.Service
{
    public interface IFeedbackService
    {
        void Insert(Feedback entity);
        void Delete(Feedback entity);
        void Delete(Guid id);
        Feedback Find(Guid id);
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetAllByName(string name);
        IEnumerable<Feedback> Search(string name);
    }
}
public class FeedbackService : IFeedbackService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IRepository<Feedback> feedbackRepository;

    public FeedbackService(IUnitOfWork unitOfWork, IRepository<Feedback> feedbackRepository)
    {
        this.unitOfWork = unitOfWork;
        this.feedbackRepository = feedbackRepository;
    }

    public void Delete(Feedback entity)
    {
        feedbackRepository.Delete(entity);
        unitOfWork.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var deleteToFeedback = feedbackRepository.Find(id);
        if (deleteToFeedback != null)
        {
            feedbackRepository.Delete(deleteToFeedback);
            unitOfWork.SaveChanges();
        }
    }

    public Feedback Find(Guid id)
    {
        return feedbackRepository.Find(id);
    }

    public IEnumerable<Feedback> GetAll()
    {
        return feedbackRepository.GetAll();
    }

    public IEnumerable<Feedback> GetAllByName(string name)
    {
        return feedbackRepository.GetAll(f => f.Name.Contains(name));
    }

    public void Insert(Feedback entity)
    {
        feedbackRepository.Insert(entity);
        unitOfWork.SaveChanges();
    }

    public IEnumerable<Feedback> Search(string name)
    {
        return feedbackRepository.GetAll(f => f.Name.Contains(name));
    }
}
