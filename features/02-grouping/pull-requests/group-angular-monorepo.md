# Update angular monorepo to v19.1.1

> [!NOTE]
> Illustrative pull request. The title, the branch name and the body format are what Renovate produces for this group. The release notes are the real notes from the angular repository. The repository, the PR number and the check results are fictional.

| Field | Value |
|---|---|
| Repository | `contoso/contoso-web` (fictional) |
| Pull request | #414, opened by `renovate[bot]` on 2025-01-17 |
| Branch | `renovate/angular-monorepo` into `main` |
| Labels | `dependencies` |
| Update type | patch (19.1.0 to 19.1.1), 8 packages |
| Checks | build: passed, lint: passed, test: passed |
| Configuration | [`../renovate.json5`](../renovate.json5) |

## Description

The text between the two lines is the PR body that Renovate writes.

---

This PR contains the following updates:

| Package | Change | [Age](https://docs.renovatebot.com/merge-confidence/) | [Confidence](https://docs.renovatebot.com/merge-confidence/) |
|---|---|---|---|
| [@angular/animations](https://github.com/angular/angular/tree/main/packages/animations) ([source](https://github.com/angular/angular/tree/HEAD/packages/animations)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2fanimations/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2fanimations/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2fanimations/19.1.0/19.1.1?slim=true) |
| [@angular/common](https://github.com/angular/angular/tree/main/packages/common) ([source](https://github.com/angular/angular/tree/HEAD/packages/common)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2fcommon/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2fcommon/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2fcommon/19.1.0/19.1.1?slim=true) |
| [@angular/compiler](https://github.com/angular/angular/tree/main/packages/compiler) ([source](https://github.com/angular/angular/tree/HEAD/packages/compiler)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2fcompiler/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2fcompiler/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2fcompiler/19.1.0/19.1.1?slim=true) |
| [@angular/compiler-cli](https://github.com/angular/angular/tree/main/packages/compiler-cli) ([source](https://github.com/angular/angular/tree/HEAD/packages/compiler-cli)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2fcompiler-cli/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2fcompiler-cli/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2fcompiler-cli/19.1.0/19.1.1?slim=true) |
| [@angular/core](https://github.com/angular/angular/tree/main/packages/core) ([source](https://github.com/angular/angular/tree/HEAD/packages/core)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2fcore/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2fcore/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2fcore/19.1.0/19.1.1?slim=true) |
| [@angular/forms](https://github.com/angular/angular/tree/main/packages/forms) ([source](https://github.com/angular/angular/tree/HEAD/packages/forms)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2fforms/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2fforms/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2fforms/19.1.0/19.1.1?slim=true) |
| [@angular/platform-browser](https://github.com/angular/angular/tree/main/packages/platform-browser) ([source](https://github.com/angular/angular/tree/HEAD/packages/platform-browser)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2fplatform-browser/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2fplatform-browser/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2fplatform-browser/19.1.0/19.1.1?slim=true) |
| [@angular/router](https://github.com/angular/angular/tree/main/packages/router) ([source](https://github.com/angular/angular/tree/HEAD/packages/router)) | [`19.1.0` → `19.1.1`](https://renovatebot.com/diffs/npm/@angular%2frouter/19.1.0/19.1.1) | ![age](https://developer.mend.io/api/mc/badges/age/npm/@angular%2frouter/19.1.1?slim=true) | ![confidence](https://developer.mend.io/api/mc/badges/confidence/npm/@angular%2frouter/19.1.0/19.1.1?slim=true) |

---

### Release Notes

<details>
<summary>angular/angular (@&#8203;angular/animations)</summary>

### [`v19.1.1`](https://github.com/angular/angular/releases/tag/19.1.1)

[Compare Source](https://github.com/angular/angular/compare/19.1.0...19.1.1)

##### core

| Commit | Description |
| -- | -- |
| [![fix - 357795cb96](https://img.shields.io/badge/357795cb96-fix-green)](https://github.com/angular/angular/commit/357795cb96a1cd138ec263c468c9de8ca8b2af9c) | run HMR replacement in the zone ([#&#8203;59562](https://github.com/angular/angular/issues/59562)) |

##### platform-browser

| Commit | Description |
| -- | -- |
| [![fix - eb0b1851f4](https://img.shields.io/badge/eb0b1851f4-fix-green)](https://github.com/angular/angular/commit/eb0b1851f494adfe72f583763a44bd2528a5956c) | roll back HMR fix ([#&#8203;59557](https://github.com/angular/angular/issues/59557)) |

</details>

---

### Configuration

📅 **Schedule**: (UTC)

- Branch creation
  - At any time (no schedule defined)
- Automerge
  - At any time (no schedule defined)

🚦 **Automerge**: Disabled by config. Please merge this manually once you are satisfied.

♻ **Rebasing**: Whenever PR becomes conflicted, or you tick the rebase/retry checkbox.

🔕 **Ignore**: Close this PR and you won't be reminded about these updates again.

---

 - [ ] <!-- rebase-check -->If you want to rebase/retry this PR, check this box

---

This PR has been generated by [Mend Renovate CLI](https://github.com/renovatebot/renovate).

---

## Files changed (2)

```diff
--- a/package.json
+++ b/package.json
@@ -12,19 +12,19 @@
   },
   "dependencies": {
-    "@angular/animations": "19.1.0",
-    "@angular/common": "19.1.0",
-    "@angular/compiler": "19.1.0",
-    "@angular/core": "19.1.0",
-    "@angular/forms": "19.1.0",
-    "@angular/platform-browser": "19.1.0",
-    "@angular/router": "19.1.0",
+    "@angular/animations": "19.1.1",
+    "@angular/common": "19.1.1",
+    "@angular/compiler": "19.1.1",
+    "@angular/core": "19.1.1",
+    "@angular/forms": "19.1.1",
+    "@angular/platform-browser": "19.1.1",
+    "@angular/router": "19.1.1",
     "axios": "1.7.9",
     "rxjs": "7.8.1",
     "tslib": "2.8.1",
     "zone.js": "0.15.0"
   },
   "devDependencies": {
     "@angular/build": "19.1.0",
     "@angular/cli": "19.1.0",
-    "@angular/compiler-cli": "19.1.0",
+    "@angular/compiler-cli": "19.1.1",
     "eslint": "8.57.1",
```

```diff
--- a/package-lock.json
+++ b/package-lock.json
@@ (shortened in this example, 1 of 8 packages shown)
     "node_modules/@angular/core": {
-      "version": "19.1.0",
-      "resolved": "https://registry.npmjs.org/@angular/core/-/core-19.1.0.tgz",
+      "version": "19.1.1",
+      "resolved": "https://registry.npmjs.org/@angular/core/-/core-19.1.1.tgz",
       "license": "MIT",
```

## What happened and why

The eight `@angular/*` packages have the same source repository, `angular/angular`. The `angular monorepo` rule in `group:monorepos` matches that repository, so Renovate puts the eight packages in one branch. Angular checks at runtime that its packages have the same version. With one PR per package, the versions in each PR do not match, and the build fails.

`@angular/compiler-cli` is a dev dependency, but it is in the group too. A monorepo group matches on the source repository and not on the dependency type.

`@angular/build` and `@angular/cli` stay on 19.1.0 in this PR. They come from a different repository, `angular/angular-cli`. The `angular-cli monorepo` rule puts them in a second PR, "Update angular-cli monorepo to v19.1.1".

The release notes show one block for eight packages. The block summary names the first package, `@angular/animations`. Renovate writes `@&#8203;` (an invisible space after the `@`) in release notes so that GitHub does not notify a user with that name.
