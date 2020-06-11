using Blog.Application.Dtos;
using Blog.Data.Context;
using Blog.Data.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Application
{
    public class PostApplicationService
    {
        private readonly BlogContext _blogContext;

        public PostApplicationService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<Post> List()
        {
            List<Post> posts = _blogContext.Posts.ToList();
            return posts;
        }

        public List<PostDto> GetPosts()
        {
            var query = from p in _blogContext.Posts
                        select new PostDto
                        {
                            Contenido = p.Contenido,
                            PostId = p.PostId,
                            Titulo = p.Titulo,
                            UsuarioIdPropietario = p.UsuarioIdPropietario,
                            UsuarioPropietario = new UsuarioDto
                            {
                                UsuarioId = p.UsuarioIdPropietarioNavigation.UsuarioId,
                                Nombre = p.UsuarioIdPropietarioNavigation.Nombre,
                                ApellidoPaterno = p.UsuarioIdPropietarioNavigation.ApellidoPaterno,
                                ApellidoMaterno = p.UsuarioIdPropietarioNavigation.ApellidoMaterno
                            }
                        };

            List<PostDto> posts = query.ToList();
            return posts;
        }

        public Post Get(int postId)
        {
            //Post post = _blogContext.Posts.Find(postId);
            var query = from p in _blogContext.Posts
                        where p.PostId == postId
                        select p;

            Post post = query.FirstOrDefault();
            return post;
        }
        public void Update(Post post)
        {
            Post postUpdate = _blogContext.Posts.Find(post.PostId);
            postUpdate.Titulo = post.Titulo;
            postUpdate.Contenido = post.Contenido;
            postUpdate.UsuarioIdActualizacion = 1;

            _blogContext.Posts.Update(postUpdate);
            _blogContext.SaveChanges();
        }
        public void Insert(Post post)
        {
            post.UsuarioIdActualizacion = 1;
            post.UsuarioIdCreacion = 1;
            
            _blogContext.Posts.Add(post);
            _blogContext.SaveChanges();
        } 
        public void Delete (int postId)
        {
            Post postDelete = _blogContext.Posts.Find(postId);
            
            _blogContext.Posts.Remove(postDelete);
            _blogContext.SaveChanges();
        }
    }
}
