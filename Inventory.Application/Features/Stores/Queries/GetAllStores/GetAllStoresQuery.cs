using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Features.Elements.Queries.GetAllElements;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Stores.Queries.GetAllStores
{
    public record GetAllStoresQuery : IRequest<List<GetAllStoresDto>>;

    internal class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, List<GetAllStoresDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllStoresDto>> Handle(GetAllStoresQuery query, CancellationToken cancellationToken)
        {
            var stores = await _unitOfWork.Repository<Store>().Entities
                   .ProjectTo<GetAllStoresDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);
            var result = await Result<List<GetAllStoresDto>>.SuccessAsync(stores);
            return result.Data;
        }
    }
}
