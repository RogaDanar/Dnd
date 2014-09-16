namespace Dnd.Dal.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Model.Character;
    using Core.Services;
    using DbModels;
    using Extensions;

    public class CharacterEfRepository : ICharacterRepository
    {
        private readonly IDbContext _context;

        private IDbSet<DbCharacter> _characters { get { return _context.Set<DbCharacter>(); } }

        public CharacterEfRepository(IDbContext context = null) {
            _context = context ?? new DataContext();
        }

        public ICharacter Add(ICharacter entity) {
            var dbCharacter = _characters.Add(entity.ToDbCharacter(new DbCharacter()));
            _context.SaveChanges();
            return dbCharacter.ToCharacter();
        }

        public ICharacter GetById(int id) {
            return _characters
                .Include(x => x.Attributes)
                .Include(x => x.Classes)
                .Include(x => x.Features)
                .Include(x => x.Skills)
                .Single(x => x.Id == id)
                .ToCharacter();
        }

        public ICharacter Update(ICharacter entity) {
            var dbCharacter = _characters.Find(entity.Id);
            entity.ToDbCharacter(dbCharacter);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(ICharacter entity) {
            var dbCharacter = _characters.Find(entity.Id);
            _characters.Remove(dbCharacter);
        }

        public IEnumerable<ICharacter> GetAll() {
            return _characters
                .Include(x => x.Classes)
                .Include(x => x.Features)
                .Include(x => x.Skills)
                .Include(x => x.Attributes)
                .ToList()
                .Select(x => x.ToCharacter());
        }

        public IEnumerable<ICharacter> FindBy(Expression<Func<ICharacter, bool>> predicate) {
            return _characters
                .Include(x => x.Attributes)
                .Include(x => x.Classes)
                .Include(x => x.Features)
                .Include(x => x.Skills)
                .Select(x => x.ToCharacter())
                .Where(predicate);
        }
    }
}
