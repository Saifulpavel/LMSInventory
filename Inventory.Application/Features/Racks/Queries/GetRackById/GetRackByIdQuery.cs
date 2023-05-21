using AutoMapper;
using Inventory.Application.Features.Elements.Queries.GetElementById;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Racks.Queries.GetRackById
{
    public record GetRackByIdQuery : IRequest<GetRackByIdDto>
    {
        public int Id { get; set; }

        public GetRackByIdQuery()
        {

        }
        public GetRackByIdQuery(int id)
        {
            Id = id;
        }

        internal class GetRackByIdQueryHandler : IRequestHandler<GetRackByIdQuery, GetRackByIdDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetRackByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<GetRackByIdDto> Handle(GetRackByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _unitOfWork.Repository<Rack>().GetByIdAsync(query.Id);
                var rack = _mapper.Map<GetRackByIdDto>(entity);
                var result = await Result<GetRackByIdDto>.SuccessAsync(rack);
                return result.Data;
            }
        }
    }
}
