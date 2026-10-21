using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public static class PortfolioBuild
{
    public static void Mac()
    {
        var output = Environment.GetEnvironmentVariable("GAME_BUILD_OUTPUT");
        if (string.IsNullOrWhiteSpace(output) || !Path.IsPathRooted(output) || !output.EndsWith(".app"))
            throw new BuildFailedException("GAME_BUILD_OUTPUT must be an absolute .app path.");
        var scenes = EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
        if (scenes.Length == 0 && File.Exists("Assets/Scenes/SampleScene.unity"))
            scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        if (scenes.Length == 0 || scenes.Any(s => !File.Exists(s)))
            throw new BuildFailedException("Missing playable scenes. Restore the original Assets folder first.");
        Directory.CreateDirectory(Path.GetDirectoryName(output));
        var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions {
            scenes = scenes, locationPathName = output,
            target = BuildTarget.StandaloneOSX, options = BuildOptions.None
        });
        if (report.summary.result != BuildResult.Succeeded)
            throw new BuildFailedException("Build failed: " + report.summary.result);
    }
}
