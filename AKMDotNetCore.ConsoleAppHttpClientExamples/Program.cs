using AKMDotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;
using System.Net.Security;

Console.WriteLine("Hello, World!");


// Console App - Client (Frontend)
// ASP.NET Core Web API - Server (Backend)


//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7212/api/blog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    //Console.WriteLine(jsonStr);
//    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
//    foreach (var blog in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(blog));
//        Console.WriteLine($"Title => {blog.BlogTitle}");
//        Console.WriteLine($"Author => {blog.BlogAuthor}");
//        Console.WriteLine($"Content =>  {blog.BlogContent}");
//    }
//}
HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();

// task 1
// task 2
// task 3 
// task 4
// task 5

// 25

// task 1, task 2
// 5

// async