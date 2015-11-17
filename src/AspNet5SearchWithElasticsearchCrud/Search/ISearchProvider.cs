namespace AspNet5SearchWithElasticsearchCrud.Search
{
    using System.Collections.Generic;

    public interface ISearchProvider
	{
		IEnumerable<Skill> QueryString(string term);

		void AddUpdateEntity(Skill skill);
		void UpdateSkill(long updateId, string updateName, string updateDescription);
		void DeleteSkill(long updateId);
	}
}