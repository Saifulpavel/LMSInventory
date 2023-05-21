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

namespace Inventory.Application.Features.Stores.Commands.CreateStore
{
    public record CreateStoreCommand : IRequest<Result<int>>, IMapFrom<Store>
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    internal class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateStoreCommand command, CancellationToken cancellationToken)
        {
            var store = new Store()
            {
                Name = command.Name,
                Country = command.Country,
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.Repository<Store>().AddAsync(store);

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(store.Id, "Store Created.");
        }
    }
}
