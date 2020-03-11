using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.Sql;



namespace Lab_DAPPER
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var db = new DB();
                db.Select(connection);
                db.Insert(connection, new Region() { RegionId = 300, RegionDescription = "test" });
                //jest dodane do tabeli Region
                db.Insert(connection, 201, "d-test");
                //usuwanie po IdRegionu
                db.Delete(connection, new Region(){RegionId =300 });
            }





            

        }
    }
}
