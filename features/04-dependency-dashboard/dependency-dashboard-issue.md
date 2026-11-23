# Dependency Dashboard

> [!NOTE]
> Illustrative issue. The section titles, the section texts, the checkbox format and the "Detected Dependencies" format are what Renovate 44 writes. The issue number, the PR numbers and the developer actions are fictional. The dependencies are the real versions on 2025-01-17. Renovate writes the PR links as relative links, for example `../pull/415`. These links open the PR in a real issue, but not in this repository.

| Field | Value |
|---|---|
| Repository | `Susling/renovate-talk-examples` |
| Issue | #388, opened by `renovate[bot]`, pinned |
| Labels | None. The option `dependencyDashboard.labels` is not set |
| Updated | 2025-01-17, 08:02 UTC, in each Renovate run |
| Configuration | [`renovate.json5`](renovate.json5) |
| Dependency file | [`package.json`](../02-grouping/example-files/package.json) from feature 02 |

## The issue body

The text between the two lines is the issue body that Renovate writes. On GitHub, the `<!-- ... -->` comments are not visible. Renovate uses them to find the branch for each checkbox.

---

This issue lists Renovate updates and detected dependencies. Read the [Dependency Dashboard](https://docs.renovatebot.com/key-concepts/dashboard/) docs to learn more.

## Pending Approval

The following branches are pending approval. To create them, click on a checkbox below.

 - [ ] <!-- approve-branch=renovate/major-eslint-monorepo -->Update dependency eslint to v9

## Awaiting Schedule

The following updates are awaiting their schedule. To get an update now, click on a checkbox below.

 - [ ] <!-- unschedule-branch=renovate/lock-file-maintenance -->Lock file maintenance

## PR Edited (Blocked)

The following updates have been manually edited so Renovate will no longer make changes. To discard all commits and start over, click on a checkbox below.

 - [ ] <!-- rebase-branch=renovate/npm-dev-tooling -->[Update npm dev tooling](../pull/415) (`husky`, `lint-staged`, `prettier`)

## Open

The following updates have all been created. To force a retry/rebase of any, click on a checkbox below.

 - [ ] <!-- rebase-branch=renovate/angular-monorepo -->[Update angular monorepo to v19.1.1](../pull/414) (`@angular/animations`, `@angular/common`, `@angular/compiler`, `@angular/compiler-cli`, `@angular/core`, `@angular/forms`, `@angular/platform-browser`, `@angular/router`)
 - [ ] <!-- rebase-branch=renovate/angular-cli-monorepo -->[Update angular-cli monorepo to v19.1.1](../pull/417) (`@angular/build`, `@angular/cli`)
 - [ ] <!-- rebase-branch=renovate/typescript-5.x -->[Update dependency typescript to v5.7.3](../pull/416)
 - [ ] <!-- rebase-all-open-prs -->**Click on this checkbox to rebase all open PRs at once**

## Detected Dependencies

<details><summary>npm (1)</summary>
<blockquote>

<details><summary>package.json (19)</summary>

 - `@angular/animations 19.1.0` → [Updates: `19.1.1`]
 - `@angular/common 19.1.0` → [Updates: `19.1.1`]
 - `@angular/compiler 19.1.0` → [Updates: `19.1.1`]
 - `@angular/core 19.1.0` → [Updates: `19.1.1`]
 - `@angular/forms 19.1.0` → [Updates: `19.1.1`]
 - `@angular/platform-browser 19.1.0` → [Updates: `19.1.1`]
 - `@angular/router 19.1.0` → [Updates: `19.1.1`]
 - `axios 1.7.9`
 - `rxjs 7.8.1`
 - `tslib 2.8.1`
 - `zone.js 0.15.0`
 - `@angular/build 19.1.0` → [Updates: `19.1.1`]
 - `@angular/cli 19.1.0` → [Updates: `19.1.1`]
 - `@angular/compiler-cli 19.1.0` → [Updates: `19.1.1`]
 - `eslint 8.57.1` → [Updates: `9.18.0`]
 - `husky 9.1.6` → [Updates: `9.1.7`]
 - `lint-staged 15.2.10` → [Updates: `15.4.1`]
 - `prettier 3.3.3` → [Updates: `3.4.2`]
 - `typescript 5.7.2` → [Updates: `5.7.3`]

</details>

</blockquote>
</details>

---

## What each section means

| Section | State of the update | Checkbox type | Effect of the checkbox |
|---|---|---|---|
| Pending Approval | A rule with `dependencyDashboardApproval: true` matches. No branch exists | `approve` | Renovate creates the branch and the PR |
| Awaiting Schedule | The update is outside its `schedule`. Here, lock file maintenance runs only before 4am on Monday | `unschedule` | Renovate creates the branch now, outside the schedule |
| PR Edited (Blocked) | A person pushed a commit to the Renovate branch. Renovate no longer pushes to it | `rebase` | Renovate deletes the extra commits and creates the branch again |
| Open | The PR exists, and Renovate keeps it up to date | `rebase` | Renovate rebases the branch on `main` |

## Why each update is in its section

| Update | Section | Reason |
|---|---|---|
| `eslint` 8.57.1 to 9.18.0 | Pending Approval | The update is major, so the approval rule matches |
| Lock file maintenance | Awaiting Schedule | 2025-01-17 is a Friday. The schedule is `before 4am on monday` |
| `npm dev tooling` (#415) | PR Edited (Blocked) | Prettier 3.4 formats some files in a new way. A developer ran `npm run format` and pushed the result to `renovate/npm-dev-tooling` |
| `angular monorepo` (#414), `angular-cli monorepo` (#417), `typescript` (#416) | Open | Patch updates with no rule that stops them |

The "Detected Dependencies" section lists all 19 dependencies in `package.json`, also the 4 dependencies without updates. Each `→ [Updates: ...]` shows the newest version that Renovate found. The list shows the dependencies in the order of the file: first `dependencies`, then `devDependencies`.

## After a person approves the major update

At 09:30 UTC, a developer selects the checkbox for eslint. GitHub saves the issue body with `[x]`. In the next run, Renovate reads the selected checkbox, creates the branch `renovate/major-eslint-monorepo` and opens PR #418. Then it writes the issue body again. This diff shows the change in the body:

```diff
 This issue lists Renovate updates and detected dependencies. Read the [Dependency Dashboard](https://docs.renovatebot.com/key-concepts/dashboard/) docs to learn more.
 
-## Pending Approval
-
-The following branches are pending approval. To create them, click on a checkbox below.
-
- - [x] <!-- approve-branch=renovate/major-eslint-monorepo -->Update dependency eslint to v9
-
 ## Awaiting Schedule
@@ (unchanged sections)
  - [ ] <!-- rebase-branch=renovate/angular-cli-monorepo -->[Update angular-cli monorepo to v19.1.1](../pull/417) (`@angular/build`, `@angular/cli`)
  - [ ] <!-- rebase-branch=renovate/typescript-5.x -->[Update dependency typescript to v5.7.3](../pull/416)
+ - [ ] <!-- rebase-branch=renovate/major-eslint-monorepo -->[Update dependency eslint to v9](../pull/418)
  - [ ] <!-- rebase-all-open-prs -->**Click on this checkbox to rebase all open PRs at once**
```

The section "Pending Approval" is gone, because it has no more items. The eslint PR is now in "Open", after the patch updates. Renovate sorts the branches by update type: first patch, then minor, then major. Feature 03 shows a PR that Renovate opened after an approval: [`major-after-approval-serilog.md`](../03-automerge/pull-requests/major-after-approval-serilog.md).

## What blocks an update

Two sections show an update that Renovate does not change any more:

| Section | Cause | How to start again |
|---|---|---|
| PR Edited (Blocked) | Somebody other than Renovate pushed a commit to the branch | Merge the PR, or select the checkbox. The checkbox deletes the extra commits |
| PR Closed (Blocked) | Somebody closed the PR without a merge | Select the checkbox. Renovate opens the PR again |

This issue does not show "PR Closed (Blocked)", because no PR is closed. If a person closes #416 without a merge, the next run moves it to that section:

```markdown
## PR Closed (Blocked)

The following updates are blocked by an existing closed PR. To recreate the PR, click on a checkbox below.

 - [ ] <!-- recreate-branch=renovate/typescript-5.x -->[Update dependency typescript to v5.7.3](../pull/416)
```

For a closed major update, Renovate ignores that major version from then on. For a closed minor or patch update, Renovate ignores only that version. A newer version gets a new PR.
