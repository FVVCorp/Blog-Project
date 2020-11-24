using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
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
            return Ok(await _mediator.Send(new GetArticleByIdQuery(articleId)));
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            return Ok(await _mediator.Send(new GetAllArticlesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            return Ok(await _mediator.Send(new CreateArticleCommand(article)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Article article)
        {
            return Ok(await _mediator.Send(new UpdateArticleCommand(article)));
        }

        [HttpDelete("{ArticleId}")]
        public async Task<IActionResult> Delete(int articleId)
        {
            return Ok(await _mediator.Send(new DeleteArticleCommand(articleId)));
        }
    }
}