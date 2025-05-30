﻿using CarsDapperProject.Contracts.Attributes;

namespace CarsDapperProject.Contracts.DTOs.Requests.Brand;

public class UpdateBrandRequest
{
    [StringLengthField(min: 1, max: 100)]
    public string Name { get; set; }
}
