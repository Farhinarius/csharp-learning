using System;

namespace Workspace.Learning.ObjectsEssence.Resources;

// record CarRecord
// {
//     public string Make { get; init; }
//     public string Model { get; init; }
//     public string Color { get; init; }
//     public CarRecord () {}
//     public CarRecord (string make, string model, string color)
//     {
//         Make = make;
//         Model = model;
//         Color = color;
//     }
// }

// this declaration is abbreviation of declaration above. Create a entity with two immutable fields. Init them from constructor
public record CarRecord(string Make, string Model, string Color);

// record inheritance
public record PositionalCar(string Make, string Model, string Color);
public record PositionalMiniVan(string Make, string Model, string Color)
    : PositionalCar(Make, Model, Color);
