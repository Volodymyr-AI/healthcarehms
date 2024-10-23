using HospitalManagement.Application.Utils.Exceptions;
using HospitalManagement.Application.Utils.Interfaces;
using HospitalManagement.Core;
using MediatR;

namespace HospitalManagement.Application.MediatR.GlobalAdmin.Hospitals.Commands.DeleteHospital
{
    public class DeleteHospitalCommandHandler : IRequestHandler<DeleteHospitalCommand, Unit>
    {
        private readonly IHospitalDbContext _dbContext;

        public DeleteHospitalCommandHandler(IHospitalDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Hospitals
                .FindAsync(new object[] { request.HospitalId }, cancellationToken);

            if (entity == null || entity.Id != request.HospitalId)
            {
                throw new NotFoundException(nameof(HospitalEntity), request.HospitalId);
            }

            _dbContext.Hospitals.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
