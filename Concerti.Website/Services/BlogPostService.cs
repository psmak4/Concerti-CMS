using Concerti.Website.Models;
using Concerti.Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Concerti.Website.Services
{
	public class BlogPostService : IBlogPostService
	{
		private ConcertiEntities context;

		public BlogPostService(ConcertiEntities context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			this.context = context;
		}

		public BlogPost GetBlogPost(int blogPostId)
		{
			return context.BlogPosts.FirstOrDefault(b => b.BlogPostId == blogPostId);
		}

		public IEnumerable<BlogPost> GetBlogPosts()
		{
			return context.BlogPosts.AsEnumerable();
		}
	}
}