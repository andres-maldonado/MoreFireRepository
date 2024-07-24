using UnityEditor;

public class Builder
{
    private static void BuildMac() {
        BuildPipeline.BuildPlayer(new string[] {"Assets/Scenes/AddressableInitiator.unity"},
                                    "MacBuilds/FireBuildFinal.app", BuildTarget.StandaloneOSX, BuildOptions.AutoRunPlayer);
    }

    private static void BuildWindows() {
        BuildPipeline.BuildPlayer(new string[] {"Assets/Scenes/AddressableInitiator.unity"},
                                    "WindowsBuilds/FireProto.exe", BuildTarget.StandaloneWindows, BuildOptions.AutoRunPlayer);
    }

}