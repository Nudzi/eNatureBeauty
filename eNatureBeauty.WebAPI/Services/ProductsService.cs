using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace eNatureBeauty.WebAPI.Services
{
    public class ProductsService : BaseCRUDService<Model.Products, ProductsSearchRequest, ProductsUpsertRequest, ProductsUpsertRequest, Products>
    {
        public ProductsService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<Model.Products> Get(ProductsSearchRequest request)
        {
            var query = _context.Set<Products>().AsQueryable();
            if (request?.ProductTypeId.HasValue == true)
            {
                query = query.Where(x => x.ProductTypeId == request.ProductTypeId);
            }
            if (!string.IsNullOrWhiteSpace(request?.ProductName))
            {
                query = query.Where(x => x.Name.StartsWith(request.ProductName));
            }
            query = query.OrderBy(x => x.Name);
            var list = query.ToList();

            return _mapper.Map<List<Model.Products>>(list);
        }
    }
}
