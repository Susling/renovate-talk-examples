# 02: Grouping

A group puts several updates in one branch and one pull request (PR). Without a group, Renovate opens one PR per dependency.

| File | What it shows |
|---|---|
| [`renovate.json5`](renovate.json5) | The configuration, with one custom group |
| [`example-files/WebApi.csproj`](example-files/WebApi.csproj) | A .NET web API before the updates (NuGet) |
| [`example-files/package.json`](example-files/package.json) | A web application before the updates (npm) |
| [`pull-requests/group-dotnet-monorepo.md`](pull-requests/group-dotnet-monorepo.md) | Built-in monorepo group, NuGet |
| [`pull-requests/group-angular-monorepo.md`](pull-requests/group-angular-monorepo.md) | Built-in monorepo group, npm |
| [`pull-requests/group-npm-dev-tooling.md`](pull-requests/group-npm-dev-tooling.md) | Custom group from `groupName` |

## Two kinds of groups

| Kind | Where it comes from | How Renovate matches a package | Example |
|---|---|---|---|
| Monorepo group | `group:monorepos`, part of `config:recommended` | The source URL of the package is in a list of known monorepos | `angular monorepo`, `dotnet monorepo` |
| Custom group | A `packageRules` entry with `groupName` | The `match*` fields of the rule | `npm dev tooling` |

A monorepo is one source repository that publishes several packages. The packages usually must have the same version. The built-in list has several hundred entries. You do not configure anything for them.

A custom group is for packages that you want to review together, but that come from different repositories.

## How the group changes the PR

| Item | Without a group | With a group |
|---|---|---|
| Branch | `renovate/prettier-3.x` | `renovate/npm-dev-tooling` (from `groupName`) |
| Title, same new version for all | `Update dependency @angular/core to v19.1.1` | `Update angular monorepo to v19.1.1` |
| Title, different new versions | `Update dependency prettier to v3.4.2` | `Update npm dev tooling` |
| Table | One row | One row per package |
| Release notes | One block | One block per source repository |

## Rules to remember

A group does not cross a major version by default. `separateMajorMinor` is still `true`, so a major update in a group gets its own branch, for example `renovate/major-npm-dev-tooling`. This configuration goes one step further. The rule matches only `minor` and `patch`, so a major update is not in the group at all.

Two groups can match one package. If that happens, the last matching `packageRules` entry wins. Renovate adds your own `packageRules` after the rules from `extends`, so your group wins over a preset group.

If one package in the group fails a check, the full PR fails. A large group therefore blocks more updates than a small group.

## Real behavior and illustration

The group names, branch names, titles and the `👻 Immortal` line are what Renovate 44 produces. The `dotnet monorepo` and `angular monorepo` rules are real entries in the Renovate preset `group:monorepos`. The PR numbers and check results are fictional.

## Read more

- [Renovate docs: `groupName`](https://docs.renovatebot.com/configuration-options/#groupname)
- [Renovate docs: group presets](https://docs.renovatebot.com/presets-group/)
- [Renovate docs: monorepo presets](https://docs.renovatebot.com/presets-monorepo/)
- [Renovate docs: `recreateWhen`](https://docs.renovatebot.com/configuration-options/#recreatewhen)
