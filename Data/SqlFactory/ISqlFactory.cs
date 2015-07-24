namespace RayUtil.DataHelper.SqlFactory
{
    public interface ISqlFactory
    {
        string GetSql<T>(T entity);
    }
}
