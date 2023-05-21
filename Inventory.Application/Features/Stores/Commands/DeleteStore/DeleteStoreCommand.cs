using AutoMapper;
using Inventory.Application.Common.Mappings;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Stores.Commands.DeleteStore
{
    public record DeleteStoreCommand : IRequest<Result<int>>, IMapFrom<Store>
    {
        public int Id { get; set; }

        public DeleteStoreCommand()
        {

        }
        public DeleteStoreCommand(int id)
        {
            Id = id;
        }
    }

    internal class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteStoreCommand command, CancellationToken cancellationToken)
        {
            var store = await _unitOfWork.Repository<Store>().GetByIdAsync(command.Id);
            if (store != null)
            {
                await _unitOfWork.Repository<Store>().DeleteAsync(store);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(store.Id, "Store Deleted");
            }
            else
            {
                return await Result<int>.FailureAsync("Store Not Found.");
            }
        }
    }
}
