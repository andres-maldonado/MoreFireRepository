using UnityEditor;

public class Builder
{
    private static void BuildMac() {
        BuildPipeline.BuildPlayer(new string[] {"Assets/Scenes/AddressableInitiator.unity"},
                                    "MacBuilds/FireBuildFinal.app", BuildTarget.StandaloneOSX, BuildOptions.AutoRunPlayer);
    }

    private static void BuildWindows() {
        BuildPipeline.BuildPlayer(new string[] {"Assets/Scenes/AddressableInitiator.unity"},
<<<<<<< HEAD
                                    "WindowsBuilds/FireProto.exe", BuildTarget.StandaloneWindows, BuildOptions.AutoRunPlayer);
=======
                                    "WindowsBuilds/FireBuildFinal.exe", BuildTarget.StandaloneWindows, BuildOptions.AutoRunPlayer);
>>>>>>> 91bca5026e0db5c5588c32688036b3c0ddc698f3
    }

}