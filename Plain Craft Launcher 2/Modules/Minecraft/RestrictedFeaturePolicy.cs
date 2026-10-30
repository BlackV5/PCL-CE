using PCL.Core.App.Region;
using PCL.Core.App.Localization;
using PCL.Core.UI;

namespace PCL;

internal static class RestrictedFeaturePolicy
{
    internal static RegionAssessment Assess() => RegionPolicy.Evaluate(RegionPolicy.ReadWindowsSignals());

    // 始终返回 false，表示永不限制
    internal static bool IsRestricted => false;

    internal static bool Check(string feature, bool showHint = true)
    {
        // 始终放行，不记录日志、不弹提示
        return true;
    }

    internal static void ThrowIfRestricted(string feature)
    {
        if (Check(feature, false)) return;
        throw new ModBase.CancelledException();
    }
}
