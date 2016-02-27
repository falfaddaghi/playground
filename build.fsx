#r @"packages/fake/tools/FakeLib.dll"

open Fake

let buildDir ="./build/"

Target "Clean" (fun _ -> 
        CleanDir buildDir)

Target "BuildSuave" (fun _ -> 
        !! "Suave/*.fsproj"
        |> MSBuildRelease buildDir "Build"
        |> Log "Buildsuave-output :"
)

Target "Default" (fun _ -> trace "hello world")

"Clean"
    ==> "BuildSuave"
    ==> "Default"


RunTargetOrDefault "Default"