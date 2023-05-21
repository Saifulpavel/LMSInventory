using AutoMapper;
using Inventory.Application.Common.Mappings;
using Inventory.Application.Features.Elements.Commands.CreateElement;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Racks.Commands.CreateRack
{
    public record CreateRackCommand : IRequest<Result<int>>, IMapFrom<Rack>
    {
        public string Name { get; set; }
        public int QuantityOfRacks { get; set; }
        public int? StoreId { get; set; }
    }
    internal class CreateRackCommandHandler : IRequestHandler<CreateRackCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRackCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateRackCommand command, CancellationToken cancellationToken)
        {
            var rack = new Rack()
            {
                Name = command.Name,
                QuantityOfRacks = command.QuantityOfRacks,
                StoreId = command.StoreId,
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.Repository<Rack>().AddAsync(rack);

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(rack.Id, "Rack Created.");
        }
    }
}
