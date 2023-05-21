using AutoMapper;
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

namespace Inventory.Application.Features.Elements.Commands.UpdateElement
{
    public record UpdateElementCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public int? RackId { get; set; }
    }

    internal class UpdateElementCommandHandler : IRequestHandler<UpdateElementCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateElementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateElementCommand command, CancellationToken cancellationToken)
        {
            var element = await _unitOfWork.Repository<Element>().GetByIdAsync(command.Id);
            if (element != null)
            {
                element.Name = command.Name;
                element.Width = command.Width;
                element.Height = command.Height;
                element.RackId = command.RackId;
                element.UpdatedBy = 1;
                element.UpdatedDate = DateTime.Now;

                await _unitOfWork.Repository<Element>().UpdateAsync(element,command.Id);

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(element.Id, "Element Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Element Not Found.");
            }
        }
    }
}
