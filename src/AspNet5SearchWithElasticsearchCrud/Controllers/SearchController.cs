using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNet5SearchWithElasticsearchCrud.Search;

namespace AspNet5SearchWithElasticsearchCrud.Controllers
{
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

        [Microsoft.AspNetCore.Mvc.HttpPut("{id}/{updateName}/{updateDescription}")]
        public IActionResult Put(long id, string updateName, string updateDescription)
        {
            _searchProvider.UpdateSkill(id, updateName, updateDescription);

            return Ok();
        }


        // DELETE api/values/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _searchProvider.DeleteSkill(id);

            return new NoContentResult();
        }
    }
}
