﻿namespace AspNet5SearchWithElasticsearchCrud.Search
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Skill
	{
		[Required]
		[Range(1, long.MaxValue)]
		public long Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Updated { get; set; }
	}
}