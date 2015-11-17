using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace AspNet5SearchWithElasticsearchCrud.Controllers
{
    using AspNet5SearchWithElasticsearchCrud.Search;

    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        readonly ISearchProvider _searchProvider;

        public SearchController(ISearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
        }

        [HttpGet("{term}")]
        public IEnumerable<Skill> Search(string term)
        {
            return _searchProvider.QueryString(term);
        }

        [HttpPost("{id}/{name}/{description}")]
        public IActionResult Post(long id, string name, string description)
        {
            _searchProvider.AddUpdateEntity(
                new Skill
                    {
                        Created = DateTimeOffset.UtcNow,
                        Description = description,
                        Name = name,
                        Id = id
                    });

            string url = $"api/search/{id}/{name}/{description}";

            return Created(url, id);
        }

        [Microsoft.AspNet.Mvc.HttpPut("{id}/{updateName}/{updateDescription}")]
        public IActionResult Put(long id, string updateName, string updateDescription)
        {
            _searchProvider.UpdateSkill(id, updateName, updateDescription);

            return Ok();
        }


        // DELETE api/values/5
        [Microsoft.AspNet.Mvc.HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _searchProvider.DeleteSkill(id);

            return new NoContentResult();
        }
    }
}
