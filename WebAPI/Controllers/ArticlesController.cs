using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("{Article_ID}")]
        public async Task<IActionResult> GetArticle(int Article_ID)
        {
            return Ok(await Mediator.Send(new GetArticleByIdQuery() { Article_ID = Article_ID }));
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            return Ok(await Mediator.Send(new GetAllArticlesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            return Ok(await Mediator.Send(new CreateArticleCommand()
            {
                Article_ID = article.Article_ID,
                Article_Text = article.Article_Text,
                Article_Karma = article.Article_Karma,
                Author_ID = article.Author_ID
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Article_ID, UpdateArticleCommand command)
        {
            if (Article_ID != command.Article_ID)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Article_ID}")]
        public async Task<IActionResult> Delete(int Article_ID)
        {
            return Ok(await Mediator.Send(new DeleteArticleCommand() { Article_ID = Article_ID }));
        }
    }
}