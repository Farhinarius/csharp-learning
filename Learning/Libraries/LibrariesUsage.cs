﻿// default usings namespaces statements (import whole namespace)      
// use type like -> new Square() (from namespace Workspace.Learning.Libraries.Shapes)
using Learning.Libraries.Resources.Shapes;
using Learning.Libraries.Resources.Shapes3D;

// give aliases to class Shape3D types (import specific type)
// use type like -> new Square3D() (from namespace Workspace.Learning.Libraries.Shapes3D)
using Hexagon3D = Learning.Libraries.Resources.Shapes3D.Hexagon;
using Circle3D = Learning.Libraries.Resources.Shapes3D.Circle;
using Square3D = Learning.Libraries.Resources.Shapes3D.Square;

// import namespaces as aliases, not a class
using figures = Learning.Classes.Resources.Figures;
using bfHome = System.Runtime.Serialization.Formatters.Binary;
// or
using System.Runtime.Serialization.Formatters.Binary;
using CarLibrary.Models;

namespace Learning.Libraries;

public static class LibrariesUsage
{
    // example of using types from imported namespace
    public static void UseTypesFromImportedNamespaces()
    {
        // using Shape classes rise a conflict,
        // since Shapes and Shapes3d contain classes with identical names
        // and it's not clear from which namespace to use type.
        //Hexagon h = new Hexagon();                          // Ошибка на этапе компиляции!
        //Circle c = new Circle();                            // Ошибка на этапе компиляции!
        //Square s = new Square();                            // Ошибка на этапе компиляции!
    }

    // fixture example of namespace conflicts                       // solve type naming conflict with full namespace specification 
    public static void UseNamespaceTypesWithoutUsingStatement()
    {
        Resources.Shapes.Hexagon h = new Resources.Shapes.Hexagon();
        Resources.Shapes.Circle c = new Resources.Shapes.Circle();
        Resources.Shapes.Square s = new Resources.Shapes.Square();
    }

    // use class aliases to solve type naming conflicts
    public static void SolveSimilarTypeNameConflictsByAliases()
    {
        Hexagon3D h = new Hexagon3D();
        Circle3D с = new Circle3D();  
        Square3D s = new Square3D();  
    }
    
    // use namespace aliases to shorten calls from similar namespaces
    public static void TestAliasNamespace()
    {
        figures.Circle c = new figures.Circle();
        figures.BitmapImage img = new figures.BitmapImage();
        bfHome.BinaryFormatter b = new bfHome.BinaryFormatter();
        BinaryFormatter bf = new BinaryFormatter();
    }

    // You can see example of Project as Class Library (.NET6, not .NET Standard) in "CarLibrary"
    // You can see example of project library (.net6) in "CarLibrary" project
    // You can see usage of "CarLibrary" project as dependency library in "CarClient" project

    // Nuget Package creation and usage example
    // 1. Specify Nuget sources in Nuget.Config file
    // There are several sources for CarLibrary nuget package 
    // To reproduce package generation process use ".\CarLibrary\Publish" storage
    // 2. Pack project into nuget package
    // cd <ProjectFolder>                                    // cd .\CarLibrary
    // dotnet build -с Release
    // dotnet pack -о .\Publish -c Debug
    // cd <solution folder>                                  // cd ..
    // dotnet add <Project> package <PackageName>            // dotnet add Learning package CarLibrary // dotnet add (to) Learning package CarLibrary

    // For convinience purposes after clean project start (after cloning for example)
    // there are also ".\CarLibrary\bin\Debug" package source avaialable in Nuget.Config

    // Use created Nuget Package
    public static void UseNugetPackage()
    {
        MiniVan miniVan = new MiniVan();
        miniVan.TurboBoost();
    }

    // 4. Publish executable project by using dotnet publish ! to test use CarClient project !
    // cd .\CarLibrary
    // 4.1 Publish .net infrastructure dependent (require .net runtime and specific OS) build to Debug folder. 
    // Path: bin\Debug\net6.0\publish ->
    // dotnet publish                                                                   
    // 4.2 Publish .net infrastructure dependent build to Release folder. Path: bin\Release\net6.0\publish
    // dotnet publish -c release
    // 4.3 Publish infrastructure independent (can work without .net runtime) build called self-contained build. 
    // dotnet publish -r win-x64 -c release -o selfcontained --self-contained true
    // 4.4 Publish self-contained and single file build. (Check option in project CarClient!!!) : <IncludeNativeLibrariesForSelfExtract>
    // dotnet publish -r win-x64 -c release -o --singlefile-selfcontained --self-contained true p:PublishSingleFile=true
    // prepare self-contained single file executable
}