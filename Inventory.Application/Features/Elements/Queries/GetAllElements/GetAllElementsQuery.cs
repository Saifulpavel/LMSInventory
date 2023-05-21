using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Elements.Queries.GetAllElements
{
    public record GetAllElementsQuery : IRequest<List<GetAllElementsDto>>;
    internal class GetAllElementsQueryHandler : IRequestHandler<GetAllElementsQuery, List<GetAllElementsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllElementsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GetAllElementsDto>> Handle(GetAllElementsQuery query, CancellationToken cancellationToken)
        {
            var elements = await _unitOfWork.Repository<Element>().Entities
                   .ProjectTo<GetAllElementsDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);
            var result = await Result<List<GetAllElementsDto>>.SuccessAsync(elements);
            return result.Data;
        }
    }
}
