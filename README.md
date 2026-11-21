# Renovate talk examples

This repository holds the examples for a talk.

The talk is about [Renovate](https://docs.renovatebot.com/). Renovate is a bot that finds outdated dependencies and opens pull requests (PRs) that update them. Each feature has a commented configuration, example files and example PRs with an explanation.

The example PRs under `features/` are Markdown files, not real PRs. Renovate also runs on this repository every hour and opens real PRs for the files under `features/*/example-files/`. The section [Renovate in this repository](#renovate-in-this-repository) explains the setup.

## Features

| # | Feature | Example PRs |
|---|---|---|
| 01 | [Basic updates](features/01-basic-updates/README.md) | [patch](features/01-basic-updates/pull-requests/patch-serilog-aspnetcore.md), [minor](features/01-basic-updates/pull-requests/minor-prettier.md), [major](features/01-basic-updates/pull-requests/major-eslint.md) |
| 02 | [Grouping](features/02-grouping/README.md) | [Angular](features/02-grouping/pull-requests/group-angular-monorepo.md), [.NET](features/02-grouping/pull-requests/group-dotnet-monorepo.md), [own group](features/02-grouping/pull-requests/group-npm-dev-tooling.md) |
| 03 | [Automerge](features/03-automerge/README.md) | [merged](features/03-automerge/pull-requests/automerge-typescript-patch.md), [blocked by a check](features/03-automerge/pull-requests/automerge-blocked-by-failing-check.md), [major after approval](features/03-automerge/pull-requests/major-after-approval-serilog.md) |
| 04 | [Dependency Dashboard](features/04-dependency-dashboard/README.md) | [the issue](features/04-dependency-dashboard/dependency-dashboard-issue.md) |
| 05 | [Lock file maintenance](features/05-lock-file-maintenance/README.md) | [lock file maintenance](features/05-lock-file-maintenance/pull-requests/lock-file-maintenance.md) |
| 06 | [Replacement PRs](features/06-replacement-prs/README.md) | [npm](features/06-replacement-prs/pull-requests/replace-babel-eslint.md), [NuGet](features/06-replacement-prs/pull-requests/replace-mvc-versioning.md), [dashboard section](features/06-replacement-prs/dependency-dashboard-deprecations.md) |
| 07 | [Vulnerability alerts](features/07-vulnerability-alerts/README.md) | [security PR](features/07-vulnerability-alerts/pull-requests/security-system-text-json.md) |
| 08 | [Rollback PRs](features/08-rollback-prs/README.md) | [rollback PR](features/08-rollback-prs/pull-requests/rollback-contoso-ui-components.md) |
| 09 | [Helm and infrastructure](features/09-helm-and-infrastructure/README.md) | [Chart.yaml](features/09-helm-and-infrastructure/01-helm-chart-dependencies/pull-requests/helm-argo-cd.md), [OCI chart](features/09-helm-and-infrastructure/02-helm-oci-internal-chart/pull-requests/helm-contoso-service.md), [values.yaml](features/09-helm-and-infrastructure/03-helm-values-images/pull-requests/image-orders-api.md), [regex manager](features/09-helm-and-infrastructure/04-custom-regex-manager/pull-requests/tool-helm.md), [Kubernetes](features/09-helm-and-infrastructure/05-kubernetes-manifests/pull-requests/image-redis.md) |

## More pages

- [Feature overview](docs/feature-overview.md): all features and all example PRs in tables.
- [Configuration reference](docs/configuration-reference.md): every option that the configurations use, with its default.
- [`configs/renovate.app.json5`](configs/renovate.app.json5): a complete configuration for features 01 to 08, for a repository with .NET and Node.js.
- [`configs/renovate.infrastructure.json5`](configs/renovate.infrastructure.json5): a complete configuration for feature 09, for a repository with Helm and Kubernetes files.

## The folder of a feature

The folders under `features/` use these names:

| File or folder | Contents |
|---|---|
| `README.md` | What the feature does, how to turn it on, and what is real in the example |
| `renovate.json5` | The configuration for this feature only, with comments |
| `example-files/` | The dependency files before the PR, for example `package.json` or `Chart.yaml` |
| `pull-requests/` | The example PRs: title, labels, branch, PR body, changed files and an explanation |

Feature 03 has no `example-files/`, because its PRs change the files of feature 01. Feature 04 has an example issue instead of example PRs. Feature 09 has five parts, and each part is a subfolder with the same files.

## Real behavior and illustration

Each example PR starts with a note that says which parts are real and which parts are illustration.

These parts are real:

- Every configuration passed the validator of Renovate 44.247.1 in strict mode.
- The PR titles, branch names, labels and the format of the PR body are what Renovate produces for the configuration. The source code of Renovate 44 is the reference.
- The public package names, versions and release dates come from the public registries and from GitHub. The examples use 2025-01-17 as "today".
- Release notes are the real text of the release. A note in the PR tells you where the text is shortened.

These parts are illustration:

- The repositories under `contoso/`, the packages under `@contoso/` and the images in `contoso.azurecr.io` are fictional.
- PR numbers, commit hashes, check names and check results are fictional.
- The links to GitHub. On github.com, Renovate changes each link to `github.com` in the PR body to `redirect.github.com`. The redirect stops GitHub from adding a reference on the linked issue or PR. The examples show `github.com`, because those links are easier to read.

## Renovate in this repository

A GitHub Actions workflow runs Renovate on this repository. These files control the run:

| File | Contents |
|---|---|
| [`.github/workflows/renovate.yml`](.github/workflows/renovate.yml) | Runs Renovate 44.247.1 at minute 0 of every hour. The "Run workflow" button on the Actions tab starts a run at once. |
| [`renovate.json`](renovate.json) | Turns on the Dependency Dashboard issue and removes the limit of 2 new PRs per hour. At most 10 Renovate PRs are open at the same time. |

The workflow reads the token from the repository secret `RENOVATE_TOKEN`. The token is a fine-grained personal access token (PAT) with access to this repository only. It has these permissions:

- Read and write: Commit statuses, Contents, Issues, Pull requests and Workflows.
- Read-only: Dependabot alerts.

The real PRs are not the same as the example PRs. The files under `example-files/` have the versions from 2025-01-17, so a real PR updates to the newest version on the day of the run.

There is no Docker setup in this repository. To run Renovate in another way, read [Renovate docs: getting started](https://docs.renovatebot.com/getting-started/running/).
