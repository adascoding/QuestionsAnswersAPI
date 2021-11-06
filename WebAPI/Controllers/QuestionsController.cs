using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Question> GetAllQuestions()
        {
            var questions = _unitOfWork.Questions.GetAll();
            var count = _unitOfWork.Questions.CountEntities();
            Response.Headers.Add("X-Total-Count", count.ToString());
            return questions;
        }
        [Route("{QuestionId}")]
        [HttpGet]
        public Question GetQuestionById(int QuestionId)
        {
            var question = _unitOfWork.Questions.GetById(QuestionId);
            return question;
        }
        [Route("random")]
        [HttpGet]
        public Question GetRandomQuestion()
        {
            var question = _unitOfWork.Questions.GetRandomQuestion();
            return question;
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult AddQuestion(string Title, string AddedBy = "Admin")
        {
            var question = new Question
            {
                Title = Title,
                AddedBy = AddedBy,
                LastModified = DateTime.Now,
            };
            _unitOfWork.Questions.Add(question);
            _unitOfWork.Complete();
            return Ok();
        }
        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateQuestion(int QuestionId, string? Title, string? AddedBy)
        {
            var question = _unitOfWork.Questions.GetById(QuestionId);
            if (Title != null) question.Title = Title;
            if (AddedBy != null) question.AddedBy = AddedBy;
            question.LastModified = DateTime.Now;
            _unitOfWork.Questions.Update(question);
            _unitOfWork.Complete();
            return Ok();
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteQuestion(int Id)
        {
            var question = _unitOfWork.Questions.GetById(Id);
            _unitOfWork.Questions.Remove(question);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
