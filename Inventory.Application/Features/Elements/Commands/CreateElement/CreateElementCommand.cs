using AutoMapper;
using Inventory.Application.Common.Mappings;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using MediatR;
using Inventory.Domain.Common;

namespace Inventory.Application.Features.Elements.Commands.CreateElement
{
    public record CreateElementCommand : IRequest<Result<int>>, IMapFrom<Element>
    {
        public string Name { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public int RackId { get; set; }
    }

    internal class CreateElementCommandHandler : IRequestHandler<CreateElementCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateElementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateElementCommand command, CancellationToken cancellationToken)
        {
            var element = new Element()
            {
                Name = command.Name,
                Width = command.Width,
                Height = command.Height,
                RackId = command.RackId,
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.Repository<Element>().AddAsync(element);

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(element.Id, "Element Created.");
        }
    }
}
