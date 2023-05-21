using AutoMapper;
using Inventory.Application.Common.Mappings;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Domain.Common;
using MediatR;

namespace Inventory.Application.Features.Elements.Commands.DeleteElement
{
    public record DeleteElementCommand : IRequest<Result<int>>, IMapFrom<Element>
    {
        public int Id { get; set; }

        public DeleteElementCommand()
        {

        }
        public DeleteElementCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteElementCommandHandler : IRequestHandler<DeleteElementCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteElementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(DeleteElementCommand command, CancellationToken cancellationToken)
        {
            var element = await _unitOfWork.Repository<Element>().GetByIdAsync(command.Id);
            if (element != null)
            {
                await _unitOfWork.Repository<Element>().DeleteAsync(element);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(element.Id, "Element Deleted");
            }
            else
            {
                return await Result<int>.FailureAsync("Element Not Found.");
            }
        }
    }
}
