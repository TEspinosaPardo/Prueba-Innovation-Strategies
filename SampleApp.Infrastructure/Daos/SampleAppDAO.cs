using Microsoft.EntityFrameworkCore;
using DTO = SampleApp.Application.Contracts.DTO;
using SampleApp.Domain.Entities;
using SampleApp.Infrastructure.Daos.Interfaces;
using SampleApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Application.Contracts.DTO;

namespace SampleApp.Infrastructure.Daos
{
    public class SampleAppDAO : ISampleAppDAO
    {
        private readonly SampleContext dbContext = new SampleContext();

        public async Task<IEnumerable<DTO.SampleForRead>> GetAllSamplesAsync()
        {
            return await dbContext.Sample
                .Select(sample => new DTO.SampleForRead()
                {
                    Name = sample.Name,
                    Created = sample.Created,
                    Sample1Id = sample.SampleId
                }).ToListAsync();
        }

        public async Task<DTO.SampleForRead> GetByIdAsync(Guid id)
        {
            return await dbContext.Sample.Where(sample => sample.SampleId.Equals(id))
                .Select(sample => new DTO.SampleForRead()
                {
                    Name = sample.Name,
                    Created = sample.Created,
                    Sample1Id = sample.SampleId,
                    SubSamples = sample.SubSamples.Select(subSample => new DTO.SubSample
                    {
                        SubSampleId = subSample.SubSampleId,
                        Info = subSample.Info
                    })
                }).FirstOrDefaultAsync();
        }

        public async Task<Sample> GetSampleByIdAsync(Guid id)
        {
            return await dbContext.Sample.FirstOrDefaultAsync(sample => sample.SampleId.Equals(id));
        }

        public async Task<IEnumerable<DTO.SubSample>> GetSubSamplesAsync(Guid sampleId)
        {
            return await dbContext.SubSample.Where(subSample => subSample.SampleId.Equals(sampleId))
                .Select(subSample => new DTO.SubSample
                {
                    SubSampleId = subSample.SubSampleId,
                    Info = subSample.Info
                }).ToListAsync();
        }

        public Task AddSampleAsync(Sample sampleForCreation)
        {
            dbContext.Sample.Add(sampleForCreation);
            return dbContext.SaveChangesAsync();
        }

        public Task DeleteSampleAsync(Guid id)
        {
            dbContext.Sample.Remove(dbContext.Sample.FirstOrDefault(sample => sample.SampleId.Equals(id)));
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateSampleAsync(Sample sample)
        {
            return dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DTO.SampleSubSample>> GetByIdFlattenedAsync(DateTime? fromDate, DateTime? toDate)
        {
            return await dbContext.Sample
                .SelectMany(sample => sample.SubSamples, (sample, subSamples) => new { sample, subSamples })
                .Select(collection => new DTO.SampleSubSample()
                {
                    SampleName = collection.sample.Name,
                    SampleCreated = collection.sample.Created,
                    SampleId = collection.sample.SampleId,
                    SubSampleId = collection.subSamples.SubSampleId,
                    SubSampleInfo = collection.subSamples.Info
                })
                .Where(sample => (fromDate == null || sample.SampleCreated >= fromDate) && (toDate == null || sample.SampleCreated <= toDate)).ToListAsync();
        }
    }
}
