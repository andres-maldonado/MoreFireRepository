using UnityEditor;

public class Builder
{
    private static void BuildMac() {
        BuildPipeline.BuildPlayer(new string[] {"Assets/Scenes/ShowcaseScene1.unity", "Assets/Scenes/ShowcaseScene2.unity"},
                                    "MacBuilds/FireProto.app", BuildTarget.StandaloneOSX, BuildOptions.AutoRunPlayer);
    }

    private static void BuildWindows() {
        BuildPipeline.BuildPlayer(new string[] {"Assets/Scenes/ShowcaseScene1.unity", "Assets/Scenes/ShowcaseScene2.unity"},
                                    "WindowsBuilds/FireProto.exe", BuildTarget.StandaloneWindows, BuildOptions.AutoRunPlayer);
    }

}