﻿using Application.Commands;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Task>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Task> Handle(UpdateArticleCommand command, CancellationToken cancellationToken)
        {
            var article = _articleRepository.GetArticle(command.ArticleId);

            if (article.Result != null)
            {
                article.Result.ArticleId = command.ArticleId;
                article.Result.ArticleText = command.ArticleText;
                article.Result.ArticleKarma = command.ArticleKarma;
                article.Result.AuthorId = command.AuthorId;

                await _articleRepository.Update(command.ArticleId, article);

                return Task.CompletedTask;
            }
            else
            {
                return default;
            }
        }
    }
}