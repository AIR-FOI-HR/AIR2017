using UnrealBuildTool;

public class AIRbenderVR3Target : TargetRules
{
	public AIRbenderVR3Target(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		ExtraModuleNames.Add("AIRbenderVR3");
	}
}
