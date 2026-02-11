namespace projetNet.Helpers;

public static class VehicleData
{
    public static Dictionary<string, List<string>> BrandsWithModels =
        new Dictionary<string, List<string>>
        {
            { "Renault", new List<string> { "Clio", "Megane", "Captur" } },
            { "Toyota", new List<string> { "Corolla", "Yaris", "Rav4" } },
            { "BMW", new List<string> { "X5", "X3", "Serie 3" } },
            { "Mercedes", new List<string> { "C-Class", "E-Class", "GLA" } }
        };

    public static List<string> GetBrands()
    {
        return BrandsWithModels.Keys.ToList();
    }

    public static List<string> GetModels(string brand)
    {
        return BrandsWithModels.ContainsKey(brand)
            ? BrandsWithModels[brand]
            : new List<string>();
    }
}