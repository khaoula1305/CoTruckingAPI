﻿namespace Cotrucking.Shared.Models
{
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
    }

    public class CountryInput
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
    }

    public class CountrySearch
    {
        public Guid? CountryId { get; set; }
        public Guid? RegionId { get; set; }
    }

    public class CountryExport
    {
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
    }
}
