﻿namespace KeyWorkerService.Infrastructure.DataModels.Local;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }
}
