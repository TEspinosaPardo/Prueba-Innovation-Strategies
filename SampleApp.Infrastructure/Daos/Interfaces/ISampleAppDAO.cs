using DTO = SampleApp.Application.Contracts.DTO;
using SampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Infrastructure.Daos.Interfaces
{
    public interface ISampleAppDAO
    {
        Task<IEnumerable<DTO.SampleForRead>> GetAllSamplesAsync();
        Task<DTO.SampleForRead> GetByIdAsync(Guid id);
        Task<IEnumerable<DTO.SubSample>> GetSubSamplesAsync(Guid sampleId);
        Task AddSampleAsync(Sample sample);
        Task<Sample> GetSampleByIdAsync(Guid sampleId);
        Task UpdateSampleAsync(Sample sample);
        Task DeleteSampleAsync(Guid id);
        Task<IEnumerable<DTO.SampleSubSample>> GetByIdFlattenedAsync(DateTime? fromDate, DateTime? toDate);
    }
}
