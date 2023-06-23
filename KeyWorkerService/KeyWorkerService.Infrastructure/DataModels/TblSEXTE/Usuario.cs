using System;
using System.Collections.Generic;

namespace KeyWorkerService.Infrastructure.DataModels.TblSEXTE;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }
}
