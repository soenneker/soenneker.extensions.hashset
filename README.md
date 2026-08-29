[![](https://img.shields.io/nuget/v/Soenneker.Extensions.HashSet.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.HashSet/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.hashset/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.hashset/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.HashSet.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.HashSet/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.hashset/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.hashset/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.HashSet

Adds an efficient `AddRange()` operation to `HashSet<T>`.

## Installation

```bash
dotnet add package Soenneker.Extensions.HashSet
```

## Quick start

```csharp
using Soenneker.Extensions.HashSet;

var ids = new HashSet<int> { 1, 2 };
ids.AddRange([2, 3, 4]);

// ids contains 1, 2, 3, and 4
```

Duplicate values keep normal `HashSet<T>` behavior and are ignored. The method pre-sizes the set when the incoming collection size is known.
