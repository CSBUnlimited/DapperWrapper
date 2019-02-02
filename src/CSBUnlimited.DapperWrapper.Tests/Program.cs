namespace CSBUnlimited.DapperWrapper.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnector dbConnector = new SqlServerConnector(@"Data Source=CO-IT-CHATHURAN\CSBUNLIMITED; Initial Catalog=Eclipse; User id=sa; Password=5556;");

            IDbParameterList dataParameters = new DbParameterList()
            {
                new DbDataParameter("@Id", 10, dbType: System.Data.DbType.Int32),
                new DbDataParameter("@OT", 10, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output)
            };
            

            var t = dbConnector.ExecuteQueryMultipleStoredProcedure<dynamic, dynamic, dynamic>("[usm].[Test_DapperWrapper]", dataParameters);

            var d = dbConnector.ExecuteQueryMultipleStoredProcedure("[usm].[Test_DapperWrapper]", dataParameters);
        }
    }
}
