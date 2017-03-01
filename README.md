# BuildBud
Create post-build MSBuild tasks that are defined within the currently building assembly

# Usage

Install the nuget package via the package manager UI or by running the following command

    Install-Package BuildBud
    
Create a class in your assembly that inheirits from `BuildBud.BuildTask`, and it will be executed as a post-build step. \
You can also return false to fail the build or access `this.Log(...` to send log messages to msbuild.
