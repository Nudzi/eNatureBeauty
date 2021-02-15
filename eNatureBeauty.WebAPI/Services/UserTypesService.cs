using AutoMapper;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class UserTypesService : IUserTypesService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;

        public UserTypesService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.UserTypes GetById(int id)
        {
            var entity = _context.UserTypes.Find(id);

            return _mapper.Map<Model.UserTypes>(entity);
        }
        public List<Model.UserTypes> Get()
        {
            List<Model.UserTypes> result = new List<Model.UserTypes>();
            var lista = _context.UserTypes.ToList();

            foreach (var item in lista)
            {
                Model.UserTypes userTypes = new Model.UserTypes();
                userTypes.Name = item.Name;
                userTypes.Description = item.Description;
                userTypes.Id = item.Id;
                result.Add(userTypes);
            }
            return result;
        }

        public Model.UserTypes isAdmin(int userTypesId)
        {
            var lista = _context.UserTypes.ToList();
            Model.UserTypes result = new Model.UserTypes();

            foreach (var item in lista)
            {
                if (item.Id == userTypesId)
                {
                    if (item.Name.Contains("Admin"))
                    {
                        result.Name = item.Name;
                        result.Description = item.Description;
                        result.Id = item.Id;

                        return result;
                    }

                }
            }
            return null;
        }
    }
    //public class UserTypesService : BaseService<Model.UserTypes, UserTypesSearchRequest, UserTypes>
    //{
    //    public UserTypesService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
    //    {
    //    }
    //}
}