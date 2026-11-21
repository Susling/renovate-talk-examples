# Configuration reference

This page lists every Renovate option that the configurations in this repository use. The defaults come from the option definitions in Renovate 44.247.1. Each option name links to the Renovate docs.

All 15 configuration files in this repository passed the validator of Renovate 44.247.1 in strict mode. This command runs the same check on the two complete configurations:

```sh
npx --yes --package renovate@44.247.1 -- renovate-config-validator --strict --no-global configs/*.json5
```

## What `config:recommended` turns on

Every configuration here starts with `extends: ['config:recommended']`. This preset is the one that the Renovate onboarding PR suggests. It extends these presets:

| Preset | Effect | Feature |
|---|---|---|
| `:dependencyDashboard` | Sets `dependencyDashboard.enabled` to `true` | [04](../features/04-dependency-dashboard/README.md) |
| `:semanticPrefixFixDepsChoreOthers` | If the repository uses semantic commits, gives `fix` to runtime dependencies and `chore` to all others | None |
| `:ignoreModulesAndTests` | Ignores files under `node_modules`, `bower_components`, `vendor`, `examples`, `test`, `tests`, `__tests__` and `__fixtures__`. For NuGet, Renovate still reads `test` and `tests` | None |
| `group:monorepos` | Groups the packages of known monorepos, for example Angular and .NET | [02](../features/02-grouping/README.md) |
| `group:recommended` | Groups other known package families, for example `group:nodeJs` | [02](../features/02-grouping/README.md) |
| `mergeConfidence:age-confidence-badges` | Adds the columns Age and Confidence to the PR table for npm, NuGet and five other datasources | [01](../features/01-basic-updates/README.md) |
| `replacements:all` | Replaces known renamed and deprecated packages | [06](../features/06-replacement-prs/README.md) |
| `workarounds:all` | Fixes the versioning of known packages that do not follow their own scheme | None |
| `security:php2shell` | Updates PHP runtime versions that have the vulnerabilities CVE-2026-109618 and CVE-2026-109619 | None |
| `helpers:githubDigestChangelogs` | Adds a link to the commit diff for digest updates from GitHub. Three similar presets do the same for Forgejo, Gitea and GitLab | None |
| `helpers:goXPackagesChangelogLink`, `helpers:goXPackagesNameLink` | Adds links for Go packages under `golang.org/x` | None |
| `helpers:renovateChangelog` | Adds a link to a better view of the Renovate changelog, for updates of Renovate itself | None |

## Options at the top level

| Option | Type | Default | What it does | Used in |
|---|---|---|---|---|
| [`extends`](https://docs.renovatebot.com/configuration-options/#extends) | list | none | Adds the options of one or more presets | All |
| [`labels`](https://docs.renovatebot.com/configuration-options/#labels) | list | none | Labels for every PR. A later `labels` replaces the list | All |
| [`dependencyDashboard`](https://docs.renovatebot.com/configuration-options/#dependencydashboard) | object | `enabled: false`, `title: 'Dependency Dashboard'`, `autoclose: false`, `pinned: false` | The issue with all updates | 04, app |
| [`lockFileMaintenance`](https://docs.renovatebot.com/configuration-options/#lockfilemaintenance) | object | `enabled: false`, `schedule: ['before 4am on monday']` | A PR that creates the lock file again | 04, 05, app |
| [`vulnerabilityAlerts`](https://docs.renovatebot.com/configuration-options/#vulnerabilityalerts) | object | `schedule: []`, `prCreation: 'immediate'`, `prConcurrentLimit: 0`, `commitMessageSuffix: '[SECURITY]'` | The options for security PRs | 07, app |
| [`rollback`](https://docs.renovatebot.com/configuration-options/#rollback) | object | `commitMessageAction: 'Roll back'`, `semanticCommitType: 'fix'` | The options for rollback PRs | 08, app |
| [`schedule`](https://docs.renovatebot.com/configuration-options/#schedule) | list | `['at any time']` | Renovate creates and updates branches only inside these times | 07. Also inside `lockFileMaintenance` |
| [`hostRules`](https://docs.renovatebot.com/configuration-options/#hostrules) | list | none | Credentials for one host and one host type | No configuration file. The README of 09.2 shows an example for a private registry |
| [`customManagers`](https://docs.renovatebot.com/configuration-options/#custommanagers) | list | `[]` | Your own managers, for example with a regular expression | 09.4, infrastructure |
| [`helm-values`](https://docs.renovatebot.com/modules/manager/helm-values/) | object | `managerFilePatterns` matches `values.yaml` | The options for the `helm-values` manager | 09.3, infrastructure |
| [`kubernetes`](https://docs.renovatebot.com/modules/manager/kubernetes/) | object | `managerFilePatterns: []` | The options for the `kubernetes` manager | 09.5, infrastructure |

A pattern that you set in `managerFilePatterns` adds to the default pattern of the manager. It does not replace the default.

## Options in `packageRules`

A package rule has match options and options to apply. All match options in one rule must match. If two rules set the same option, the later rule wins. The option `addLabels` is the exception, because each rule adds to the list.

| Option | Kind | What it matches or does | Used in |
|---|---|---|---|
| [`matchManagers`](https://docs.renovatebot.com/configuration-options/#matchmanagers) | Match | The manager, for example `npm`, `nuget` or `helmv3` | 01, 02, 09.1, app, infrastructure |
| [`matchDatasources`](https://docs.renovatebot.com/configuration-options/#matchdatasources) | Match | The datasource, for example `nuget` | 06, app |
| [`matchDepTypes`](https://docs.renovatebot.com/configuration-options/#matchdeptypes) | Match | The dependency type, for example `devDependencies` | 02, app |
| [`matchPackageNames`](https://docs.renovatebot.com/configuration-options/#matchpackagenames) | Match | Exact names, glob patterns such as `@angular/**`, or regular expressions | 02, 06, 08, app |
| [`matchUpdateTypes`](https://docs.renovatebot.com/configuration-options/#matchupdatetypes) | Match | `major`, `minor`, `patch`, `replacement` and other update types | 01, 02, 03, 04, 06, app |
| [`matchCurrentVersion`](https://docs.renovatebot.com/configuration-options/#matchcurrentversion) | Match | The current version. `'!/^0/'` excludes current versions that start with 0 | 03, app |
| [`matchFileNames`](https://docs.renovatebot.com/configuration-options/#matchfilenames) | Match | The path of the dependency file, as a glob pattern such as `features/03-automerge/**` | The root `renovate.json5` only |
| [`addLabels`](https://docs.renovatebot.com/configuration-options/#addlabels) | Apply | Adds labels to the labels of `labels`. Features 07 and 08 also use it in `vulnerabilityAlerts` and `rollback` | 01, 06, 07, 08, 09.1, app, infrastructure |
| [`groupName`](https://docs.renovatebot.com/configuration-options/#groupname) | Apply | Puts the matched updates in one branch and one PR | 02, 04, app |
| [`automerge`](https://docs.renovatebot.com/configuration-options/#automerge) | Apply | Default `false`. Merges the PR after all checks pass | 03, app |
| [`automergeType`](https://docs.renovatebot.com/configuration-options/#automergetype) | Apply | Default `'pr'`. `'branch'` merges without a PR | 03 |
| [`platformAutomerge`](https://docs.renovatebot.com/configuration-options/#platformautomerge) | Apply | Default `true`. GitHub merges the PR, not the next Renovate run | 03. The root `renovate.json5` sets `false` |
| [`ignoreTests`](https://docs.renovatebot.com/configuration-options/#ignoretests) | Apply | Default `false`. `true` merges without passing checks | 03 |
| [`dependencyDashboardApproval`](https://docs.renovatebot.com/configuration-options/#dependencydashboardapproval) | Apply | Default `false`. A person must select the update in the dashboard first | 03, 04, app |
| [`replacementName`](https://docs.renovatebot.com/configuration-options/#replacementname) | Apply | The new package name | 06, app |
| [`replacementVersion`](https://docs.renovatebot.com/configuration-options/#replacementversion) | Apply | The version of the new package | 06, app |
| [`rollbackPrs`](https://docs.renovatebot.com/configuration-options/#rollbackprs) | Apply | Default `false`. Allows rollback PRs | 08, app |

## Options in a custom regex manager

| Option | What it does |
|---|---|
| [`customType`](https://docs.renovatebot.com/configuration-options/#customtype) | `'regex'` for a manager with regular expressions |
| [`managerFilePatterns`](https://docs.renovatebot.com/configuration-options/#managerfilepatterns) | The files that the manager reads. There is no default |
| [`matchStrings`](https://docs.renovatebot.com/configuration-options/#matchstrings) | The regular expressions. The named groups give the fields of the dependency |

A match must have three fields to give a dependency. The fields are a package name (`depName` or `packageName`), a version (`currentValue` or `currentDigest`) and a `datasource`. A named group or a template can give each field. If you do not set `versioning`, Renovate uses `semver-coerced`. [Part 4 of feature 09](../features/09-helm-and-infrastructure/04-custom-regex-manager/README.md) explains each named group.

## Complete configurations

| File | Contents |
|---|---|
| [`configs/renovate.app.json5`](../configs/renovate.app.json5) | Features 01 to 08 for a repository with .NET and Node.js |
| [`configs/renovate.infrastructure.json5`](../configs/renovate.infrastructure.json5) | The five parts of feature 09 for a repository with Helm and Kubernetes files |
