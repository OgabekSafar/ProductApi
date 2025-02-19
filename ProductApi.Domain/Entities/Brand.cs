﻿namespace ProductApi.Domain.Entities;

public class Brand
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<CategoryBrand> CategoryBrands { get; set; }
    public List<Product> Products { get; set; }
}
