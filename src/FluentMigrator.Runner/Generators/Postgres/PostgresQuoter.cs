using System.Linq;
using FluentMigrator.Runner.Generators.Generic;
using FluentMigrator.Runner.Helpers;

namespace FluentMigrator.Runner.Generators.Postgres
{
    public class PostgresQuoter : GenericQuoter
    {
        public override string FormatBool(bool value) { return value ? "true" : "false"; }
        private  bool NoQuotes { get; } = false;

        public PostgresQuoter(bool _NoQuotes = false)
        {
            NoQuotes = _NoQuotes;
        }
        

        protected override string FormatByteArray(byte[] array)
        {
            var arrayAsHex = array.Select(b => b.ToString("X2")).ToArray();
            return @"E'\\x" + string.Concat(arrayAsHex) + "'";
        }

        public string UnQuoteSchemaName(string quoted)
        {
            if (string.IsNullOrEmpty(quoted))
                return "public";

            return UnQuote(quoted).ToLowerForPostgresSQL(NoQuotes);
        }


        public override string QuoteTableName(string tableName)
        {
            return tableName.ToLowerForPostgresSQL(NoQuotes);
        }

        public override string QuoteColumnName(string columnName)
        {
            return columnName.ToLowerForPostgresSQL(NoQuotes);
        }


        public override string QuoteSchemaName(string schemaName)
        {
            if (string.IsNullOrEmpty(schemaName))
                schemaName = "public";
            return schemaName.ToLowerForPostgresSQL(NoQuotes);
        }

        public override string QuoteIndexName(string indexName)
        {
            return indexName.ToLowerForPostgresSQL(NoQuotes);
        }


    }
}