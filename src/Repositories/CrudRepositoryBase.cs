using System;
using MySql.Data.MySqlClient;

namespace HomeRest.Repositories;

public abstract class CrudRepositoryBase
{
    internal string connectionString;

    internal readonly string tableName;
    private readonly string schema;

    public CrudRepositoryBase(IWebHostEnvironment env, IConfiguration configuration, string tableName, string schema)
    {
        if (env.IsDevelopment())
        {
            connectionString = configuration["ConnectionString"];
        }
        else
        {
            connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING") ?? "";
        }

        this.tableName = tableName;
        this.schema = schema;
        InitializeDatabase();
    }

    internal void InitializeDatabase()
    {
        try
        {
            if (DoesTableExist() == false)
            {
                CreateTable();
            }
        }
        catch
        {
            // This needs to be caught by the controller, which should then be passed to the front end in a meaningful way
            // telling the user that the database could not be initialized at all, probably due to a bad connection string
            throw new Exception("Fatal Error: Could not initialize the database");
        }
    }

    internal MySqlConnection GetConnection()
    {
        try
        {
            MySqlConnection connection = new(connectionString);
            return connection;
        }
        catch
        {
            // This needs to be caught by the controller, which should then be passed to the front end in a meaningful way
            // telling the user that the database could not be connected to
            throw new Exception("Fatal Error: Could not connect to database.");
        }
    }

    internal bool DoesTableExist()
    {
        using (MySqlConnection connection = GetConnection())
        {
            MySqlCommand command = new();

            command.CommandText = "SELECT COUNT(*) FROM information_schema.TABLES WHERE (TABLE_SCHEMA='bookkeeper') AND (TABLE_NAME='" + tableName + "')";

            command.Connection = connection;

            connection.Open();

            int n = GetCountFromScalarCommand(command);
            return n > 0;
        }
    }

    internal int GetCountFromScalarCommand(MySqlCommand command)
    {
        return int.Parse(command.ExecuteScalar().ToString() ?? "0");
    }

    internal void CreateTable()
    {
        using (MySqlConnection connection = GetConnection())
        {
            MySqlCommand command = new();
            
            command.CommandText = schema;
            
            command.Connection = connection;
            
            connection.Open();
            
            command.ExecuteNonQuery();
        }
    }
}