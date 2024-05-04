﻿using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.WebRestApi.Models;
using MYTDotNetCore.WebRestApi;
using System.Data;
using Dapper;
using Microsoft.IdentityModel.Tokens;

namespace MYTDotNetCore.WebRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        private readonly IDbConnection _db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            List<BlogModel> lst = _db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = FindById (id);
            if (item is null)
            {
                return NotFound("item not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            int result = _db.Execute(query, blog);
            string message = result > 0 ? "Create Success" : "Create Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("Item Not Found");
            }

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor 
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            blog.BlogId = id;
            int result = _db.Execute(query, blog);
            string message = result > 0 ? "Update Success " : "Update Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null) 
            {
                return NotFound("Data not found");
            }
            string condition = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle)) 
            {
                condition += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                condition += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += "[BlogContent] = @BlogContent, ";
            }
            condition = condition.Substring(0, condition.Length - 2); 
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition}
 WHERE BlogId = @BlogId";
            blog.BlogId = id;
            var result = _db.Execute(query, blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("Item not found");
            }
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            int result = _db.Execute(query,item);
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            return Ok(message);

        }
        private BlogModel FindById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";
            var item = _db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }
    }
}