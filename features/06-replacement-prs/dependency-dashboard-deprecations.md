# Dependency Dashboard: Deprecations / Replacements

> [!NOTE]
> Illustrative issue sections. The section title, the warning text, the table format and the badges are what Renovate 44 writes. The source file is `lib/workers/repository/dependency-dashboard.ts`. The repositories are fictional. The package data comes from the npm registry and nuget.org.

[Feature 04](../04-dependency-dashboard/README.md) shows the Dependency Dashboard. Renovate adds the section "Deprecations / Replacements" to it for each dependency that matches one of these conditions:

- The datasource reports the dependency as deprecated.
- A replacement rule matches the dependency.

The section comes near the top of the issue, before "Pending Approval".

## `contoso-legacy-portal`

The text between the two lines is the section that Renovate writes.

---

## Deprecations / Replacements
> ⚠️ **Warning**
> 
> The following dependencies are either deprecated or have replacements available.

| Datasource | Package | Replacement PR? |
|------------|------|--------------|
| npm | [babel-eslint](https://github.com/babel/babel-eslint) | ![Available](https://img.shields.io/badge/available-green?style=flat-square) |

---

`babel-eslint` is deprecated on the npm registry, and the preset `replacements:babel-eslint-to-eslint-parser` matches it. "Available" means that Renovate has a replacement update for the package. The PR is [`pull-requests/replace-babel-eslint.md`](pull-requests/replace-babel-eslint.md).

## `contoso-api`, before and after the package rule

Before the repository added its own package rule, the section looked like this:

---

## Deprecations / Replacements
> ⚠️ **Warning**
> 
> The following dependencies are either deprecated or have replacements available.

| Datasource | Package | Replacement PR? |
|------------|------|--------------|
| nuget | [Microsoft.AspNetCore.Mvc.Versioning](https://github.com/dotnet/aspnet-api-versioning) | ![Unavailable](https://img.shields.io/badge/unavailable-orange?style=flat-square) |

---

All 44 versions of `Microsoft.AspNetCore.Mvc.Versioning` on nuget.org are deprecated, so the nuget datasource reports the package as deprecated. No replacement rule matches, so the badge is "Unavailable". The section tells you that a package needs attention. It does not tell you the new package name.

After the repository added the rule in [`renovate.json5`](renovate.json5), the row changes:

```diff
-| nuget | [Microsoft.AspNetCore.Mvc.Versioning](https://github.com/dotnet/aspnet-api-versioning) | ![Unavailable](https://img.shields.io/badge/unavailable-orange?style=flat-square) |
+| nuget | [Microsoft.AspNetCore.Mvc.Versioning](https://github.com/dotnet/aspnet-api-versioning) | ![Available](https://img.shields.io/badge/available-green?style=flat-square) |
```

The PR is [`pull-requests/replace-mvc-versioning.md`](pull-requests/replace-mvc-versioning.md).

## How to read the table

| Column | Content |
|---|---|
| Datasource | The name of the manager, for example `npm` or `nuget`. The column title says "Datasource", but the value comes from the manager |
| Package | The package name. The link goes to the source repository. Without a known repository, the name has no link |
| Replacement PR? | "Available": a replacement update exists. "Unavailable": the package is deprecated, and no replacement rule matches |

The row stays in the section until the old package is gone from the dependency files. After you merge the replacement PR, the row disappears in the next run.
