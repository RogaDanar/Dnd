namespace Dnd.Web.Mappers
{
    using System.Collections.Generic;

    public class GenericMapper<TEntity, TViewModel> : MapperBase, IMapper<TEntity, TViewModel>
    {
        public TEntity Map(TViewModel viewModel) {
            return Map<TViewModel, TEntity>(viewModel);
        }

        public IEnumerable<TEntity> Map(IEnumerable<TViewModel> viewModel) {
            return Map<TViewModel, TEntity>(viewModel);
        }

        public TViewModel Map(TEntity model) {
            return Map<TEntity, TViewModel>(model);
        }

        public IEnumerable<TViewModel> Map(IEnumerable<TEntity> model) {
            return Map<TEntity, TViewModel>(model);
        }
    }
}
