﻿namespace WarehouseAPI.Domain.DTOs
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public int Number { get; set; }
    }
}
