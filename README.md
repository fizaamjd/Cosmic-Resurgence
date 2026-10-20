# Planet-1

A Unity 3D space-survival game with three planet stages, astronaut movement, oxygen pickups, health, lives, cutscenes, and scene progression.

**Status:** archived coursework, documented and organized for source review. **Engine:** Unity 2022.3.47f1 / C#.

## What is implemented

- Three planet stages, a menu, an introductory cutscene, and win/lose scenes.
- Forward movement and rotation with WASD or arrow keys; F toggles a float animation.
- Key collection gates spaceship transitions.
- Oxygen-tank collision replenishes health; health and lives are carried through GameData.
- The original timer uses a configurable time multiplier and the health decrement is frame-based, so behavior is frame-rate dependent.

## Original project video

[Watch the original in-game cutscene](docs/media/original-cutscene.mp4). This is original project footage, not a new playthrough.

The preserved Windows build is distributed in [Releases](https://github.com/fizaamjd/Planet-1/releases). Extract the full archive before launching `Planet-1.exe`; the Data folder, UnityPlayer and Mono runtime must remain together.

## Run and inspect

Read [asset setup](docs/ASSET_SETUP.md) before opening Unity. This is an authored-source archive; imported artwork must be restored separately. Build scenes are retained in `ProjectSettings/EditorBuildSettings.asset`.

## Source map

| Path | Purpose |
| --- | --- |
| `Assets/*.cs` | Gameplay and UI behaviors |
| `Assets/All Scenes` or `Assets/Scenes` | Authored scene serialization |
| `Packages` | Unity package versions |
| `ProjectSettings` | Editor version, input mapping and build-scene order |
| `docs/asset-manifest.json` | Asset paths, sizes and hashes for restoration |

## Verification

Repository checks validate the package manifest, editor version, scene references and source inventory. Unity and the Windows runtime are not installed on the maintenance host, so an editor build or playthrough is not claimed. See asset setup for the required local validation.

## Project maintenance

[Contributing](CONTRIBUTING.md) · [Security](SECURITY.md) · [Third-party notices](THIRD_PARTY_NOTICES.md)

MIT covers original code and documentation only. Original source folder: `Planet-1`. No second copy of this project is published under another repository name.
