using FluentValidation;
using projetNet.DTOs.Vehicle;

namespace projetNet.Validators;

/// <summary>
/// Validator for CreateVehicleRequest
/// Ensures all required fields are present and valid
/// </summary>
public class CreateVehicleRequestValidator : AbstractValidator<CreateVehicleRequest>
{
    public CreateVehicleRequestValidator()
    {
        RuleFor(x => x.Vin)
            .NotEmpty().WithMessage("VIN is required")
            .Length(17).WithMessage("VIN must be exactly 17 characters")
            .Matches("^[A-HJ-NPR-Z0-9]{17}$")
            .WithMessage("VIN must contain only valid characters (no I, O, or Q)");
        
        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand is required")
            .MaximumLength(50).WithMessage("Brand must not exceed 50 characters");
        
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required")
            .MaximumLength(50).WithMessage("Model must not exceed 50 characters");
        
        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.Now.Year + 1)
            .WithMessage($"Year must be between 1900 and {DateTime.Now.Year + 1}");
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThanOrEqualTo(10_000_000).WithMessage("Price must not exceed 10,000,000");
        
        RuleFor(x => x.Mileage)
            .GreaterThanOrEqualTo(0).WithMessage("Mileage cannot be negative")
            .LessThanOrEqualTo(1_000_000).WithMessage("Mileage must not exceed 1,000,000");
        
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(100).WithMessage("Location must not exceed 100 characters");
        
        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}

/// <summary>
/// Validator for UpdateVehicleRequest
/// Similar rules to CreateVehicleRequest but without VIN (cannot be changed)
/// </summary>
public class UpdateVehicleRequestValidator : AbstractValidator<UpdateVehicleRequest>
{
    public UpdateVehicleRequestValidator()
    {
        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand is required")
            .MaximumLength(50).WithMessage("Brand must not exceed 50 characters");
        
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required")
            .MaximumLength(50).WithMessage("Model must not exceed 50 characters");
        
        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.Now.Year + 1)
            .WithMessage($"Year must be between 1900 and {DateTime.Now.Year + 1}");
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThanOrEqualTo(10_000_000).WithMessage("Price must not exceed 10,000,000");
        
        RuleFor(x => x.Mileage)
            .GreaterThanOrEqualTo(0).WithMessage("Mileage cannot be negative")
            .LessThanOrEqualTo(1_000_000).WithMessage("Mileage must not exceed 1,000,000");
        
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(100).WithMessage("Location must not exceed 100 characters");
        
        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}

/// <summary>
/// Validator for SearchVehiclesRequest
/// Ensures search parameters are within valid ranges
/// </summary>
public class SearchVehiclesRequestValidator : AbstractValidator<SearchVehiclesRequest>
{
    public SearchVehiclesRequestValidator()
    {
        RuleFor(x => x.MinYear)
            .GreaterThanOrEqualTo(1900)
            .WithMessage("Minimum year must be 1900 or later")
            .When(x => x.MinYear.HasValue);
        
        RuleFor(x => x.MaxYear)
            .LessThanOrEqualTo(DateTime.Now.Year + 1)
            .WithMessage($"Maximum year cannot exceed {DateTime.Now.Year + 1}")
            .When(x => x.MaxYear.HasValue);
        
        RuleFor(x => x)
            .Must(x => !x.MinYear.HasValue || !x.MaxYear.HasValue || x.MinYear.Value <= x.MaxYear.Value)
            .WithMessage("Minimum year must be less than or equal to maximum year")
            .When(x => x.MinYear.HasValue && x.MaxYear.HasValue);
        
        RuleFor(x => x.MinPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Minimum price cannot be negative")
            .When(x => x.MinPrice.HasValue);
        
        RuleFor(x => x.MaxPrice)
            .GreaterThan(0)
            .WithMessage("Maximum price must be greater than 0")
            .When(x => x.MaxPrice.HasValue);
        
        RuleFor(x => x)
            .Must(x => !x.MinPrice.HasValue || !x.MaxPrice.HasValue || x.MinPrice.Value <= x.MaxPrice.Value)
            .WithMessage("Minimum price must be less than or equal to maximum price")
            .When(x => x.MinPrice.HasValue && x.MaxPrice.HasValue);
        
        RuleFor(x => x.MaxMileage)
            .GreaterThan(0)
            .WithMessage("Maximum mileage must be greater than 0")
            .When(x => x.MaxMileage.HasValue);
        
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0");
        
        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("Page size must be between 1 and 100");
    }
}
