using System;
using System.Data.SqlClient;
using System.IO;
using AsynchronousSessionManagement.Migrations;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;

namespace AsynchronousSessionManagement.Tests
{
    public static class TestDatabase
    {
        private const string FixedDatabaseLocation = @"C:\MultiThreadedTest\Databases";

        public static bool LogToConsole { get; set; }

        public static string Deploy(string databaseName)
        {
            if (databaseName.Contains(" ")) throw new ArgumentException("databaseName shouldn't contain spaces");

            var context = Environment.GetEnvironmentVariable("build_context");

            if (!string.IsNullOrWhiteSpace(context))
                databaseName = context.Replace(" ", "") + "-" + databaseName;

            Directory.CreateDirectory(FixedDatabaseLocation);
            foreach (var file in Directory.GetFiles(FixedDatabaseLocation, databaseName + ".*"))
                File.Delete(file);
            foreach (var file in Directory.GetFiles(FixedDatabaseLocation, databaseName + "_log.*"))
                File.Delete(file);

            var fileName = Path.Combine(FixedDatabaseLocation, databaseName);
            var fullPath = DropAndCreateDatabase(databaseName, fileName);

            var connectionString =
                $@"Server=(localdb)\MSSQLLocalDB;Initial Catalog={databaseName};AttachDbFilename={fullPath};Integrated Security=true";

            DeployMigrations(connectionString);

            return connectionString;
        }

        private static string DropAndCreateDatabase(string databaseName, string fileName)
        {
            var fileNameStatement = $"'{fileName}.mdf'";

            using (var conn = new SqlConnection(
                       @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Master;Integrated Security=True;Connection Timeout=30;"))
            {
                conn.Open();

                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = string.Format(@"
                        IF EXISTS(SELECT * FROM sys.databases WHERE name='{0}')
                        BEGIN
                            EXEC sp_detach_db [{0}]

                        END

                        DECLARE @FILENAME AS VARCHAR(255)

                        SET @FILENAME = {1};

                        EXEC ('CREATE DATABASE [{0}] ON PRIMARY (NAME = [{0}], FILENAME =''' + @FILENAME + ''', SIZE = 25MB, MAXSIZE = 500MB, FILEGROWTH = 5MB )')

                        SELECT @FILENAME", databaseName, fileNameStatement)
                };

                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        private static void DeployMigrations(string connectionString)
        {
            var announcer = LogToConsole ? (IAnnouncer)new ConsoleAnnouncer() : new NullAnnouncer();
            var context = new RunnerContext(announcer)
            {
                Connection = connectionString,
                Target = typeof(_20214141559_InitialMigration).Assembly.FullName,
                Database = "SqlServer"
            };
            new TaskExecutor(context).Execute();
        }
    }
}