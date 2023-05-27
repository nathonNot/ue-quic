// Fill out your copyright notice in the Description page of Project Settings.

using System.IO;
using UnrealBuildTool;

public class quic : ModuleRules
{
    private string ModulePath
    {
        get { return ModuleDirectory; }
    }
    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
    }

    public quic(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;
        PublicIncludePaths.AddRange(
            new string[] {
                 Path.Combine(ThirdPartyPath, "quic"),
            }
        );
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            // Add the import library
            //PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "x64", "Release", "ExampleLibrary.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "Win64", "quiche.dll.lib"));

            // Delay-load the DLL, so we can load it from the right place first
            PublicDelayLoadDLLs.Add("quiche.dll");

            // Ensure that the DLL is staged along with the executable
            RuntimeDependencies.Add(Path.Combine(ModuleDirectory, "Win64", "quiche.dll"));
            //RuntimeDependencies.Add("$(PluginDir)/Win64/quiche.dll");
        }
        //else if (Target.Platform == UnrealTargetPlatform.Mac)
        //{
        //    PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "libExampleLibrary.dylib"));
        //    RuntimeDependencies.Add("$(PluginDir)/Source/ThirdParty/uequicLibrary/Mac/Release/libExampleLibrary.dylib");
        //}
        //else if (Target.Platform == UnrealTargetPlatform.Linux)
        //{
        //    string ExampleSoPath = Path.Combine("$(PluginDir)", "Binaries", "ThirdParty", "uequicLibrary", "Linux", "x86_64-unknown-linux-gnu", "libExampleLibrary.so");
        //    PublicAdditionalLibraries.Add(ExampleSoPath);
        //    PublicDelayLoadDLLs.Add(ExampleSoPath);
        //    RuntimeDependencies.Add(ExampleSoPath);
        //}
    }

}
