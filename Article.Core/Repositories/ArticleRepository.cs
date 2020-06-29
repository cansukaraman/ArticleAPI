using Article.Core.Context;
using Article.Core.Model;
using Article.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Core.Repositories
{
    public class ArticleRepository : BaseRepository<ArticleModel>, IArticleRepository
    {
        public ArticleRepository(ArticleContext context) : base(context) { }

    }
}
