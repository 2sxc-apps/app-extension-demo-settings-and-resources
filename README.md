# Demo: Extension Settings and Resources

This 2sxc demo extension shows how an extension can ship preset settings and
resources while allowing each installation to override only selected values.

The extension contains:

- five strongly typed settings with preset values
- five strongly typed resources with preset values
- exported content-type definitions and initial data
- a helper which stacks installation-specific values over the presets
- a Razor view which reads every setting and resource explicitly

## Structure

- `extensions/demo-settings-and-resources/` contains the extension manifest,
  Razor view, and exported data bundle.
- `AppCode/Extensions/DemoSettingsAndResources/` contains the generated models
  and the settings/resources helper service.

The exported manifest is a source extension (`isInstalled: false`). The
installation-specific `package-index.json` is intentionally not part of this
repository.

## Test

Import or install the extension in another 2sxc app and add the exported
**Demo Settings and Resources** view to a page. It should first show all preset
values. Then create installation-specific settings and resources and override
only one or two fields; all remaining fields should continue to fall back to
the extension presets.

