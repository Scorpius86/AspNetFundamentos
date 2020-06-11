using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Dtos;
using Blog.Client.MVC.Models;
using Blog.Data.Context;
using Blog.Data.Enities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Client.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly PostApplicationService _postApplicationService;
        private readonly BlogContext _blogContext;

        public PostController(PostApplicationService postApplicationService,BlogContext blogContext)
        {
            _postApplicationService = postApplicationService;
            _blogContext = blogContext;
        }

        public IActionResult Index()
        {
            List<PostDto> posts = _postApplicationService.GetPosts();
            return View(posts);
        }

        public IActionResult Details(int postId)
        {
            Post post = _blogContext.Posts
                .Include(p => p.UsuarioIdActualizacionNavigation)
                .Include(p => p.UsuarioIdCreacionNavigation)
                .Include(p => p.UsuarioIdPropietarioNavigation)
                .FirstOrDefault(p => p.PostId == postId);

            return View(post);
        }
        
    }
}