﻿namespace Cotrucking.Domain.Entities.Security
{
    public class FunctionalityDataModel: BaseEntity
    {
        public string? Label { get; set; }
        public virtual ICollection<PageFunctionalityDataModel>? PageFunctionalities { get; set; }
    }
}