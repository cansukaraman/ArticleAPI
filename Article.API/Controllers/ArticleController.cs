using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.Core.Components;
using Article.Core.Model;
using Article.Core.Repositories;
using Article.Core.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Article.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public IArticleRepository articleRepository;
        public ArticleController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = articleRepository.GetAll();
            return new OkObjectResult(response);
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            ArticleModel article = articleRepository.Get(id);

            if (article != null)
                return new OkObjectResult(article);
            else
                return NotFound();
        }

        // POST: api/Default
        [HttpPost]
        public IActionResult Add([FromBody]ArticleModel article)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            article.Created = DateTime.Now;
            article.Status = Enums.Status.Active;

            articleRepository.Add(article);

            return new OkObjectResult(article);
           
        }

        // POST: api/Default/5
        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody]ArticleModel articleModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ArticleModel _articleModel = articleRepository.Get(id);

            if (_articleModel == null)
                return NotFound();

            _articleModel.Title = articleModel.Title;
            _articleModel.Category = articleModel.Category;
            _articleModel.Headline = articleModel.Headline;
            _articleModel.Description = articleModel.Description;
            _articleModel.Status = articleModel.Status;

            bool result = articleRepository.Update(_articleModel);
            if (result)
                return new OkObjectResult(_articleModel);

            else
                return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ArticleModel _article = articleRepository.Get(id);

            if (_article == null)
                return new NotFoundResult();
            else
            {
                articleRepository.Delete(_article);

                return new OkResult();
            }
        }
    }

}