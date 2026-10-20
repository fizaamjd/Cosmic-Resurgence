import json,re
from pathlib import Path
p=Path('.')
json.loads((p/'Packages/manifest.json').read_text())
assert '2022.3.47f1' in (p/'ProjectSettings/ProjectVersion.txt').read_text()
for scene in re.findall(r'path: (.+)',(p/'ProjectSettings/EditorBuildSettings.asset').read_text()):
 assert (p/scene).is_file(),scene
assert list((p/'Assets').glob('*.cs'))
print('Unity source archive structure validated; editor execution requires restored assets.')
