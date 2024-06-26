﻿using System.Data;
using System.Data.SqlClient;
using Dapper;
using MYTDotNetCore.ConsoleApp.Services;

namespace MYTDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        //public void Run()
        //{
        //    //            Read();
        //    //Edit(1);
        //    //Edit(11);
        //    //Create("title", "author", "content");
        //    //Update(10, "Update Title", "Update Author", "Update Content");
        //    //Delete(13);
        //    Read();
        //}

        public void Generate(int count)
        {
            for (int i = 0; i < count; i++)
            {
            int rowNo = i + 1;
                Create("Title " + rowNo, "Author " + rowNo, "Content " + rowNo);
            }
        }

        private readonly IDbConnection _db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        public void Read()
        {

            List<BlogDto> lst = _db.Query<BlogDto>("select * from Tbl_blog").ToList();
            foreach (BlogDto blog in lst)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
                Console.WriteLine("------------------------");

            }
        }

        public void Edit(int id)
        {

            var item = _db.Query<BlogDto>("select * from Tbl_blog where BlogId = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("______________________");
        }
        public void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";


            int result = _db.Execute(query, item);

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            var item = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor 
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            int result = _db.Execute(query, item);
            var message = result > 0 ? "Update Successful" : "Update Fail";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            var item = new BlogDto
            {
                BlogId = id
            };
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";


            int result = _db.Execute(query, item);
            string message = result > 0 ? "Delete Successful" : "Delete Fail";
            Console.WriteLine(message);
        }
    }
}
