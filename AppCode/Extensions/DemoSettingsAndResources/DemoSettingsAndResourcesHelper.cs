using System;
using System.Linq;
using Custom.Hybrid;

namespace AppCode.Extensions.DemoSettingsAndResources
{
  /// <summary>
  /// Provides the effective settings and resources for the extension.
  /// The first stream item contains the extension presets; when an installation
  /// adds a customized item, its values are stacked over those presets.
  /// </summary>
  public class DemoSettingsAndResourcesHelper : CodeTyped
  {
    public DemoSettingsAndResourcesSettings GetSettings()
    {
      if (_settings != null)
        return _settings;

      var settings = App.Data
        .GetStream(nameof(DemoSettingsAndResourcesSettings))
        .ToList();

      switch (settings.Count)
      {
        case 0:
          throw new Exception(
            "Demo Settings and Resources settings definition is missing.");
        case 1:
          return _settings = As<DemoSettingsAndResourcesSettings>(settings[0]);
        default:
          var customizedSettings = settings.Last();
          return _settings = AsStack<DemoSettingsAndResourcesSettings>(
            customizedSettings,
            settings[0]
          );
      }
    }
    private DemoSettingsAndResourcesSettings _settings;

    public DemoSettingsAndResourcesResources GetResources()
    {
      if (_resources != null)
        return _resources;

      var resources = App.Data
        .GetStream(nameof(DemoSettingsAndResourcesResources))
        .ToList();

      switch (resources.Count)
      {
        case 0:
          throw new Exception(
            "Demo Settings and Resources resources definition is missing.");
        case 1:
          return _resources = As<DemoSettingsAndResourcesResources>(resources[0]);
        default:
          var customizedResources = resources.Last();
          return _resources = AsStack<DemoSettingsAndResourcesResources>(
            customizedResources,
            resources[0]
          );
      }
    }
    private DemoSettingsAndResourcesResources _resources;
  }
}
