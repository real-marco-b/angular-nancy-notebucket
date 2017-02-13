using System;

namespace NoteBucket.Backend.Api.Contracts
{
    /// <summary>
    /// Specifies the API for generating demo data.
    /// The purpose of this API is to generate some quick fixture data during development.
    /// </summary>
    public interface IDemoDataService
    {
        /// <summary>
        /// Creates the demo data.
        /// </summary>
        void CreateDemoData();
    }
}
