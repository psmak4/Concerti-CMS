using Concerti.Website.Models;
using System.Collections.Generic;

namespace Concerti.Website.Services.Interfaces
{
	public interface IBlogPostService
	{
		BlogPost GetBlogPost(int blogPostId);

		IEnumerable<BlogPost> GetBlogPosts();
	}
}