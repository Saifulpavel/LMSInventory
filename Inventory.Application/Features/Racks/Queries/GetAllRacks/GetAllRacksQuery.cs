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

namespace Inventory.Application.Features.Racks.Queries.GetAllRacks
{
    public record GetAllRacksQuery : IRequest<List<GetAllRacksDto>>;
    internal class GetAllRacksQueryHandler : IRequestHandler<GetAllRacksQuery, List<GetAllRacksDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllRacksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllRacksDto>> Handle(GetAllRacksQuery query, CancellationToken cancellationToken)
        {
            var racks = await _unitOfWork.Repository<Rack>().Entities
                   .ProjectTo<GetAllRacksDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);
            var result = await Result<List<GetAllRacksDto>>.SuccessAsync(racks);
            return result.Data;
        }
    }
}
