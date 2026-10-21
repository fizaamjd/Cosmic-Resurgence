# Native macOS build

Use Unity 2022.3.47f1 with an activated license and the complete original Assets folder. The public authored-source archive excludes imported artwork; restore it before compiling. Work from a copy of the original project to preserve the archive.

The helper builds all enabled scenes in their stored order. Dungeon Escape has no saved build-scene list, so the helper explicitly falls back to its SampleScene. Cosmic Resurgence keeps its cutscene, menu, three planet levels and ending scenes.

```sh
GAME_BUILD_OUTPUT="/absolute/output/Cosmic Resurgence.app" \
"/Applications/Unity/Hub/Editor/2022.3.47f1/Unity.app/Contents/MacOS/Unity" \
  -batchmode -quit -projectPath "/absolute/path/to/complete-project" \
  -executeMethod PortfolioBuild.Mac -logFile "/absolute/output/build.log"
```

Copy Assets/Editor/PortfolioBuild.cs into the complete working project before running the command. Inspect the build log and launch the resulting application to verify controls and level progression. This helper is prepared but has not yet been executed with Unity on the maintenance machine. Source checks are not a substitute for a successful editor build or gameplay test.
