namespace FluxoDiario.DataAccess.Mappers
{
    public interface IDefaultDataModelMapper<TModel, TEntity>
    {
        TModel ToModel(TEntity entity);
        TEntity ToEntity(TModel model);
    }
}
