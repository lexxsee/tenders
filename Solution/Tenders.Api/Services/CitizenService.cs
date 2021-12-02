using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChoETL;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Tenders.Core.DTOs;
using Tenders.Core.Entities;
using Tenders.Core.Enums;
using Tenders.Core.Interfaces;
using Tenders.Infrastructure.Data.Persistence;
using Tenders.Infrastructure.Data.Repositories;

namespace Tenders.Api.Services
{
    class CitizenService : ICitizenService
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private TenderDbContext _context;
        private IValidator<CitizenRequestDto> _validator;
        private readonly IRepository<Citizen> _repository;
        private readonly IMapper _mapper;

        public CitizenService(TenderDbContext context, IMapper mapper, IValidator<CitizenRequestDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _uowFactory = new EntityFrameworkUnitOfWorkFactory(context);
            _repository = new EntityFrameworkRepository<Citizen>(context);
        }

        public async Task<IEnumerable<CitizenDto>> GetAllAsync()
        {
            var citizens = await _repository.All().Include(i => i.CitizenDocuments)
                .ThenInclude(t => t.CitizenDocumentType).ToListAsync();
            return _mapper.Map<IEnumerable<CitizenDto>>(citizens);
        }

        public async Task<IEnumerable<CitizenDto>> FindAsync(CitizenFilterDto filter)
        {
            var citizens = await _repository.All()
                .Where(CitizenEqual<Citizen>(filter))
                .Include(i => i.CitizenDocuments)
                .ThenInclude(t => t.CitizenDocumentType).ToListAsync();

            return _mapper.Map<IEnumerable<CitizenDto>>(citizens);
        }

        public async Task<CitizenDto> FindByDocumentAsync(CitizenDocumentFilterDto filter)
        {
            var citizen = await _repository.All().Include(i => i.CitizenDocuments)
                .ThenInclude(t => t.CitizenDocumentType).FirstOrDefaultAsync(f =>
                    f.CitizenDocuments.Any(a => a.TypeId == filter.TypeId && a.Number == filter.Number));
            return _mapper.Map<CitizenDto>(citizen);
        }

        public async Task AddAsync(CitizenRequestDto citizenRequestDto)
        {
            await _validator.ValidateAndThrowAsync(citizenRequestDto);

            using var uow = _uowFactory.Create();
            var map = _mapper.Map<Citizen>(citizenRequestDto);
            await _repository.AddAsync(map);
            await uow.SaveAsync();
        }

        // данный метод был специально написан в таком упрощенном виде.
        // по факту редактирование документов должно быть в собственном контролере, с отслеживанием изменения документов,
        // т.к. в тз нет ни какой информации по этому поводу и с учетом что это тестовое задание .
        public async Task EditAsync(int id, CitizenRequestDto citizenRequestDto)
        {
            await _validator.ValidateAndThrowAsync(citizenRequestDto);

            using var uow = _uowFactory.Create();
            var original = _repository.All().Include(i => i.CitizenDocuments).SingleOrDefault(x => x.Id == id);
            if (original == null) throw new ArgumentNullException(nameof(id));
            original.SurName = citizenRequestDto.SurName;
            original.FirstName = citizenRequestDto.FirstName;
            original.Patronymic = citizenRequestDto.Patronymic;
            original.DateOfBirth = citizenRequestDto.DateOfBirth;
            original.DateOfDeath = citizenRequestDto.DateOfDeath;


            var docInn = original.CitizenDocuments.SingleOrDefault(w => w.TypeId == (int)CitizenDocumentTypeEnum.ИИН);
            if (docInn != null) docInn.Number = citizenRequestDto.Inn;

            var docSnils =
                original.CitizenDocuments.SingleOrDefault(w => w.TypeId == (int)CitizenDocumentTypeEnum.СНИЛС);
            if (docSnils != null) docSnils.Number = citizenRequestDto.Snils;

            await uow.SaveAsync();
        }

        public async Task RemoveAsync(int id)
        {
            using var uow = _uowFactory.Create();
            _repository.Remove(_repository.All().Single(x => x.Id == id));
            await uow.SaveAsync();
        }

        public async Task<string> ExportToCvsAsync()
        {
            var citizens = await _repository.All().Include(i => i.CitizenDocuments)
                .ThenInclude(t => t.CitizenDocumentType).Select(s => new CitizenViewDto
                {
                    SurName = s.SurName,
                    FirstName = s.FirstName,
                    Patronymic = s.Patronymic,
                    DateOfBirth = s.DateOfBirth.ToShortDateString(),
                    DateOfDeath = !s.DateOfDeath.HasValue ? null : s.DateOfDeath.Value.ToShortDateString(),
                    Inn = s.CitizenDocuments.FirstOrDefault(f => f.TypeId == (int)CitizenDocumentTypeEnum.ИИН).Number,
                    Snils = s.CitizenDocuments.FirstOrDefault(f => f.TypeId == (int)CitizenDocumentTypeEnum.СНИЛС).Number
                }).ToListAsync();
            var sb = new StringBuilder();

            using var parser = new ChoCSVWriter<CitizenViewDto>(sb).WithFirstLineHeader();
            parser.Write(citizens);
            return sb.ToString();
        }

        public async Task ImportFromCvsAsync(string raw)
        {
            using var csvReader = new ChoCSVReader<CitizenRequestDto>(new StringBuilder(raw)).WithFirstLineHeader();
            using var uow = _uowFactory.Create();
            foreach (var citizenRequestDto in csvReader)
            {
                var map = _mapper.Map<Citizen>(citizenRequestDto);
                await _repository.AddAsync(map);
            }
            await uow.SaveAsync();
        }

        private static Expression<Func<T, bool>> CitizenEqual<T>(CitizenFilterDto filter)
        {
            var parameter = Expression.Parameter(typeof(T), "e");
            var props = new Dictionary<string, object>(typeof(CitizenFilterDto).GetProperties().Select(x =>
                new KeyValuePair<string, object>(x.Name, x.GetValue(filter))));

            var expressions = (from prop in props
                    where prop.Value != null
                    let entityProperty = typeof(T).GetProperty(prop.Key)
                    select Expression.Equal(
                        Expression.Property(parameter, entityProperty!),
                        Expression.Constant(prop.Value, entityProperty.PropertyType)
                    )
                ).ToList();

            var predicate = expressions.Aggregate(Expression.AndAlso);
            return Expression.Lambda<Func<T, bool>>(predicate, parameter);
        }
    }
}