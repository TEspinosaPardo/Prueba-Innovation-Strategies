using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Application.Contracts.DTO
{
    /// <summary>
    /// DTO with the SubSample information
    /// </summary>
    public class SampleSubSample
    {
        public Guid SampleId { get; set; }
        public string SampleName { get; set; }
        public DateTimeOffset SampleCreated { get; set; }
        public Guid SubSampleId { get; set; }

        public string SubSampleInfo { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Id: {SubSampleId} - Name: {SubSampleInfo}";
        }
    }
}
