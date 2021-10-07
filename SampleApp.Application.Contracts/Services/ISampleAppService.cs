using SampleApp.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.Application.Contracts.Services
{
    /// <summary>
    /// ISample1AppService
    /// </summary>
    public interface ISampleAppService : IDisposable
    {
        /// <summary>
        /// Get paginated
        /// </summary>
        /// <param name="numPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<SampleForRead>> GetAllSamplesAsync();

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SampleForRead> GetByIdAsync(Guid id);

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        Task<IEnumerable<Contracts.DTO.SubSample>> GetSubSamplesAsync(Guid sampleId);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="sampleForCreation"></param>
        /// <returns></returns>
        Task<SampleForRead> AddSampleAsync(SampleForCreate sampleForCreation);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="sampleForCreation"></param>
        /// <returns></returns>
        Task<SampleForRead> UpdateSampleAsync(SampleForUpdate sampleForUpdate);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteSampleAsync(Guid id);
        Task<IEnumerable<DTO.SampleSubSample>> GetByIdFlattenedAsync(DateTime? fromDate, DateTime? toDate);
    }
}
