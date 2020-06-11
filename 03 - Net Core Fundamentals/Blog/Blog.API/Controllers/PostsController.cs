using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Data.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostApplicationService _postApplicationService;

        public PostsController(PostApplicationService postApplicationService)
        {
            _postApplicationService = postApplicationService;
        }
        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            List<Post> posts = _postApplicationService.List();
            return posts;
        }

        // GET: api/Posts/5
        [HttpGet("{postId}", Name = "Get")]
        public Post Get(int postId)
        {
            Post post = _postApplicationService.Get(postId);
            return post;
        }

        // POST: api/Posts
        [HttpPost]
        public void Post([FromBody] Post post)
        {
            _postApplicationService.Insert(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{postId}")]
        public void Put(int postId, [FromBody] Post post)
        {
            post.PostId = postId;
            _postApplicationService.Update(post);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{postId}")]
        public void Delete(int postId)
        {
            _postApplicationService.Delete(postId);
        }
    }
}
