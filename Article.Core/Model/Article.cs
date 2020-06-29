using Article.Core.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Article.Core.Model
{
    public class ArticleModel : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; } 
        public string Headline { get; set; } 
        public string Description { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Enums.Status Status { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public DateTime Created { get; set; }
    }
}
