using FluentValidation;
using DTO = SampleApp.Application.Contracts.DTO;
using SampleApp.Application.Contracts.Services;
using SampleApp.Domain.Entities;
using SampleApp.Infrastructure.Daos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApp.Infrastructure.Daos;
using SampleApp.Application.Contracts.DTO;

namespace SampleApp.Application.Services
{
    /// <summary>
    /// Service where all the business logic related to the Sample entity is implemented
    /// </summary>    
    internal class SampleAppService : ISampleAppService
    {
        private readonly IValidator<DTO.SampleForCreate> _validatorCreate;
        private readonly ISampleAppDAO _sampleAppDAO = new SampleAppDAO();

        public SampleAppService(IValidator<DTO.SampleForCreate> validatorCreate)
        {
            _validatorCreate = validatorCreate;
        }

        ~SampleAppService()
        {
            Dispose(false);
        }

        public async Task<IEnumerable<DTO.SampleForRead>> GetAllSamplesAsync()
        {
            IEnumerable<DTO.SampleForRead> result = await _sampleAppDAO.GetAllSamplesAsync();

            return result;
        }

        public async Task<DTO.SampleForRead> GetByIdAsync(Guid id)
        {
            DTO.SampleForRead result = await _sampleAppDAO.GetByIdAsync(id);

            return result;
        }

        public async Task<IEnumerable<DTO.SubSample>> GetSubSamplesAsync(Guid sampleId)
        {
            IEnumerable<DTO.SubSample> result = await _sampleAppDAO.GetSubSamplesAsync(sampleId);

            return result;
        }

        public async Task<DTO.SampleForRead> AddSampleAsync(DTO.SampleForCreate sampleForCreation)
        {
            if (null == sampleForCreation)
                throw new ArgumentNullException(nameof(sampleForCreation));

            var valid = _validatorCreate.Validate(sampleForCreation);
            if (!valid.IsValid)
                throw new Exception(string.Join("; ", valid.Errors.Select(c => c.ErrorMessage)));

            Sample sample = new Sample()
            {
                SampleId = sampleForCreation.SampleId,
                Name = sampleForCreation.Name,
                SubSamples = sampleForCreation.SubSamples.Select(subSample => new Domain.Entities.SubSample()
                {
                    SubSampleId = subSample.SubSampleId,
                    Info = subSample.Info
                }).ToList(),
            };

            await _sampleAppDAO.AddSampleAsync(sample);

            DTO.SampleForRead result = await _sampleAppDAO.GetByIdAsync(sample.SampleId);

            return result;
        }

        public async Task<DTO.SampleForRead> UpdateSampleAsync(DTO.SampleForUpdate sampleForUpdate)
        {
            if (null == sampleForUpdate)
                throw new ArgumentNullException(nameof(sampleForUpdate));

            Sample sample = await _sampleAppDAO.GetSampleByIdAsync(sampleForUpdate.SampleId);

            DTO.SampleForRead result = null;


            if (sample != null)
            {
                sample.Name = sampleForUpdate.Name;

                await _sampleAppDAO.UpdateSampleAsync(sample);

                result = await _sampleAppDAO.GetByIdAsync(sample.SampleId);
            }

            return result;
        }

        public async Task DeleteSampleAsync(Guid id)
        {
            await _sampleAppDAO.DeleteSampleAsync(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {

        }

        public async Task<IEnumerable<DTO.SampleSubSample>> GetByIdFlattenedAsync(DateTime? fromDate, DateTime? toDate)
        {
            IEnumerable<DTO.SampleSubSample> result = await _sampleAppDAO.GetByIdFlattenedAsync(fromDate, toDate);

            return result;
        }
    }
}
