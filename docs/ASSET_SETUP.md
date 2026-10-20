# Restoring the Unity project

Editor: **Unity 2022.3.47f1**. Install through Unity Hub with the target build module.

This public source archive includes gameplay C#, authored scenes, project settings and the package manifest. Raw imported art, models, animations, audio and asset-store bundles are intentionally not republished. The complete original local project remains unchanged.

1. Obtain the original `Planet-1/Assets` folder from the project owner, or obtain each required pack under its original license.
2. Restore the asset paths and `.meta` GUIDs listed in `asset-manifest.json`. New imports can generate different GUIDs and require relinking serialized scene references.
3. Open the repository in Unity Hub with 2022.3.47f1. Allow package resolution and import TextMesh Pro essentials when prompted.
4. Resolve missing materials, prefabs, animations and fonts before building. Use the scene list in `ProjectSettings/EditorBuildSettings.asset`.

The checked-in archive alone is **not** a complete art-inclusive Unity build. No automatic Unity build is claimed, and no Unity activation secret is required by repository CI.
