namespace Dnd.Web.Mappers
{
    using System.Collections.Generic;

    public interface IMapper<TEntity, TViewModel>
    {
        TEntity Map(TViewModel viewModel);
        IEnumerable<TEntity> Map(IEnumerable<TViewModel> viewModel);
        TViewModel Map(TEntity model);
        IEnumerable<TViewModel> Map(IEnumerable<TEntity> model);
    }
}