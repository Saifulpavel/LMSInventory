using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Features.Elements.Queries.GetAllElements;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory.Application.Features.Elements.Queries.GetElementById
{
    public record GetElementByIdQuery : IRequest<GetElementByIdDto>
    {
        public int Id { get; set; }

        public GetElementByIdQuery()
        {

        }
        public GetElementByIdQuery(int id)
        {
            Id = id;
        }
        internal class GetElementByIdQueryHandler : IRequestHandler<GetElementByIdQuery, GetElementByIdDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetElementByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<GetElementByIdDto> Handle(GetElementByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await _unitOfWork.Repository<Element>().GetByIdAsync(query.Id);
                var element = _mapper.Map<GetElementByIdDto>(entity);
                var result = await Result<GetElementByIdDto>.SuccessAsync(element);
                return result.Data;
            }
        }
    }
}
