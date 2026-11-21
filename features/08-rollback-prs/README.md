# 08: Rollback PRs

A rollback PR moves a dependency to a lower version. If the version in the repository no longer exists in the registry, Renovate opens a rollback PR. The option `rollbackPrs` is off by default.

| File | What it shows |
|---|---|
| [`renovate.json5`](renovate.json5) | The configuration: `rollbackPrs` for the internal `@contoso` packages only, and a `rollback` label |
| [`example-files/`](example-files/) | `package.json` and `.npmrc` of `contoso-web`, before the PR |
| [`pull-requests/rollback-contoso-ui-components.md`](pull-requests/rollback-contoso-ui-components.md) | npm: `@contoso/ui-components` 2.4.0 to 2.3.2, after 2.4.0 was deleted |

## The scenario

The design system team publishes `@contoso/ui-components` to GitHub Packages. Version 2.4.0 had no compiled styles, so the team deleted it. The `main` branch of `contoso-web` still pinned 2.4.0.

```mermaid
%%{init: {"htmlLabels": false, "flowchart": {"htmlLabels": false, "wrappingWidth": 400}}}%%
flowchart TD
    A["2025-01-13<br/>The team publishes 2.4.0"]
    B["2025-01-14<br/>contoso-web merges PR #409<br/>Update to v2.4.0"]
    C["2025-01-15<br/>The team deletes 2.4.0<br/>from GitHub Packages"]
    D["2025-01-16<br/>npm ci fails with E404<br/>The main branch does not build"]
    E["2025-01-17<br/>Renovate opens PR #421<br/>Roll back to v2.3.2"]
    F["A developer merges PR #421<br/>The main branch builds again"]
    A --> B --> C --> D --> E --> F
```

The registry before and after the deletion:

| Version | 2025-01-14 | 2025-01-17 |
|---|---|---|
| 2.2.0 | Yes | Yes |
| 2.3.0 | Yes | Yes |
| 2.3.1 | Yes | Yes |
| 2.3.2 | Yes | Yes |
| 2.4.0-rc.1 | Yes | Yes |
| 2.4.0 | Yes | ~~2.4.0~~ deleted |
| 3.0.0-beta.1 | Yes | Yes |

## How Renovate picks the version

```mermaid
%%{init: {"htmlLabels": false, "flowchart": {"htmlLabels": false, "wrappingWidth": 400}}}%%
flowchart TD
    A["Renovate reads '2.4.0'<br/>from package.json"]
    B["The npm datasource returns<br/>6 versions"]
    C{"Is rollbackPrs true<br/>for this package?"}
    D["Normal lookup: no version<br/>above 2.4.0, so no PR"]
    E{"Does a version in the<br/>registry match '2.4.0'?"}
    F["Normal lookup"]
    G["Keep the versions below 2.4.0<br/>2.2.0 2.3.0 2.3.1 2.3.2 2.4.0-rc.1"]
    H{"Is the current version<br/>a stable version?"}
    I["Drop the unstable versions<br/>2.4.0-rc.1 goes"]
    J["Take the highest version<br/>2.3.2"]
    K["PR 'Roll back dependency<br/>@contoso/ui-components to v2.3.2'"]
    A --> B --> C
    C -->|No| D
    C -->|Yes| E
    E -->|Yes| F
    E -->|No| G --> H
    H -->|Yes| I --> J
    H -->|No| J
    J --> K
```

Renovate does not pick the version before the last update. It picks the highest version below the missing version. In the example, both are 2.3.2. If the registry also has 2.3.3, Renovate picks 2.3.3.

The PR updates `package.json` and runs `npm install` to update `package-lock.json`. The PR body has no release notes, because Renovate shows release notes only for versions above the current version.

## Configuration

| Option | Default | Effect |
|---|---|---|
| `rollbackPrs` | `false` | If no version in the registry matches the current value, Renovate makes a rollback update |
| `rollback` | see below | The configuration that Renovate applies only to rollback updates. Your values add to the defaults |

The defaults of `rollback` in Renovate 44:

| Field | Default | Result in the example |
|---|---|---|
| `branchTopic` | `{{{depNameSanitized}}}-rollback` | `renovate/contoso-ui-components-rollback` |
| `commitMessageAction` | `Roll back` | `Roll back dependency @contoso/ui-components to v2.3.2` |
| `semanticCommitType` | `fix` | With semantic commits on: `fix(deps): roll back ...` |

The Renovate docs recommend that you turn on `rollbackPrs` in `packageRules` for some packages, not for all packages. A good match is a package from your own registry, where a person can delete a version. The docs also say that you must not use `rollbackPrs` together with `constraintsFiltering: 'strict'`.

Renovate must have read access to the registry. For GitHub Packages, the Renovate installation needs a token with `read:packages` in `hostRules` for `npm.pkg.github.com`.

## When Renovate opens no rollback PR

A rollback PR needs a missing version. Renovate opens no PR in these cases:

1. The broken version is still in the registry. Renovate sees a valid version and has nothing to do.
2. `rollbackPrs` is `false` for the package. Renovate finds no version above 2.4.0 and opens no PR.
3. No version below the current version exists. Renovate writes the warning `Can't find version matching 2.4.0 for npm package @contoso/ui-components` in the log and on the Dependency Dashboard.

On npmjs.org, a package owner can unpublish a version only under strict conditions. A deleted version is therefore more frequent in a private registry.

If a broken version stays in the registry, revert the update with git. Then stop Renovate from proposing that version again:

```json5
{
  packageRules: [
    {
      matchPackageNames: ['@contoso/ui-components'],
      allowedVersions: '!/^2\\.4\\.0$/',
    },
  ],
}
```

## Three kinds of rollback

The word "rollback" means different things in different tools:

| | Renovate rollback PR | Revert in git | Deployment rollback |
|---|---|---|---|
| Example | PR #421 | `git revert` of the merge of PR #409 | `kubectl rollout undo`, `helm rollback` |
| What changes | One dependency in `package.json` and `package-lock.json` | Every file in the reverted commit | The release that runs in the cluster |
| Trigger | The version is missing from the registry | A person, after a failed build or a bug | A person or a tool, after a failed deploy or health check |
| Target version | The highest version below the missing version | The state before the reverted commit | The release before the current release |
| Fixes the build | Yes | Yes | No. The repository still pins 2.4.0 |
| Broken version still in the registry | No PR | Works | Works |

A deployment rollback changes only the cluster. With GitOps tools such as Flux, the next sync applies the repository again. Then a revert in git is the rollback.

## Real behavior and illustration

These parts come from Renovate 44:

- The option `rollbackPrs`, its default and the `rollback` defaults.
- The rules that pick the version.
- The title, the branch name and the table in the PR.
- The note in the PR body, word for word.

The source files are `lib/config/options/index.ts`, `lib/workers/repository/process/lookup/index.ts` and `lib/workers/repository/process/lookup/rollback.ts`. The package `@contoso/ui-components`, its versions, the hashes, the repository, the PR numbers and the npm log are fictional.

## Read more

- [Renovate docs: `rollbackPrs`](https://docs.renovatebot.com/configuration-options/#rollbackprs)
- [Renovate docs: `rollback`](https://docs.renovatebot.com/configuration-options/#rollback)
- [Renovate docs: `allowedVersions`](https://docs.renovatebot.com/configuration-options/#allowedversions)
- [npm docs: unpublish policy](https://docs.npmjs.com/policies/unpublish)
