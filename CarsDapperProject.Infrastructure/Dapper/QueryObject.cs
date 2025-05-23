namespace CarsDapperProject.DataAccess.Dapper;

public class QueryObject
{
    public QueryObject(string sql, object parameters)
    {
        if (string.IsNullOrEmpty(sql))
            throw new ArgumentException("SQL is empty");

        Sql = sql;
        Params = parameters;
    }

    public string Sql { get; set; }
    public object Params { get; set; }
}
