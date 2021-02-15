using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    //public class StoragesService : BaseCRUDService<Model.Storages, StoragesSearchRequest, StoragesUpsertRequest, StoragesUpsertRequest, Storages>
    //{
    //    public StoragesService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
    //    {
    //    }
    //    public override IList<Model.Storages> Get(StoragesSearchRequest request)
    //    {
    //        var query = _context.Set<Storages>().AsQueryable();
    //        if (!string.IsNullOrWhiteSpace(request?.Name))
    //        {
    //            query = query.Where(x => x.Name.StartsWith(request.Name));
    //        }
    //        query = query.OrderBy(x => x.Name);
    //        var list = query.ToList();

    //        return _mapper.Map<List<Model.Storages>>(list);
    //    }
    //}

    public class StoragesService : IStoragesService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public StoragesService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var entity = _context.Storages.Find(id);
            _context.Storages.Remove(entity);
            _context.SaveChanges();
        }

        public List<Model.Storages> Get(StoragesSearchRequest request)
        {
            var query = _context.Set<Storages>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }
            query = query.OrderBy(x => x.Name);
            var list = query.ToList();

            return _mapper.Map<List<Model.Storages>>(list);
        }

        public Model.Storages GetById(int id)
        {
            var entity = _context.Storages.Find(id);

            return _mapper.Map<Model.Storages>(entity);
        }
        public void Insert(StoragesUpsertRequest request)
        {
            Database.Storages entity = _mapper.Map<Database.Storages>(request);
            _context.Storages.Add(entity);
            _context.SaveChanges();

            _context.SaveChanges();
        }
        public void Update(int id, StoragesUpsertRequest request)
        {
            var entity = _context.Storages.Find(id);
            _context.Storages.Attach(entity);
            _context.Storages.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
        }
    }
}
