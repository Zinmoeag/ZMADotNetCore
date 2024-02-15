// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//using DotNet7TrainingBatch.ConsoleApp.AdoDotNetExamples;
using DotNet7TrainingBatch.ConsoleApp.AdoDotNetExamples;
using DotNet7TrainingBatch.ConsoleApp.DapperExamples;
using DotNet7TrainingBatch.ConsoleApp.EFCoreExamples;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

//making connection
//SqlConnectionStringBuilder ConnectionStringBuilder = new SqlConnectionStringBuilder();
//ConnectionStringBuilder.DataSource = ".";
//ConnectionStringBuilder.InitialCatalog = "testing";
//ConnectionStringBuilder.UserID = "sa";
//ConnectionStringBuilder.Password = "zma123";
//SqlConnection Connection = new SqlConnection(ConnectionStringBuilder.ConnectionString);


//string query = "Select * from tbl_blogs";
//Connection.Open();

////prepare query comand line
//SqlCommand cmd = new SqlCommand(query, Connection);
////exec query
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);

////make table data instance
//DataTable dt = new DataTable();
////clone data to dt objeect
//adapter.Fill(dt);

//foreach (DataRow row in dt.Rows)
//{
//    Console.WriteLine(row["blog_title"]);
//    Console.WriteLine(row["blog_author"]);
//    Console.WriteLine(row["blog_content"]);
//}
//Console.WriteLine("connection is opended");
//Connection.Close();
//Console.WriteLine("Connectio is Closed");


// adoDotNet CRUD ------`
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(5);
//adoDotNetExample.Create("tin tin", "this is Tin Tin", "Tin Tin is back");
//adoDotNetExample.Update(3, "tin tin", "this is Tin Tin", "Tin Tin is back");
//adoDotNetExample.Delete(3);

DapperExample dapperExample = new DapperExample();

//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Edit(21);
//dapperExample.Create("this is Tin win", "tin win", "Tin win is back");
//dapperExample.Update(4,"this is Tin win", "tin win", "Tin win is back");
//dapperExample.Delete(4);

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(1);
//eFCoreExample.Edit(20);
//eFCoreExample.Create("ko zin", "ko zin is back", "this is ko zin blah blah");
//eFCoreExample.Update(1, "ko zin", "ko zin is back", "this is ko zin blah blah");
//eFCoreExample.Delete(15);







