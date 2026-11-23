# 03: Automerge

Automerge means that Renovate merges an update without a person, after all status checks (CI) pass. In this example, patch updates merge automatically, and major updates need approval first.

| File | What it shows |
|---|---|
| [`renovate.json5`](renovate.json5) | The configuration, with the automerge defaults written out |
| [`example-files/merged/package.json`](example-files/merged/package.json) | The npm package `clsx` 2.1.0. Its patch PR merges automatically |
| [`example-files/blocked/package.json`](example-files/blocked/package.json) | The npm package `dayjs` 1.11.12. Its patch PR does not merge, because a check fails |
| [`pull-requests/automerge-clsx-patch.md`](pull-requests/automerge-clsx-patch.md) | Patch update that merges automatically |
| [`pull-requests/automerge-blocked-by-failing-check.md`](pull-requests/automerge-blocked-by-failing-check.md) | Patch update that does not merge, because a test fails |
| [`pull-requests/major-after-approval-serilog.md`](pull-requests/major-after-approval-serilog.md) | Major update that waits for approval, then gets a normal PR |

The major update for Serilog.AspNetCore changes the file [`WebApi.csproj`](../01-basic-updates/example-files/WebApi.csproj) of feature 01.

## The checks for the example files

The workflow [`.github/workflows/automerge-example.yml`](../../.github/workflows/automerge-example.yml) runs on each PR that changes a file under `example-files/`. It has two jobs:

| Job | Result |
|---|---|
| `test (clsx)` | Passes. Renovate merges the PR for `clsx` |
| `test (dayjs)` | Fails for each version of `dayjs` other than 1.11.12. The PR for `dayjs` stays open |

The failure of `test (dayjs)` is an illustration. The job does not test the code of dayjs. It fails on purpose, so that the repository shows a PR that automerge does not merge.

The two package names are in no other file of this repository and in no group. Thus each update gets its own PR, and the automerge rule changes no PR of another feature.

## What happens to each update type

| Update type | Rule | Result |
|---|---|---|
| patch | `automerge: true` | The PR opens and the checks run. If all checks pass, the PR merges |
| minor | No rule | Normal PR. A person merges it |
| major | `dependencyDashboardApproval: true` | No branch and no PR. A checkbox in the Dependency Dashboard. After approval, a normal PR |

## How the CI checks control automerge

```mermaid
%%{init: {"flowchart": {"htmlLabels": false}} }%%
flowchart TB
    A["Renovate opens the PR<br/>and enables auto-merge"] --> B["CI runs the checks"]
    B --> C{"All required<br/>checks pass?"}
    C -- yes --> D["GitHub merges the PR"]
    C -- no --> E["PR stays open<br/>for a person"]
```

Three options decide how the checks control the merge:

| Option | Default | Effect |
|---|---|---|
| `platformAutomerge` | `true` | Renovate turns on GitHub auto-merge. After the required checks pass, GitHub merges. With `false`, Renovate merges in a later run, after it reads the check results itself |
| `ignoreTests` | `false` | Renovate merges only with green checks. A branch without any checks is not green, so it does not merge. With `true`, Renovate merges without checks |
| `automergeType` | `pr` | `pr` merges a PR. `branch` merges the branch directly into `main` without a PR. If a check fails, Renovate opens a PR |

> [!WARNING]
> Set the CI checks as required checks on `main` before you turn on automerge. GitHub auto-merge waits only for required checks. Without required checks, GitHub can merge before the CI finishes.

## Waiting for a new release to settle

Automerge often goes together with `minimumReleaseAge`, for example `minimumReleaseAge: '3 days'`. Renovate then waits three days after the release date before it creates the branch. A release with a serious bug is often unpublished or replaced in that time. This configuration does not use the option, so that the example PRs match the snapshot date 2025-01-17.

## Real behavior and illustration

The lines `🚦 Automerge: Enabled.` and `Disabled by config` and the dashboard checkbox are what Renovate 44 writes. The check names are the names of the jobs in `automerge-example.yml`. The timelines and the PR numbers are fictional.

The example PRs use the configuration of this folder, with `platformAutomerge: true`. The configuration of this repository, [`renovate.json5`](../../renovate.json5) in the root, is different in two places:

- The automerge rule has `matchFileNames: ['features/03-automerge/**']`. Only the PRs for the files of this feature merge automatically.
- The rule has `platformAutomerge: false`, because GitHub auto-merge is off for this repository. Renovate merges the PR for `clsx` in the first run after the checks pass. Renovate runs once a day.

## Read more

- [Renovate docs: Automerge configuration and troubleshooting](https://docs.renovatebot.com/key-concepts/automerge/)
- [Renovate docs: `platformAutomerge`](https://docs.renovatebot.com/configuration-options/#platformautomerge)
- [Renovate docs: `ignoreTests`](https://docs.renovatebot.com/configuration-options/#ignoretests)
- [Renovate docs: `dependencyDashboardApproval`](https://docs.renovatebot.com/configuration-options/#dependencydashboardapproval)
- [Renovate docs: `minimumReleaseAge`](https://docs.renovatebot.com/configuration-options/#minimumreleaseage)
