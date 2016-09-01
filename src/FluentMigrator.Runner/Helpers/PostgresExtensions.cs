namespace FluentMigrator.Runner.Helpers
{
    public  static class PostgresExtensions
    {
        /// <summary>
        /// if noQuotes is true all objects are converted to Lower Case
        /// </summary>
        /// <param name="sqlObject"></param>
        /// <param name="NoQuotes"></param>
        /// <returns></returns>
        public static string ToLowerForPostgresSQL(this string sqlObject, bool NoQuotes)
        {
            if (!NoQuotes)
                return sqlObject;
            return sqlObject.ToLower();
        }

    }
}
