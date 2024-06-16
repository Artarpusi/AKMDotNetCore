using AKMDotNetCore.ConsoleApp;
using AKMDotNetCore.ConsoleApp.AdoDotNetAKMs;
using AKMDotNetCore.ConsoleApp.DapperExamples;
using AKMDotNetCore.ConsoleApp.EFCoreExamples;
using AKMDotNetCore.ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "DESKTOP-BCLDL4T";
//stringBuilder.InitialCatalog = "AKMDotNetConsole";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

//connection.Open();
//Console.WriteLine("Connection open.");

//string query = "select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection close.");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id => " + dr["BlogId"]);
//    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
//    Console.WriteLine("-------------------------------------");
//}

//AdoDotNetAKM adoDotNetAKM = new AdoDotNetAKM();
////adoDotNetAKM.Read();
////adoDotNetAKM.Create("title", "author", "content");
////adoDotNetAKM.Update(14, "test title", "test author", "test content");
////adoDotNetAKM.Delete(12);
//adoDotNetAKM.Edit(12);
//adoDotNetAKM.Edit(2);

//DapperAKM dapperAKM = new DapperAKM();
//dapperAKM.Run();
//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();
var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetAKM(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperAKM(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider() ;

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetAKM>();
adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperAKM>();
//dapperExample.Run();

Console.ReadLine();
