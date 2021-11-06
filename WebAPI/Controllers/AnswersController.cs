using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Answer> GetAllAnswers()
        {
            var answers = _unitOfWork.Answers.GetAll();
            var count = _unitOfWork.Answers.CountEntities();
            Response.Headers.Add("X-Total-Count", count.ToString());
            return answers;
        }
        [Route("GetById/{AnswerId}")]
        [HttpGet]
        public Answer GetAnswer(int AnswerId)
        {
            var answer = _unitOfWork.Answers.GetById(AnswerId);
            return answer;
        }
        [Route("GetByQuestionId/{QuestionId}")]
        [HttpGet]
        public IEnumerable<Answer> GetAllAnswersForQuestion(int QuestionId)
        {
            var answers = _unitOfWork.Answers.GetAnswersForQuestion(QuestionId);
            return answers;
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult AddAnswer(string Title, int QuestionId, string AnsweredBy = "Anonymous")
        {
            var answer = new Answer
            {
                Title = Title,
                QuestionId = QuestionId,
                AnsweredBy = AnsweredBy,
                LastModified = DateTime.Now,
            };
            _unitOfWork.Answers.Add(answer);
            _unitOfWork.Complete();
            return Ok();
        }
        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateAnswer(int AnswerId, string? Title, int? QuestionId, string? AnsweredBy)
        {
            var answer = _unitOfWork.Answers.GetById(AnswerId);
            if (Title != null) answer.Title = Title;
            if (QuestionId != null) answer.QuestionId = (int)QuestionId;
            if (AnsweredBy != null) answer.AnsweredBy = AnsweredBy;
            answer.LastModified = DateTime.Now;
            _unitOfWork.Answers.Update(answer);
            _unitOfWork.Complete();
            return Ok();
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteAnswer(int Id)
        {
            var answer = _unitOfWork.Answers.GetById(Id);
            _unitOfWork.Answers.Remove(answer);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
