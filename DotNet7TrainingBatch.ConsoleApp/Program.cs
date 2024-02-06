// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

//making connection
SqlConnectionStringBuilder ConnectionStringBuilder = new SqlConnectionStringBuilder();
ConnectionStringBuilder.DataSource = ".";
ConnectionStringBuilder.InitialCatalog = "testing";
ConnectionStringBuilder.UserID = "sa";
ConnectionStringBuilder.Password = "zma123";
SqlConnection Connection = new SqlConnection(ConnectionStringBuilder.ConnectionString);


string query = "Select * from tbl_blogs";
Connection.Open();

//prepare query comand line
SqlCommand cmd = new SqlCommand(query, Connection);
//exec query
SqlDataAdapter adapter = new SqlDataAdapter(cmd);

//make table data instance
DataTable dt = new DataTable(); 
// clone data to dt objeect
adapter.Fill(dt);

foreach (DataRow row in dt.Rows)
{
    Console.WriteLine(row["blog_title"]);
    Console.WriteLine(row["blog_author"]);
    Console.WriteLine(row["blog_content"]);
}
//Console.WriteLine("connection is opended");
Connection.Close();
//Console.WriteLine("Connectio is Closed");


