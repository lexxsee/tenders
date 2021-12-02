using System;
using System.Collections.Generic;
using System.Linq;
using Tenders.Core.Entities;
using Tenders.Core.Interfaces;
using Tenders.Infrastructure.Data.Persistence;

namespace Tenders.Infrastructure.Data.Repositories
{
    public class CitizenRepository : EntityFrameworkRepository<Citizen>, ICitizenRepository
    {
        private readonly TenderDbContext _context;

        public CitizenRepository(TenderDbContext context)
            : base(context)
        {
            _context = context;
        }

        public ICollection<Citizen> GetAll()
        {
            return ObjectSet.ToList();
        }

        public Citizen GetByKey(int id)
        {
            return ObjectSet.SingleOrDefault(e => e.Id == id);
        }

        // public override void Add(Citizen entity)
        // {
        //     if (entity == null)
        //     {
        //         throw new ArgumentNullException(nameof(entity));
        //     }
        //
        //     ObjectSet.AddAsync(entity);
        //
        // }

        public new TenderDbContext Context => (TenderDbContext)base.Context;
    }
}