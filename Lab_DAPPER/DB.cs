using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DAPPER
{
    class DB
    {
        //jak nie działa using przy var 
        //northwind properties connection string w SQL server object Explorer
        public void Select(IDbConnection connection)
        {

            var regions = connection.Query<Region>("SELECT * FROM Region"); // nie trzeba dalej podawac ale mozna po zapytaniu
            foreach (var item in regions)
            {
                Console.WriteLine($"{item.RegionId}:{item.RegionDescription}");//przez dodanie Region kolo Query pilnuje naszych nazw
            }


        }
        public void Insert(IDbConnection connection, Region region)
        {
            connection.Execute("INSERT INTO Region(RegionID,RegionDescription)" + "VALUES(@id,@desc)",
                new { id = region.RegionId, desc = region.RegionDescription });
        }


        public void Insert(IDbConnection connection, int id, string description)
        {
            connection.Execute("INSERT INTO Region(RegionID,RegionDescription)" + "VALUES(@id,@desc)",
                new { id = id, desc = description });
        }
        public void Delete(IDbConnection connection,Region region)
        {
            connection.Execute("DELETE FROM  Region(RegionID, RegionDescription)" + "VALUES(@id, @desc)");

        }



    }
}