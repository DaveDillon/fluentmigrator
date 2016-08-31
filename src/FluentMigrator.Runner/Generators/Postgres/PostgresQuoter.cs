using System.Linq;
using FluentMigrator.Runner.Generators.Generic;

namespace FluentMigrator.Runner.Generators.Postgres
{
    public class PostgresQuoter : GenericQuoter
    {
        public override string FormatBool(bool value) { return value ? "true" : "false"; }

     

        protected override string FormatByteArray(byte[] array)
        {
            var arrayAsHex = array.Select(b => b.ToString("X2")).ToArray();
            return @"E'\\x" + string.Concat(arrayAsHex) + "'";
        }

        public string UnQuoteSchemaName(string quoted)
        {
            if (string.IsNullOrEmpty(quoted))
                return "public";

            return UnQuote(quoted).ToLower();
        }


        public override string QuoteTableName(string tableName)
        {
            return tableName.ToLower();
        }

        public override string QuoteColumnName(string columnName)
        {
            return columnName.ToLower(); ;
        }


        public override string QuoteSchemaName(string schemaName)
        {
            if (string.IsNullOrEmpty(schemaName))
                schemaName = "public";
            return schemaName.ToLower();
        }

        public override string QuoteIndexName(string indexName)
        {
            return indexName.ToLower();
        }


    }
}