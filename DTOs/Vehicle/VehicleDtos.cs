namespace projetNet.DTOs.Vehicle;

/// <summary>
/// Request DTO for creating a new vehicle listing
/// </summary>
public class CreateVehicleRequest
{
    /// <summary>
    /// Vehicle Identification Number (17 characters)
    /// </summary>
    public required string Vin { get; set; }
    
    /// <summary>
    /// Vehicle brand/manufacturer (e.g., Toyota, BMW)
    /// </summary>
    public required string Brand { get; set; }
    
    /// <summary>
    /// Vehicle model (e.g., Corolla, X5)
    /// </summary>
    public required string Model { get; set; }
    
    /// <summary>
    /// Manufacturing year
    /// </summary>
    public int Year { get; set; }
    
    /// <summary>
    /// Listed price
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Vehicle description
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Current mileage in kilometers
    /// </summary>
    public int Mileage { get; set; }
    
    /// <summary>
    /// Location/city where vehicle is located
    /// </summary>
    public required string Location { get; set; }
    
    /// <summary>
    /// Image URL (optional, can be uploaded separately)
    /// </summary>
    public string? ImageUrl { get; set; }
}

/// <summary>
/// Request DTO for updating an existing vehicle listing
/// </summary>
public class UpdateVehicleRequest
{
    /// <summary>
    /// Vehicle brand/manufacturer
    /// </summary>
    public required string Brand { get; set; }
    
    /// <summary>
    /// Vehicle model
    /// </summary>
    public required string Model { get; set; }
    
    /// <summary>
    /// Manufacturing year
    /// </summary>
    public int Year { get; set; }
    
    /// <summary>
    /// Listed price
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Vehicle description
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Current mileage in kilometers
    /// </summary>
    public int Mileage { get; set; }
    
    /// <summary>
    /// Location/city where vehicle is located
    /// </summary>
    public required string Location { get; set; }
    
    /// <summary>
    /// Image URL
    /// </summary>
    public string? ImageUrl { get; set; }
}

/// <summary>
/// Response DTO for vehicle information
/// </summary>
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

/// <summary>
/// Request parameters for searching vehicles
/// </summary>
public class SearchVehiclesRequest
{
    /// <summary>
    /// Filter by brand
    /// </summary>
    public string? Brand { get; set; }
    
    /// <summary>
    /// Minimum year (inclusive)
    /// </summary>
    public int? MinYear { get; set; }
    
    /// <summary>
    /// Maximum year (inclusive)
    /// </summary>
    public int? MaxYear { get; set; }
    
    /// <summary>
    /// Minimum price (inclusive)
    /// </summary>
    public decimal? MinPrice { get; set; }
    
    /// <summary>
    /// Maximum price (inclusive)
    /// </summary>
    public decimal? MaxPrice { get; set; }
    
    /// <summary>
    /// Maximum mileage (inclusive)
    /// </summary>
    public int? MaxMileage { get; set; }
    
    /// <summary>
    /// Filter by location
    /// </summary>
    public string? Location { get; set; }
    
    /// <summary>
    /// Page number (default: 1)
    /// </summary>
    public int Page { get; set; } = 1;
    
    /// <summary>
    /// Items per page (default: 20, max: 100)
    /// </summary>
    public int PageSize { get; set; } = 20;
}
