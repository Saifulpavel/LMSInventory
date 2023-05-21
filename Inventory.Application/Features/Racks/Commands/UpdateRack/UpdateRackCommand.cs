using AutoMapper;
using Inventory.Application.Features.Elements.Commands.UpdateElement;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Racks.Commands.UpdateRack
{
    public record UpdateRackCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfRacks { get; set; }
        public int? StoreId { get; set; }
    }
    internal class UpdateRackCommandHandler : IRequestHandler<UpdateRackCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRackCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpdateRackCommand command, CancellationToken cancellationToken)
        {
            var rack = await _unitOfWork.Repository<Rack>().GetByIdAsync(command.Id);
            if (rack != null)
            {
                rack.Name = command.Name;
                rack.QuantityOfRacks = command.QuantityOfRacks;
                rack.StoreId = command.StoreId;
                rack.UpdatedBy = 1;
                rack.UpdatedDate = DateTime.Now;
                await _unitOfWork.Repository<Rack>().UpdateAsync(rack,command.Id);
                await _unitOfWork.Save(cancellationToken);
                return await Result<int>.SuccessAsync(rack.Id, "Rack Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Rack Not Found.");
            }
        }
    }
}
