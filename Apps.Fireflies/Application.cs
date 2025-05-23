﻿using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Fireflies;

public class Application : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [
            ApplicationCategory.ArtificialIntelligence,
            ApplicationCategory.Multimedia
        ];
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}