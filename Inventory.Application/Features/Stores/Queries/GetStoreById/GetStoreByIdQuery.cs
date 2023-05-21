using AutoMapper;
using Inventory.Application.Features.Stores.Queries.GetStoreById;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Stores.Queries.GetStoreById
{
    public record GetStoreByIdQuery : IRequest<GetStoreByIdDto>
    {
        public int Id { get; set; }
        public GetStoreByIdQuery()
        {
        }
        public GetStoreByIdQuery(int id)
        {
            Id = id;
        }
        internal class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, GetStoreByIdDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetStoreByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<GetStoreByIdDto> Handle(GetStoreByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _unitOfWork.Repository<Store>().GetByIdAsync(query.Id);
                var store = _mapper.Map<GetStoreByIdDto>(entity);
                var result = await Result<GetStoreByIdDto>.SuccessAsync(store);
                return result.Data;
            }
        }
    }
}
