using System;
using System.Data.SqlClient;

var conStr = "Data Source=DESKTOP-U9UFRFT\\SQLEXPRESS; Initial Catalog=Library; User ID=sa; Password=258025;";
SqlConnection connection = new SqlConnection(conStr);




SelectAlltable("Authors");


/////////////////////////////////////////////////////////////////////////////////
///

//select
void SelectAlltable(string tablename)
{
    SqlDataReader reader = null;
    string[] allowedtables = ["Books","S_Cards"];
    if (!allowedtables.Contains(tablename))
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Acces denied");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(800);
            Console.Clear();
            Thread.Sleep(500);
        }
       
        return;
    }
    else {
        try
        {

            //table adlari etir adlari parametr kmi verilmir
            connection.Open();
            var command = new SqlCommand($"SELECT * FROM {tablename}", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Name: {reader[1]}  Pages: {reader[2]}  PressYear: {reader[3]}");
                // Console.WriteLine($"{reader["Id"]} {reader["FirstName"]} {reader["LastName"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            reader?.Close();
            connection?.Close();
        } 
    }
}


void QueryWithP(string p)
{
    SqlDataReader reader = null;
    try
    {
        connection.Open();
    
        var query = "Select* from AUthors where FirstName=@p1"  ;
        var command = new SqlCommand(query, connection);
        //way 1
        /*var param = new SqlParameter();
        param.ParameterName = "@p1";
        param.Value = p;
        param.SqlDbType = System.Data.SqlDbType.NVarChar;
        command.Parameters.Add(param);
        //way2
        command.Parameters.Add("@p1",System.Data.SqlDbType.NVarChar).Value=p;
        */

        //way3
        command.Parameters.AddWithValue("@p1", p);


        reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]} {reader[1]}");
        }
            }
    finally
    {

    }
}

void SelectBooks()
{
    SqlDataReader? reader = null;

    var columns = new List<string>();
    try
    {
        connection.Open();
        var query = "Select * from Books";
        var command = new SqlCommand(query, connection);
        reader = command.ExecuteReader();

        int line = 0;
        while (reader.Read())
        {
            if (line == 0)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    columns.Add(reader.GetName(i));
                    Console.Write($"{reader.GetName(i)} ");
                }
                line=1;

            }
            foreach (var item in columns)
            {
                Console.Write($"{reader[item]}");
            }

            Console.WriteLine();
        }
    }
    finally
    {
        connection.Close();
    }
}

//insertion
void InsertAuthor(int id , string name,string lastname)
{
    try
    {
        connection.Open();
        var query = "INSERT INTO Authors (Id,FirstName,LastName) VALUES(@p1,@p2,@p3) ";
        var command2 = new SqlCommand(query, connection);
        command2.Parameters.AddWithValue("@p1", id);
        command2.Parameters.AddWithValue("@p2", name);
        command2.Parameters.AddWithValue("@p3", lastname);
        
        command2.ExecuteNonQuery();
    }
    finally
    {
        connection.Close();
    }
}
