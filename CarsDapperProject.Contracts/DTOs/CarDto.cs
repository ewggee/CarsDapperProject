﻿namespace CarsDapperProject.Contracts.DTOs;

public class CarDto
{
    public int Id { get; set; }
    public string Model { get; set; }
    public ShortOwnerDto Owner { get; set; }
}
