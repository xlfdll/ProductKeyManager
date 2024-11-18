using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

using ProductKeyManager.Properties;

namespace ProductKeyManager
{
    public class ProductKeyDatabase : IDisposable
    {
        public ProductKeyDatabase(String databaseFileName)
        {
            this.DatabaseFileName = databaseFileName;
            this.Database = new SQLiteConnection($"Data Source={this.DatabaseFileName}; Foreign Keys=true");

            this.CreateSchemaIfNotExist();

            ProductKeyDatabase.Current = this;
        }

        private String DatabaseFileName { get; }

        internal SQLiteConnection Database { get; }

        public Boolean IsConnected
            => this.Database.State == ConnectionState.Open;

        public void OpenConnection()
        {
            if (this.Database.State == ConnectionState.Closed)
            {
                this.Database.Open();
            }
        }

        public void CloseConnection()
        {
            if (this.Database.State != ConnectionState.Closed)
            {
                this.Database.Close();
            }
        }

        private void CreateSchemaIfNotExist()
        {
            if (!File.Exists(this.Database.FileName))
            {
                SQLiteConnection.CreateFile(this.Database.FileName);

                this.Database.Open();

                using (SQLiteCommand command = new SQLiteCommand(Resources.DataSchema, this.Database))
                {
                    command.ExecuteNonQuery();
                }

                this.Database.Close();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Database.Dispose();
        }

        #endregion

        public static ProductKeyDatabase Current { get; private set; }
    }
}