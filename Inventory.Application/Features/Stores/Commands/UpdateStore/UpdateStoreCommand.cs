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

namespace Inventory.Application.Features.Stores.Commands.UpdateStore
{
    public record UpdateStoreCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
    internal class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateStoreCommand command, CancellationToken cancellationToken)
        {
            var store = await _unitOfWork.Repository<Store>().GetByIdAsync(command.Id);
            if (store != null)
            {
                store.Name = command.Name;
                store.Country = command.Country;
                store.UpdatedBy = 1;
                store.UpdatedDate= DateTime.Now;

                await _unitOfWork.Repository<Store>().UpdateAsync(store, command.Id);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(store.Id, "Store Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Store Not Found.");
            }
        }
    }
}
