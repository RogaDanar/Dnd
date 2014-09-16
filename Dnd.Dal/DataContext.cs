namespace Dnd.Dal
{
    using System.Data.Entity;
    using Core.Model;
    using Mapping;

    public class DataContext : DbContext, IDbContext
    {
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity<int> {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new CharacterMap());
            modelBuilder.Configurations.Add(new AttributesMap());
            modelBuilder.Configurations.Add(new FeaturesMap());
            modelBuilder.Configurations.Add(new SkillsMap());
            modelBuilder.Configurations.Add(new ClassesMap());
            //var typesToRegister = Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null
            //        && type.BaseType.IsGenericType
            //        && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach (var type in typesToRegister) {
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}

            base.OnModelCreating(modelBuilder);
        }
    }
}
