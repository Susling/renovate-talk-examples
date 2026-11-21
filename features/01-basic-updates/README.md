# 01: Basic updates (patch, minor, major)

Renovate reads the dependency files in a repository, asks each registry for newer versions, and opens one pull request (PR) per update.

| File | What it shows |
|---|---|
| [`renovate.json5`](renovate.json5) | The configuration for this example |
| [`example-files/package.json`](example-files/package.json) | A web application before the updates (npm) |
| [`example-files/WebApi.csproj`](example-files/WebApi.csproj) | A .NET web API before the updates (NuGet) |
| [`pull-requests/patch-serilog-aspnetcore.md`](pull-requests/patch-serilog-aspnetcore.md) | Patch PR, NuGet |
| [`pull-requests/minor-prettier.md`](pull-requests/minor-prettier.md) | Minor PR, npm |
| [`pull-requests/major-eslint.md`](pull-requests/major-eslint.md) | Major PR, npm, with a failed check |

## How Renovate finds the dependencies

A manager is the part of Renovate that reads one file type. The `npm` manager reads `package.json`. The `nuget` manager reads `*.csproj`, `Directory.Packages.props` and other MSBuild files. Both managers are on by default, so the configuration does not name any files.

A datasource is the part of Renovate that asks a registry for versions. The `npm` manager uses the `npm` datasource (registry.npmjs.org). The `nuget` manager uses the `nuget` datasource (api.nuget.org).

## Patch, minor and major

Renovate compares the current version with the new version. The result is the update type.

| Update type | Example | Rule | PR in this folder |
|---|---|---|---|
| patch | `Serilog.AspNetCore` 8.0.2 to 8.0.3 | Only the last number changes | [patch-serilog-aspnetcore.md](pull-requests/patch-serilog-aspnetcore.md) |
| minor | `prettier` 3.3.3 to 3.4.2 | The middle number changes | [minor-prettier.md](pull-requests/minor-prettier.md) |
| major | `eslint` 8.57.1 to 9.18.0 | The first number changes | [major-eslint.md](pull-requests/major-eslint.md) |

The configuration can use the update type in a `packageRules` entry, with `matchUpdateTypes`. Feature 03 uses it to automerge only patch updates.

## Default behavior from `config:recommended`

| Behavior | Configuration option | Effect in the examples |
|---|---|---|
| One PR per dependency and major version | `separateMajorMinor: true` (default) | `Serilog.AspNetCore` gets one PR for 8.0.3 and one PR for 9.0.0 |
| Patch and minor in the same branch | `separateMinorPatch: false` (default) | The branch is `renovate/serilog.aspnetcore-8.x` and not `-8.0.x` |
| Newest version only | No option. This is how the lookup works | `prettier` goes to 3.4.2 directly and skips 3.4.0 and 3.4.1 |
| Age and Confidence columns | `mergeConfidence:age-confidence-badges` | Shown for npm and NuGet, not for Helm or Docker |

## Titles and branch names

| Item | Template (default) | Result |
|---|---|---|
| PR title | `Update dependency {depName} to v{newVersion}` | `Update dependency prettier to v3.4.2` |
| PR title, major | `Update dependency {depName} to v{newMajor}` | `Update dependency eslint to v9` |
| Branch | `renovate/{depNameSanitized}-{newMajor}.x` | `renovate/prettier-3.x` |

The titles have no `chore(deps):` prefix. The `semanticCommits` option is `auto` by default. If the last commits in the repository use Conventional Commits (a commit message format like `fix: ...`), Renovate adds the prefix.

## Real behavior and illustration

The PR titles, branch names, table format and the configuration text are what Renovate 44 produces. The release notes come from the real GitHub releases. The PR numbers and the check results are fictional.

## Read more

- [Renovate docs: Updating and rebasing branches](https://docs.renovatebot.com/updating-rebasing/)
- [Renovate docs: `separateMajorMinor`](https://docs.renovatebot.com/configuration-options/#separatemajorminor)
- [Renovate docs: `matchUpdateTypes`](https://docs.renovatebot.com/configuration-options/#matchupdatetypes)
