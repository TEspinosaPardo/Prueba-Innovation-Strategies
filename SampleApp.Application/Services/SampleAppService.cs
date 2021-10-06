using FluentValidation;
using SampleApp.Application.Contracts.DTO;
using SampleApp.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Application.Services
{
    /// <summary>
    /// Service where all the business logic related to the Sample entity is implemented
    /// </summary>    
    internal class SampleAppService : ISampleAppService
    {
        private readonly IValidator<SampleForCreate> _validatorCreate;

        public SampleAppService(IValidator<SampleForCreate> validatorCreate)
        {
            _validatorCreate = validatorCreate;
        }

        ~SampleAppService()
        {
            Dispose(false);
        }

        public async Task<IEnumerable<SampleForRead>> GetAllSamplesAsync()
        {
            IEnumerable<Application.Contracts.DTO.SampleForRead> result = null;

            return result;
        }

        public async Task<SampleForRead> GetByIdAsync(Guid id)
        {
            SampleForRead result = null;

            return result;
        }

        public async Task<IEnumerable<Contracts.DTO.SubSample>> GetSubSamplesAsync(Guid sampleId)
        {
            IEnumerable<Application.Contracts.DTO.SubSample> result = null;

            return result;
        }

        public async Task<SampleForRead> AddSampleAsync(SampleForCreate sampleForCreation)
        {
            if (null == sampleForCreation)
                throw new ArgumentNullException(nameof(sampleForCreation));

            var valid = _validatorCreate.Validate(sampleForCreation);
            if (!valid.IsValid)
                throw new Exception(String.Join("; ", valid.Errors.Select(c => c.ErrorMessage)));

            SampleForRead result = null;

            return result;
        }

        public async Task<SampleForRead> UpdateSampleAsync(SampleForUpdate sampleForUpdate)
        {
            if (null == sampleForUpdate)
                throw new ArgumentNullException(nameof(sampleForUpdate));

            SampleForRead result = null;
            
            return result;
        }

        public async Task DeleteSampleAsync(Guid id)
        {
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {

        }
    }
}
