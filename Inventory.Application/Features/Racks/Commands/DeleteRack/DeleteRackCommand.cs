using AutoMapper;
using Inventory.Application.Common.Mappings;
using Inventory.Application.Interfaces.Repositories;
//using Inventory.Domain.Common;
using Inventory.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;

namespace Inventory.Application.Features.Racks.Commands.DeleteRack
{
    public record DeleteRackCommand : IRequest<Result<int>>, IMapFrom<Rack>
    {
        public int Id { get; set; }

        public DeleteRackCommand()
        {

        }
        public DeleteRackCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteRackCommandHandler : IRequestHandler<DeleteRackCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRackCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteRackCommand command, CancellationToken cancellationToken)
        {
            var rack = await _unitOfWork.Repository<Rack>().GetByIdAsync(command.Id);
            if (rack != null)
            {
                await _unitOfWork.Repository<Rack>().DeleteAsync(rack);
                try
                {
                    await _unitOfWork.Save(cancellationToken);
                    return await Result<int>.SuccessAsync(rack.Id, "Rack Deleted");
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailureAsync(ex.Message);
                }            
            }
            else
            {
                return await Result<int>.FailureAsync("Rack Not Found.");
            }
        }
    }

}
