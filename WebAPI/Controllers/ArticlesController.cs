using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{ArticleId}")]
        public async Task<IActionResult> GetArticle(int articleId)
        {
            return Ok(await _mediator.Send(new GetArticleByIdQuery() { ArticleId = articleId }));
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            return Ok(await _mediator.Send(new GetAllArticlesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            return Ok(await _mediator.Send(new CreateArticleCommand()
            {
                ArticleId = article.ArticleId,
                ArticleText = article.ArticleText,
                ArticleKarma = article.ArticleKarma,
                AuthorId = article.AuthorId
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int articleId, UpdateArticleCommand command)
        {
            if (articleId != command.ArticleId)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{Article_ID}")]
        public async Task<IActionResult> Delete(int articleId)
        {
            return Ok(await _mediator.Send(new DeleteArticleCommand() { ArticleId = articleId }));
        }
    }
}