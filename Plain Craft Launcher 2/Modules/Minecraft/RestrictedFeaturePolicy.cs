using PCL.Core.App.Region;
using PCL.Core.App.Localization;
using PCL.Core.UI;

namespace PCL;

internal static class RestrictedFeaturePolicy
{
    internal static RegionAssessment Assess() => RegionPolicy.Evaluate(RegionPolicy.ReadWindowsSignals());

    //internal static bool IsRestricted => Assess().IsRestricted;//屏蔽区域检测功能
    // 修改：始终返回 false，表示永不限制
    internal static bool IsRestricted => flase;

    internal static bool Check(string feature, bool showHint = true)
    {
        #if 0 //屏蔽区域检测功能
        var assessment = Assess();
        if (!assessment.IsRestricted) return true;

        ModBase.Log($"[RegionPolicy] 已阻止功能 {feature}，判定原因：{assessment.Reason}");
        if (showHint)
        {
            HintService.Hint(Lang.Text(assessment.Classification == RegionClassification.Unknown
                ? "Region.Feature.Unknown"
                : "Region.Feature.Restricted"), HintType.Error);
        }
        return false;
        #endif
        return ture;
    }

    internal static void ThrowIfRestricted(string feature)
    {
        // Check 始终返回 true，这里自然不会再抛出异常
        if (Check(feature, false)) return;
        throw new ModBase.CancelledException();
    }
}
