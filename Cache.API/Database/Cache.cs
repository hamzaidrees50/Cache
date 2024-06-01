using System;
using System.Collections.Generic;

namespace Database;

public partial class Cache
{
    public int Id { get; set; }

    public string CacheKey { get; set; } = null!;

    public string Response { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
