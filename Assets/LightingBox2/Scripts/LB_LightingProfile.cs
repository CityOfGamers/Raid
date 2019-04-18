
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;

[CreateAssetMenu(fileName = "Lighting Data", menuName = "Lighting Profile", order = 1)]
public class LB_LightingProfile : ScriptableObject {

	[Header("Camera")]
	public string mainCameraName = "Main Camera";

	public VolumeProfile volumeProfile;

	public string objectName = "LB_LightingProfile";
	[Header("Profiles")]
	public PostProcessProfile postProcessingProfile;
	public bool webGL_Mobile = false;

	[Header("Global")]
	public  LightingMode lightingMode = LightingMode.RealtimeGI;
	public  float bakedResolution = 10f;
	public  LightSettings lightSettings = LightSettings.Mixed;
	public MyColorSpace colorSpace = MyColorSpace.Linear;

	[Header("Environment")]
	public  AmbientLight ambientLight = AmbientLight.Procedural;
	public  Cubemap skyCube;
	public  float skyExposure;
	public  float hdrRotation;
	[ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]
	public  Color skyTint;
	[ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]
	public  Color groundColor;
	public  float tickness;
	// gradient sky
	[ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]
	public  Color gradientTop = Color.blue;
	[ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]
	public  Color gradientMiddle = new Color(0.3f,0.7f,1f);
	[ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]
	public  Color gradientBottom = Color.white;
	public float gradientDiffusion = 1f;

	[Header("Sun")]
	public  Color sunColor = Color.white;
	public float sunIntensity = 2.1f;
	public Flare sunFlare;
	public float indirectIntensity = 1.43f;

	[Header("Fog")]
	public CustomFog fogMode = CustomFog.Exponential;
	public FogColorType fogColorMode;
	public float fogDistance;
	public float fogHeight;
	public float fogStart;
	public float fogEnd;
	[ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]
	public Color fogColor;
	public float fogDensity;
	// Volumetric Fog
	[ColorUsageAttribute(true,true,0f,8f,0.125f,3f)]
	public Color scatteringAlbedo = Color.white;
	public float freePath = 1000000f;
	public float fogAnisotropy = 0;
	public float LightProbeDimmer = 1f;

	[Header("Bloom")]
	public float bIntensity = 0.73f;
	public float bThreshould = 0.5f;
	public Color bColor = Color.white;
	public Texture2D dirtTexture;
	public float dirtIntensity;
	public bool mobileOptimizedBloom = false;
	public float bRotation;

	[Header("Indirect Controller")]
	public float indirectDiffuse = 0.3f;
	public float indirectSpecular = 0.3f;

	[Header("Micro  Shadowing")]
	public bool microEnabled = false;
	public float microOpacity = 1f;

	[Header("AO")]
	public AOType aoType = AOType.Modern;
	public float aoRadius = 0.3f;
	public float aoIntensity = 1f;
	public bool ambientOnly = false;
	public Color aoColor = Color.black;
	public AmbientOcclusionQuality aoQuality = AmbientOcclusionQuality.Medium;

	[Header("Other")]
	public LightProbeMode lightProbesMode;
	public bool automaticLightmap = false;

	[Header("Depth of Field")]
	public float dofDistance2;

	[Header("Color settings")]
	public float exposureIntensity = 1.43f;
	public float contrastValue = 30f;
	public float temp = 0;
	public ColorMode colorMode = ColorMode.ACES;
	public float saturation = 0;
	public float gamma = 0;
	public Color colorGamma = Color.black;
	public Color colorLift = Color.black;
	public Texture lut;

	[Header("Effects")]
	public float vignetteIntensity = 0.1f;
	public float CA_Intensity = 0.1f;

	[Header("Unity SSR")]
	public ScreenSpaceReflectionPreset ssrQuality = ScreenSpaceReflectionPreset.Lower;
	public float ssrAtten = 0;
	public float ssrFade = 0;

	[Range(0,1f)]
	public float eyeKeyValue  =   0.17f;   

	[Header("AA")]
	public AAMode aaMode;


	[Header("HD Render Pipeline")]
	// Sky box HDR
	CubemapParameter hdrSkyBox;

	[Header("HD Shadows")]
	public  int CascadeCount = 4;
	public float distance = 500f;
	public float split1 = 0.05f;
	public float split2 = 0.15f;
	public float split3 = 0.3f;

	[Header("Enabled Options")]
	public bool Ambient_Enabled = true;
	public bool Scene_Enabled = true;
	public bool Sun_Enabled = true;
	public bool VL_Enabled = false;
	public bool Fog_Enabled = false;
	public bool AutoFocus_Enabled = false;
	public bool DOF_Enabled = true;
	public bool Bloom_Enabled = false;
	public bool AA_Enabled = true;
	public bool AO_Enabled = false;
	public bool MotionBlur_Enabled = true;
	public bool Vignette_Enabled = true;
	public bool Chromattic_Enabled = true;
	public bool SSR_Enabled = false;
	public bool HD_Enabled = false;
	public bool Micro_Enabled = false;

	public bool ambientState = false;
	public bool sunState = false;
	public bool lightSettingsState = false;
	public bool cameraState = false;
	public bool profileState = false;
	public bool buildState = false;
	public bool fogState = false;
	public bool dofState = false;
	public bool autoFocusState =  false;
	public bool colorState = false;
	public bool bloomState = false;
	public bool aaState = false;
	public bool aoState = false;
	public bool motionBlurState = false;
	public bool vignetteState = false;
	public bool chromatticState = false;
	public bool ssrState;
	public bool hdState;
	public bool MicroState;
	public bool OptionsState = true;
	public bool LightingBoxState = true;
}