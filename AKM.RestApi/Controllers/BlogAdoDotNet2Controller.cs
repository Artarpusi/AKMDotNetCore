﻿using AKM.RestApi.Models;
using AKMDotNetCore.Shared;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AKM.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {

        //private readonly AdoDotNetService _adoDotNetService =
        //    new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNet2Controller(AdoDotNetService adoDotNetService)
        {
            this._adoDotNetService = adoDotNetService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _adoDotNetService.Query<BlogModel>(query, parameters);

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            if (item is null)
            {
                return NotFound("No data found.");
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

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
            );

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            //return StatusCode(500, message);
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult PutBlog(int id, BlogModel blog)
        {
            string query = "SELECT COUNT(*) FROM Tbl_Blog WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand checkCmd = new SqlCommand(query, connection);
            checkCmd.Parameters.AddWithValue("@BlogId", id);
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }

            string updatequery = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle,
                               [BlogAuthor] = @BlogAuthor,
                               [BlogContent] = @BlogContent
                           WHERE BlogId = @BlogId";


            SqlCommand cmd = new SqlCommand(updatequery, connection);

            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            List<AdoDotNetParameter> lst = new List<AdoDotNetParameter>();
            string findQuery = "select * from tbl_blog where blogid = @BlogId";
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(findQuery, new AdoDotNetParameter("@BlogId", id));

            if (item is null)
            {
                return NotFound("No Data Found.");
            }

            // Adding the BlogId parameter
            lst.Add(new AdoDotNetParameter("@BlogId", id));

            // Prepare SQL UPDATE conditions and add corresponding parameters
            string conditions = String.Empty;

            if (!String.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
                lst.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }

            if (!String.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
                lst.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }

            if (!String.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";
                lst.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }

            // Check if no fields are updated
            if (conditions.Length == 0)
            {
                var response = new { IsSuccess = false, Message = "No updates provided." };
                return BadRequest(response);
            }

            // Remove the last comma and space from the conditions string
            conditions = conditions.Substring(0, conditions.Length - 2);

            // Construct the SQL update statement
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                      SET {conditions}
                      WHERE BlogId = @BlogId";

            // Execute the SQL update statement
            var result = _adoDotNetService.Execute(query, lst.ToArray());

            string message = result > 0 ? "Patching Successful!" : "Patching Failed.";
            return Ok(message);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                           WHERE BlogId = @BlogId";
            var result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where blogid = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }

    }
}
