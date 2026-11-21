# Feature overview

This page compares the nine features on one page. Each row links to the page of the feature. The column "On with `config:recommended`" tells you whether you get the feature without extra configuration.

| # | Feature | What Renovate does | Main option | On with `config:recommended` | Ecosystems in the examples |
|---|---|---|---|---|---|
| 01 | [Basic updates](../features/01-basic-updates/README.md) | Opens one PR per update. Major updates get their own PR | `separateMajorMinor` | Yes | npm, NuGet |
| 02 | [Grouping](../features/02-grouping/README.md) | Puts several updates in one PR | `groupName` | Yes, for known monorepos (`group:monorepos`) | npm, NuGet |
| 03 | [Automerge](../features/03-automerge/README.md) | Merges a PR after all checks pass | `automerge` | No | npm, NuGet |
| 04 | [Dependency Dashboard](../features/04-dependency-dashboard/README.md) | Keeps one issue with all updates and a checkbox for each | `dependencyDashboard` | Yes (`:dependencyDashboard`) | npm, NuGet |
| 05 | [Lock file maintenance](../features/05-lock-file-maintenance/README.md) | Creates the lock file again, so that transitive dependencies update | `lockFileMaintenance` | No | npm |
| 06 | [Replacement PRs](../features/06-replacement-prs/README.md) | Changes the name of a dependency, not only the version | `replacementName` | Yes, for known renames (`replacements:all`) | npm, NuGet |
| 07 | [Vulnerability alerts](../features/07-vulnerability-alerts/README.md) | Opens a security PR at once, outside the schedule | `vulnerabilityAlerts` | Yes. GitHub must give Renovate the Dependabot alerts | NuGet |
| 08 | [Rollback PRs](../features/08-rollback-prs/README.md) | If the version is gone from the registry, moves the dependency to a lower version | `rollbackPrs` | No | npm |
| 09 | [Helm and infrastructure](../features/09-helm-and-infrastructure/README.md) | Updates charts, images and tool versions in deploy files | `managerFilePatterns`, `customManagers` | Partly. See the table below | Helm, Docker, Kubernetes, GitHub releases |

## The five parts of feature 09

| Part | Manager | Built-in or custom | Works without configuration |
|---|---|---|---|
| [1. Helm chart dependencies](../features/09-helm-and-infrastructure/01-helm-chart-dependencies/README.md) | `helmv3` | Built-in | Yes |
| [2. A Helm chart in an OCI registry](../features/09-helm-and-infrastructure/02-helm-oci-chart/README.md) | `helmv3` | Built-in | Yes, for a public registry. A private registry needs a host rule |
| [3. Images in values.yaml](../features/09-helm-and-infrastructure/03-helm-values-images/README.md) | `helm-values` | Built-in | Yes, for a public registry. A private registry needs a host rule |
| [4. Custom regex manager](../features/09-helm-and-infrastructure/04-custom-regex-manager/README.md) | `regex` | Custom | No. You write the manager |
| [5. Kubernetes manifests](../features/09-helm-and-infrastructure/05-kubernetes-manifests/README.md) | `kubernetes` | Built-in | No. You set `managerFilePatterns` |

## All example PRs

Each example is a Markdown file, not a real PR. The labels column shows the labels that the configuration of the feature gives the PR.

| Feature | Example | Labels |
|---|---|---|
| 01 | [Update dependency Serilog.AspNetCore to v8.0.3](../features/01-basic-updates/pull-requests/patch-serilog-aspnetcore.md) | `dependencies` `nuget` |
| 01 | [Update dependency prettier to v3.4.2](../features/01-basic-updates/pull-requests/minor-prettier.md) | `dependencies` `npm` |
| 01 | [Update dependency eslint to v9](../features/01-basic-updates/pull-requests/major-eslint.md) | `dependencies` `npm` `major` |
| 02 | [Update angular monorepo to v19.1.1](../features/02-grouping/pull-requests/group-angular-monorepo.md) | `dependencies` |
| 02 | [Update dotnet monorepo to v9.0.1](../features/02-grouping/pull-requests/group-dotnet-monorepo.md) | `dependencies` |
| 02 | [Update npm dev tooling](../features/02-grouping/pull-requests/group-npm-dev-tooling.md) | `dependencies` |
| 03 | [Update dependency typescript to v5.7.3](../features/03-automerge/pull-requests/automerge-typescript-patch.md) | `dependencies` |
| 03 | [Update dotnet monorepo to v9.0.1 (automerge blocked)](../features/03-automerge/pull-requests/automerge-blocked-by-failing-check.md) | `dependencies` |
| 03 | [Update dependency Serilog.AspNetCore to v9](../features/03-automerge/pull-requests/major-after-approval-serilog.md) | `dependencies` |
| 04 | [Dependency Dashboard (issue)](../features/04-dependency-dashboard/dependency-dashboard-issue.md) | None |
| 05 | [Lock file maintenance](../features/05-lock-file-maintenance/pull-requests/lock-file-maintenance.md) | `dependencies` |
| 06 | [Replace dependency babel-eslint with @babel/eslint-parser v7.11.0](../features/06-replacement-prs/pull-requests/replace-babel-eslint.md) | `dependencies` `replacement` |
| 06 | [Replace dependency Microsoft.AspNetCore.Mvc.Versioning with Asp.Versioning.Mvc v8.1.0](../features/06-replacement-prs/pull-requests/replace-mvc-versioning.md) | `dependencies` `replacement` |
| 06 | [Dependency Dashboard: Deprecations / Replacements (issue section)](../features/06-replacement-prs/dependency-dashboard-deprecations.md) | None |
| 07 | [Update dependency System.Text.Json to v8.0.5 [SECURITY]](../features/07-vulnerability-alerts/pull-requests/security-system-text-json.md) | `dependencies` `security` |
| 08 | [Roll back dependency rc to v1.2.8](../features/08-rollback-prs/pull-requests/rollback-rc.md) | `dependencies` `rollback` |
| 09.1 | [Update Helm release argo-cd to v7.7.16](../features/09-helm-and-infrastructure/01-helm-chart-dependencies/pull-requests/helm-argo-cd.md) | `dependencies` `helm` |
| 09.2 | [Update podinfo Docker tag to v6.7.1](../features/09-helm-and-infrastructure/02-helm-oci-chart/pull-requests/helm-podinfo.md) | `dependencies` |
| 09.3 | [Update ghcr.io/stefanprodan/podinfo Docker tag to v6.7.1](../features/09-helm-and-infrastructure/03-helm-values-images/pull-requests/image-podinfo.md) | `dependencies` |
| 09.4 | [Update dependency helm/helm to v3.17.0](../features/09-helm-and-infrastructure/04-custom-regex-manager/pull-requests/tool-helm.md) | `dependencies` |
| 09.5 | [Update redis Docker tag to v7.4.2](../features/09-helm-and-infrastructure/05-kubernetes-manifests/pull-requests/image-redis.md) | `dependencies` |

The `helm` label in part 1 comes from a package rule for the `helmv3` manager. Part 2 uses the same manager, but its example configuration has no such rule. The combined file [`configs/renovate.infrastructure.json5`](../configs/renovate.infrastructure.json5) has the rule, so there the PR of part 2 also gets `helm`.
