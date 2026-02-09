namespace projetNet.DTOs.Vehicle;

public class CreateVehicleRequest
{
    public required string Vin { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }

    public int Year { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Mileage { get; set; }
    public required string Location { get; set; }
    public string? ImageUrl { get; set; }
}

public class UpdateVehicleRequest
{
    public required string Brand { get; set; } 
    public required string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; } 
    public int Mileage { get; set; }   
    public required string Location { get; set; }
    public string? ImageUrl { get; set; }
}

public class VehicleResponse
{
    public Guid Id { get; set; }
    public string Vin { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string OwnerId { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Mileage { get; set; }
    public string Location { get; set; } = string.Empty;
}
public class SearchVehiclesRequest
{
    public string? Brand { get; set; }
    public int? MinYear { get; set; }
    public int? MaxYear { get; set; } 
    public decimal? MinPrice { get; set; } 
    public decimal? MaxPrice { get; set; } 
    public int? MaxMileage { get; set; }
    public string? Location { get; set; } 
    public int Page { get; set; } = 1; 
    public int PageSize { get; set; } = 20;
}
