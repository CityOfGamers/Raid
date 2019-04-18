// Use this script to get runtime access to the lighting box econtrolled effects
/// <summary>
/// example :
/// 
/// // Update bloom effect .
/// void Start ()
/// {
///   	GameObject.FindObjectOfType<LB_LightingBoxHelper> ().Update_Bloom (true, 1f, 0.5f, Color.white);
/// }
/// </summary>
using UnityEngine;   
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;

#if UNITY_EDITOR
using UnityEditor;
#endif

#region Emum Types
public enum FogColorType
{
	SkyColor,CustomColor
}
public enum CameraMode
{
	Single,All,Custom
}
public enum WindowMode
{
	Part1,Part2,Part3,
	Finish
}
public enum AmbientLight
{
	HDR,
	Procedural,Gradient,
	None
}
public enum LightingMode
{
	FullyRealtime,
	RealtimeGI,
	Baked,
	RealtimeGIandBakedGI
}
public enum LightSettings
{
	Default,
	Realtime,
	Mixed,
	Baked
}
public enum MyColorSpace
{
	Linear,
	Gamma
}

public enum CustomFog
{
	Exponential,
	Linear,
	Volumetric
}
public enum LightsShadow
{
	OnlyDirectionalSoft,OnlyDirectionalHard,
	AllLightsSoft,AllLightsHard,
	Off
}
public enum LightProbeMode
{
	Blend,
	Proxy
}

public enum DOFQuality
{
	Low,Medium,High
}

public enum AOType
{
	Classic,Modern
}

public enum ColorMode
{
	ACES,Neutral,LUT
}

public enum AAMode
{
	TAA,FXAA,SMAA
}

#endregion

public class LB_LightingBoxHelper : MonoBehaviour {

	public LB_LightingProfile mainLightingProfile;
	public VolumeProfile volumeProfileMain;

	#region Runtime Update

	Light sunLight;
	Camera mainCamera;
	LB_LightingBoxHelper helper;

	void Start()
	{
		if (!mainCamera) {
			if (GameObject.Find (mainLightingProfile.mainCameraName))
				mainCamera = GameObject.Find (mainLightingProfile.mainCameraName).GetComponent<Camera> ();
			else
				mainCamera = GameObject.FindObjectOfType<Camera> ();
		}

		Update_SunRuntime (mainLightingProfile);
		UpdatePostEffects (mainLightingProfile);
		UpdateSettings (mainLightingProfile);
	}

	void UpdatePostEffects(LB_LightingProfile profile)
	{
		if(!helper)
			helper = GameObject.Find("LightingBox_Helper").GetComponent<LB_LightingBoxHelper> ();

		if (!profile)
			return;

		helper.UpdateProfiles (mainCamera, profile.postProcessingProfile,profile.volumeProfile);

		// MotionBlur
		if (profile.MotionBlur_Enabled)
			helper.Update_MotionBlur (true);
		else
			helper.Update_MotionBlur (false);

		// Vignette
		helper.Update_Vignette (profile.Vignette_Enabled,profile.vignetteIntensity);


		// _ChromaticAberration
		helper.Update_ChromaticAberration(profile.Chromattic_Enabled,profile.CA_Intensity);

		// Foliage
	//	helper.Update_Foliage (profile.translucency,profile. ambient, profile.shadows, profile.windSpeed, profile.windScale, profile.tranColor);

		// Snow
	//	helper.Update_Snow (profile.snowAlbedo,profile.snowNormal,profile.snowIntensity);

		helper.Update_Bloom(profile.Bloom_Enabled,profile.bIntensity,profile.bThreshould,profile.bColor,profile.dirtTexture,profile.dirtIntensity,profile.mobileOptimizedBloom,profile.bRotation);


		// Depth of Field
		helper.Update_DOF(profile.DOF_Enabled,profile.dofDistance2);

		// AO
		if (profile.AO_Enabled)
			helper.Update_AO(mainCamera,true,profile.aoType,profile.aoRadius,profile.aoIntensity,profile.ambientOnly,profile.aoColor, profile.aoQuality);
		else
			helper.Update_AO(mainCamera,false,profile.aoType,profile.aoRadius,profile.aoIntensity,profile.ambientOnly,profile.aoColor, profile.aoQuality);


		// Color Grading
		helper.Update_ColorGrading(profile.colorMode,profile.exposureIntensity,profile.contrastValue,profile.temp,profile.eyeKeyValue,profile.saturation,profile.colorGamma,profile.colorLift,profile.gamma,profile.lut);

		////-----------------------------------------------------------------------------
		/// 
		// Screen Space Reflections
		helper.Update_SSR(mainCamera, profile.SSR_Enabled,profile.ssrQuality,profile.ssrAtten,profile.ssrFade);

	//	helper.Update_StochasticSSR(mainCamera, profile.ST_SSR_Enabled,profile.resolutionMode,profile.debugPass,profile.rayDistance,profile.screenFadeSize,profile.smoothnessRange);

	}

	void UpdateSettings(LB_LightingProfile profile)
	{
		// Sun Light Update
		if (sunLight) {
			sunLight.color = profile.sunColor;
			sunLight.intensity = profile.sunIntensity;
			sunLight.bounceIntensity = profile.indirectIntensity;
		} else {
			Update_SunRuntime (profile);
		}

		if (profile.sunFlare)
		{
			if(sunLight)
				sunLight.flare = profile.sunFlare;
		}
		else
		{
			if(sunLight)
				sunLight.flare = null;
		}

		// Update Ambient
		helper.Update_Ambient (profile.Ambient_Enabled,profile.ambientLight,profile.skyCube, profile.skyExposure,profile.hdrRotation,profile.skyTint,profile.groundColor,profile.tickness
			,profile.gradientTop,profile.gradientMiddle,profile.gradientBottom,profile.gradientDiffusion);

		// Volumetric Light
	//	helper.Update_VolumetricLight(mainCamera,profile.VL_Enabled,profile.vLight,profile.vLightLevel);

		// Sun Shaft
	//	helper.Update_SunShaft(mainCamera,profile.SunShaft_Enabled, profile.shaftQuality,profile.shaftDistance,profile.shaftBlur,profile.shaftColor,sunLight.transform);

		// Global Fog
		helper.Update_GlobalFog(profile.Fog_Enabled,profile.fogMode,profile.fogColorMode,profile.fogColor,profile.fogDistance,profile.fogHeight,profile.fogStart,profile.fogEnd,profile.fogDensity
			,profile.scatteringAlbedo,profile.freePath,profile.fogAnisotropy,profile.LightProbeDimmer);

	}

	void Update_SunRuntime(LB_LightingProfile profile)
	{
		if (profile.Sun_Enabled) {
			if (!UnityEngine.RenderSettings.sun) {
				Light[] lights = GameObject.FindObjectsOfType<Light> ();
				foreach (Light l in lights) {
					if (l.type == LightType.Directional) {
						sunLight = l;

						if (profile.sunColor != Color.clear)
							profile.sunColor = l.color;
						else
							profile.sunColor = Color.white;

						//sunLight.shadowNormalBias = 0.05f;  
						sunLight.color = profile.sunColor;
						if (sunLight.bounceIntensity == 1f)
							sunLight.bounceIntensity = profile.indirectIntensity;
					}
				}
			} else {		
				sunLight = UnityEngine.RenderSettings.sun;

				if (profile.sunColor != Color.clear)
					profile.sunColor = sunLight.color;
				else
					profile.sunColor = Color.white;

				//	sunLight.shadowNormalBias = 0.05f;  
				sunLight.color = profile.sunColor;
				if (sunLight.bounceIntensity == 1f)
					sunLight.bounceIntensity = profile.indirectIntensity;
			}
		}


	}

	#endregion

	public void Update_MainProfile(LB_LightingProfile profile,VolumeProfile volumeProfile)
	{
		if(profile)
			mainLightingProfile = profile;

		if(volumeProfile)
			volumeProfileMain = volumeProfile;             
	}

	public void UpdateProfiles(Camera mainCamera,PostProcessProfile profile,VolumeProfile volumeProfile)
	{
		if (!profile)
			return;
		
		if (profile)
		{
			if (!mainCamera.GetComponent<PostProcessLayer> ())
			{
				mainCamera.gameObject.AddComponent<PostProcessLayer> ();
				mainCamera.gameObject.GetComponent<PostProcessLayer> ().antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
				mainCamera.gameObject.GetComponent<PostProcessLayer> ().volumeLayer = LayerMask.NameToLayer("Everything");
				mainCamera.gameObject.GetComponent<PostProcessLayer> ().fog.enabled = true;
				mainCamera.gameObject.GetComponent<PostProcessLayer> ().Init(null);
			}
			
		}

		if (!GameObject.Find ("Post Processing Global Volume")) {
			GameObject gVolume = new GameObject ();
			gVolume.name = "Post Processing Global Volume";
			gVolume.AddComponent<PostProcessVolume> ();
			gVolume.GetComponent<PostProcessVolume> ().isGlobal = true;
			gVolume.GetComponent<PostProcessVolume> ().priority = 1f;
			if (profile)
				gVolume.GetComponent<PostProcessVolume> ().sharedProfile = profile;
		} else {
			if (profile)
				GameObject.Find ("Post Processing Global Volume").GetComponent<PostProcessVolume> ().sharedProfile = profile;
		}



		if (!GameObject.Find ("Fog/Sky/HD Volume")) {
			GameObject fogVolume = new GameObject ();
			fogVolume.name = "Fog/Sky/HD Volume";
			fogVolume.AddComponent<Volume> ();
			fogVolume.GetComponent<Volume> ().isGlobal = true;
			fogVolume.GetComponent<Volume> ().priority = 1f;
			if (volumeProfile)
				fogVolume.GetComponent<Volume> ().sharedProfile = volumeProfile;
		} else {
			if (volumeProfile)
				GameObject.Find ("Fog/Sky/HD Volume").GetComponent<Volume> ().sharedProfile = volumeProfile;
		}
	}

	public void Update_MotionBlur(bool enabled)
	{
		MotionBlur mb;
		GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out mb);
		mb.enabled.value = enabled; 
	}

	public void Update_Vignette(bool enabled, float intensity)
	{
		Vignette vi;
		GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out vi);

		vi.enabled.value = enabled; 

		vi.intensity.overrideState = true;
		vi.intensity.value = intensity;

		vi.smoothness.overrideState = true;
		vi.smoothness.value = 1f;

		vi.roundness.overrideState = true;
		vi.roundness.value = 1f;

	}

	public void Update_ChromaticAberration(bool enabled,float intensity)
	{
		ChromaticAberration ca;
		GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out ca);

		ca.intensity.overrideState = true;
		ca.intensity.value = intensity;

		ca.fastMode.overrideState = true;

		ca.enabled.value = enabled; 
	}

	public void Update_Bloom(bool enabled,float intensity,float threshold,Color color,Texture2D dirtTexture,float dirtIntensity,bool mobileOptimized,float bRotation)
	{
		if(enabled)
		{
			Bloom b;
			GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out b);
			b.intensity.overrideState = true;
			b.intensity.value = intensity;
			b.threshold.overrideState = true;
			b.threshold.value = threshold;
			b.color.overrideState = true;
			b.color.value = color;

			b.anamorphicRatio.overrideState = true;
			b.anamorphicRatio.value = bRotation;

			b.fastMode.overrideState = true;
			b.fastMode.value = mobileOptimized;

			b.dirtTexture.overrideState = true;
			b.dirtTexture.value = dirtTexture;

			b.dirtIntensity.overrideState = true;
			b.dirtIntensity.value = dirtIntensity;

			b.enabled.value = true;
		}
		else
		{
			Bloom b;
			GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out b);
			b.intensity.overrideState = true;
			b.intensity.value = intensity;
			b.threshold.overrideState = true;
			b.threshold.value = threshold;
			b.color.overrideState = true;
			b.color.value = color;

			b.dirtTexture.overrideState = true;
			b.dirtTexture.value = dirtTexture;

			b.dirtIntensity.overrideState = true;
			b.dirtIntensity.value = dirtIntensity;

			b.anamorphicRatio.overrideState = true;
			b.anamorphicRatio.value = bRotation;

			b.enabled.value = false;
		}
	}

	public void Update_DOF(bool dofEnabled,float dofDistance2)
	{
		DepthOfField dof;
		GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out dof);

		dof.enabled.overrideState = true;
		dof.enabled.value = dofEnabled;
		dof.aperture.overrideState = true;
		dof.aperture.value = 0.9f;

		dof.focalLength.overrideState = true;
		dof.focalLength.value = 2f;

		dof.focusDistance.overrideState = true;
		dof.focusDistance.value = dofDistance2;

		dof.kernelSize.overrideState = true;
		dof.kernelSize.value = KernelSize.Medium;
	}

	public void Update_AA(Camera mainCamera ,AAMode aaMode, bool  enabled)
	{
		if (enabled) {
			if (aaMode == AAMode.TAA) {
				mainCamera.GetComponent<PostProcessLayer> ().antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
				mainCamera.GetComponent<PostProcessLayer> ().Init (null);
			}
			if (aaMode == AAMode.FXAA) {
				mainCamera.GetComponent<PostProcessLayer> ().antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
				mainCamera.GetComponent<PostProcessLayer> ().Init (null);
			}
			if (aaMode == AAMode.SMAA) {
				mainCamera.GetComponent<PostProcessLayer> ().antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
				mainCamera.GetComponent<PostProcessLayer> ().Init (null);
			}
		} else {
			mainCamera.GetComponent<PostProcessLayer> ().antialiasingMode = PostProcessLayer.Antialiasing.None;
			mainCamera.GetComponent<PostProcessLayer> ().Init (null);
		}
	}

	public void Update_AO(Camera mainCamera ,bool enabled,AOType aoType,float aoRadius,float aoIntensity,bool ambientOnly,Color aoColor, AmbientOcclusionQuality aoQuality)
	{

		AmbientOcclusion ao;
		GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out ao);

		if (enabled) {
			if (aoType == AOType.Classic) {
				ao.enabled.overrideState = true;
				ao.enabled.value = true;
				ao.mode.overrideState = true;
				ao.mode.value = AmbientOcclusionMode.ScalableAmbientObscurance;
				ao.radius.overrideState = true;
				ao.radius.value = aoRadius;
				ao.ambientOnly.overrideState = true;
				ao.ambientOnly.value = ambientOnly;
				ao.color.overrideState = true;
				ao.color.value = aoColor;
				ao.intensity.overrideState = true;
				ao.intensity.value = aoIntensity;
				ao.quality.overrideState = true;
				ao.quality.value = aoQuality;
			}
			if (aoType == AOType.Modern) {		
				ao.enabled.overrideState = true;
				ao.enabled.value = true;
				ao.mode.overrideState = true;
				ao.mode.value = AmbientOcclusionMode.MultiScaleVolumetricObscurance;
				ao.radius.overrideState = true;
				ao.radius.value = aoRadius;
				ao.ambientOnly.overrideState = true;
				ao.ambientOnly.value = ambientOnly;
				ao.color.overrideState = true;
				ao.color.value = aoColor;
				ao.intensity.overrideState = true;
				ao.intensity.value = aoIntensity;
			}
		} else {
			ao.enabled.overrideState = true;
			ao.enabled.value = false;
		}
	}

	public void Update_ColorGrading(ColorMode colorMode,float exposureIntensity,float contrastValue,float temp,float eyeKeyValue
		,float saturation,Color colorGamma,Color colorLift,float gamma,Texture lut)
	{
		ColorGrading cg;
		GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out cg);

		AutoExposure ae;
		GameObject.Find("Post Processing Global Volume").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out ae);

			if (colorMode == ColorMode.ACES) {
				cg.tonemapper.overrideState = true;
				cg.tonemapper.value = Tonemapper.ACES;
				cg.gradingMode.value = GradingMode.HighDefinitionRange;

			}
			if (colorMode == ColorMode.Neutral) {
				cg.tonemapper.overrideState = true;
				cg.tonemapper.value = Tonemapper.Neutral;
				cg.gradingMode.value = GradingMode.HighDefinitionRange;

			}

		if (colorMode == ColorMode.LUT) {
			cg.tonemapper.overrideState = true;
			cg.tonemapper.value = Tonemapper.Custom;
			cg.gradingMode.value = GradingMode.External;
			if (lut != null) {
				cg.externalLut.overrideState = true;
				cg.externalLut.value = lut;
			}
		} else {

			cg.lift.overrideState = true;
			cg.lift.value.Set (colorLift.r, colorLift.g, colorLift.b, 0);

			cg.gamma.overrideState = true;
			cg.gamma.value.Set (colorGamma.r, colorGamma.g, colorGamma.b, gamma);

			cg.gain.overrideState = true;
			cg.gain.value.Set (cg.gain.value.x, cg.gain.value.y, cg.gain.value.z, 0);

			cg.saturation.overrideState = true;
			cg.saturation.value = saturation * 100;

			cg.saturation.overrideState = true;
			cg.saturation.value = saturation * 100;
			cg.postExposure.overrideState = true;
			cg.postExposure.value = exposureIntensity;
			cg.contrast.overrideState = true;
			cg.contrast.value = contrastValue * 100;
			cg.temperature.overrideState = true;
			cg.temperature.value = temp;
			cg.enabled.value = true;

			ae.keyValue.value = eyeKeyValue;
			ae.enabled.value = true;
		}
	}

	public void Update_SSR(Camera mainCamera ,bool enabled,ScreenSpaceReflectionPreset preset,float atten,float fade)
	{
		/*
		ScreenSpaceReflections ssr;
		GameObject.Find("\t\thelper.Update_Ambient (profile.Ambient_Enabled,profile.ambientLight,profile.skyCube, profile.skyExposure,profile.hdrRotation,profile.skyTint,profile.groundColor,profile.tickness);\n").GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out ssr);

		ssr.enabled.overrideState = true;
		ssr.enabled.value = enabled;

		ssr.preset.overrideState = true;
		ssr.preset.value = preset;

		ssr.vignette.overrideState = true;
		ssr.vignette.value = atten;

		ssr.distanceFade.overrideState = true;
		ssr.distanceFade.value = fade;

*/
	}

	public void Update_MicroShadowing(bool enabled, float opacity)
	{
		
		MicroShadowing mShadow;
		GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out mShadow);

		mShadow.enable.overrideState = true;
		mShadow.opacity.overrideState = true;
		mShadow.enable.value  = enabled;
		mShadow.opacity.value = new ClampedFloatParameter(opacity, 0.0f, 1.0f);

	}
		
	public void Update_LightingMode(bool enabled, LightingMode lightingMode,float indirectDiffuse, float  indirectSpecular)
	{
		if (enabled) {
			#if UNITY_EDITOR
			if (lightingMode == LightingMode.RealtimeGI) {
				Lightmapping.realtimeGI = true;
				Lightmapping.bakedGI = false;
				LightmapEditorSettings.lightmapper = LightmapEditorSettings.Lightmapper.Enlighten;
			}
			if (lightingMode == LightingMode.Baked) {
				Lightmapping.realtimeGI = false;
				Lightmapping.bakedGI = true;
				LightmapEditorSettings.lightmapper = LightmapEditorSettings.Lightmapper.ProgressiveCPU;
			}
			if (lightingMode == LightingMode.FullyRealtime) {
				Lightmapping.realtimeGI = false;
				Lightmapping.bakedGI = false;
			}
			if (lightingMode == LightingMode.RealtimeGIandBakedGI) {
				Lightmapping.realtimeGI = true;
				Lightmapping.bakedGI = true;
				LightmapEditorSettings.lightmapper = LightmapEditorSettings.Lightmapper.ProgressiveCPU;
			}
			#endif
			//***
			IndirectLightingController inController;
			GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out inController);

			inController.indirectDiffuseIntensity.overrideState = true;
			inController.indirectSpecularIntensity.overrideState = true;
			inController.indirectDiffuseIntensity.value  = new MinFloatParameter(indirectDiffuse, 0.0f);
			inController.indirectSpecularIntensity.value = new MinFloatParameter(indirectSpecular, 0.0f);

		}
	}

	public void Update_HDSHadows(bool enabled ,int cascadeCount,float distance,float split1,float split2,float split3)
	{
		if(enabled)
		{
			HDShadowSettings hdShadows;
			GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out hdShadows);

			hdShadows.cascadeShadowSplitCount.overrideState = true;
			hdShadows.cascadeShadowSplitCount.value  =new NoInterpClampedIntParameter(cascadeCount, 1, 4);

			hdShadows.maxShadowDistance.overrideState = true;
			hdShadows.maxShadowDistance.value  =  new NoInterpMinFloatParameter(distance,0f);

			hdShadows.cascadeShadowSplit0.overrideState = true;
			hdShadows.cascadeShadowSplit0.value  = new NoInterpClampedFloatParameter(split1,0 , 1f);

			hdShadows.cascadeShadowSplit1.overrideState = true;
			hdShadows.cascadeShadowSplit1.value =  new NoInterpClampedFloatParameter(split2, 0, 1f);

			hdShadows.cascadeShadowSplit2.overrideState = true;
			hdShadows.cascadeShadowSplit2.value =  new NoInterpClampedFloatParameter(split3, 0, 1f);
		}
	}

	public void Update_Ambient(bool enabled,AmbientLight ambientMode,Cubemap skyCube,float skyExposure,float hdrRotation,
		Color skyTint,Color groundColor,float tickness,Color gradientTop,Color gradientMiddle,Color gradientBottom,float gradientDiffusion)
	{
		if (enabled)
		{
			VisualEnvironment enviro;
			GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out enviro);

			if (ambientMode == AmbientLight.HDR) {

				enviro.skyType.overrideState = true;
				enviro.skyType.value = (int)SkyType.HDRISky;

				try{
				HDRISky hdrSkyBox  ;
				GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out hdrSkyBox);

				hdrSkyBox.exposure.overrideState = true;
				hdrSkyBox.exposure.value = skyExposure;

				hdrSkyBox.hdriSky.overrideState = true;
				hdrSkyBox.hdriSky.value = skyCube;
				
				hdrSkyBox.rotation.overrideState = true;
					hdrSkyBox.rotation.value = hdrRotation;
				}
				catch{}				
			}
			if (ambientMode == AmbientLight.Procedural) {
				enviro.skyType.overrideState = true;
				enviro.skyType.value = (int)SkyType.ProceduralSky;

				ProceduralSky pSky  ;
				GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out pSky);

				pSky.skyTint.overrideState = true;
				pSky.skyTint.value = skyTint;

				pSky.groundColor.overrideState = true;
				pSky.groundColor.value = groundColor;

				pSky.atmosphereThickness.overrideState = true;
				pSky.atmosphereThickness.value = tickness;

				pSky.exposure.overrideState = true;
				pSky.exposure.value = skyExposure;
			}
			if (ambientMode == AmbientLight.Gradient) {

				enviro.skyType.overrideState = true;
				enviro.skyType.value = (int)SkyType.Gradient;

				GradientSky gSky  ;
				GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out gSky);

				gSky.top.overrideState = true;
				gSky.top.value = new UnityEngine.Experimental.Rendering
					.ColorParameter(gradientTop, true, false, true);

				gSky.middle.overrideState = true;
				gSky.middle.value = new UnityEngine.Experimental.Rendering
					.ColorParameter(gradientMiddle, true, false, true);

				gSky.bottom.overrideState = true;
				gSky.bottom.value =  new UnityEngine.Experimental.Rendering
					.ColorParameter(gradientBottom, true, false, true);

				gSky.gradientDiffusion.overrideState = true;
				gSky.gradientDiffusion.value = new UnityEngine.Experimental.Rendering
					.FloatParameter(gradientDiffusion);
			}
			if (ambientMode == AmbientLight.None) {



				enviro.skyType.overrideState = true;
				enviro.skyType.value = 0;

			}


		}
	}

	#if UNITY_EDITOR
	public void Update_LightSettings(bool enabled, LightSettings lightSettings)
	{
		if(enabled)
		{
			if (lightSettings == LightSettings.Baked) {

				Light[] lights = GameObject.FindObjectsOfType<Light> ();

				foreach (Light l in lights) {
					SerializedObject serialLightSource = new SerializedObject(l);
					SerializedProperty SerialProperty  = serialLightSource.FindProperty("m_Lightmapping");
					SerialProperty.intValue = 2;
					serialLightSource.ApplyModifiedProperties ();
				}
			} 
			if (lightSettings == LightSettings.Realtime) {

				Light[] lights = GameObject.FindObjectsOfType<Light> ();

				foreach (Light l in lights) {
					SerializedObject serialLightSource = new SerializedObject(l);
					SerializedProperty SerialProperty  = serialLightSource.FindProperty("m_Lightmapping");
					SerialProperty.intValue = 4;
					serialLightSource.ApplyModifiedProperties ();
				}
			}
			if (lightSettings == LightSettings.Mixed) {

				Light[] lights = GameObject.FindObjectsOfType<Light> ();

				foreach (Light l in lights) {
					SerializedObject serialLightSource = new SerializedObject(l);
					SerializedProperty SerialProperty  = serialLightSource.FindProperty("m_Lightmapping");
					SerialProperty.intValue = 1;
					serialLightSource.ApplyModifiedProperties ();
				}

			}
		}
	}

	public void Update_AutoMode(bool enabled)
	{
		if(enabled)
			Lightmapping.giWorkflowMode = Lightmapping.GIWorkflowMode.Iterative;
		else
			Lightmapping.giWorkflowMode = Lightmapping.GIWorkflowMode.OnDemand;
	}
	public void Update_LightProbes(bool enabled, LightProbeMode lightProbesMode)
	{
		if (enabled) {
			if (lightProbesMode == LightProbeMode.Blend) {

				MeshRenderer[] renderers = GameObject.FindObjectsOfType<MeshRenderer> ();

				foreach (MeshRenderer mr in renderers) {
					if (!mr.gameObject.isStatic) {
						if (mr.gameObject.GetComponent<LightProbeProxyVolume> ()) {
							if (Application.isPlaying)
								Destroy (mr.gameObject.GetComponent<LightProbeProxyVolume> ());
							else
								DestroyImmediate (mr.gameObject.GetComponent<LightProbeProxyVolume> ());
						}
						mr.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
					}
				}
			}
			if (lightProbesMode == LightProbeMode.Proxy) {

				MeshRenderer[] renderers = GameObject.FindObjectsOfType<MeshRenderer> ();

				foreach (MeshRenderer mr in renderers) {

					if (!mr.gameObject.isStatic) {
						if (!mr.gameObject.GetComponent<LightProbeProxyVolume> ())
							mr.gameObject.AddComponent<LightProbeProxyVolume> ();
						mr.gameObject.GetComponent<LightProbeProxyVolume> ().resolutionMode = LightProbeProxyVolume.ResolutionMode.Custom;
						mr.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.UseProxyVolume;
					}
				}
			}
		}
	}

	#endif

	public void Update_GlobalFog(bool fogEnabled,CustomFog fogMode,FogColorType fogColorMode,Color fogColor,float fogDistance,
		float fogHeight,float fogStart,float fogEnd,float fogDensity  ,Color scatteringAlbedo,float freePath,float fogAnisotropy
		,float LightProbeDimmer)
	{
		VisualEnvironment enviro;
		GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out enviro);

		if (fogEnabled)
		{
			if (fogMode == CustomFog.Exponential) {
				enviro.fogType.overrideState = true;
				enviro.fogType.value = FogType.Exponential;

				ExponentialFog exFog;
				GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out exFog);

				exFog.colorMode.overrideState = true;
				if(fogColorMode == FogColorType.SkyColor)
					exFog.colorMode.value = FogColorMode.SkyColor;
				if(fogColorMode == FogColorType.CustomColor)
					exFog.colorMode.value = FogColorMode.ConstantColor;
				
				exFog.fogDistance.overrideState = true;
				exFog.fogDistance.value = fogDistance;

				exFog.fogBaseHeight.overrideState = true;
				exFog.fogBaseHeight.value = fogHeight;

				exFog.color.overrideState = true;
				exFog.color.value = fogColor;


				exFog.density.overrideState = true;
				exFog.density.value = fogDensity;

			}
			if (fogMode == CustomFog.Linear) {
				enviro.fogType.overrideState = true;
				enviro.fogType.value = FogType.Linear;

				LinearFog exFog;
				GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out exFog);

				if(fogColorMode == FogColorType.SkyColor)
					exFog.colorMode.value = FogColorMode.SkyColor;
				if(fogColorMode == FogColorType.CustomColor)
					exFog.colorMode.value = FogColorMode.ConstantColor;
				
				exFog.fogStart.overrideState = true;
				exFog.fogStart.value = fogStart;

				exFog.fogEnd.overrideState = true;
				exFog.fogEnd.value = fogEnd;

				exFog.fogHeightEnd.overrideState = true;
				exFog.fogHeightEnd.value = fogHeight;

				exFog.color.overrideState = true;
				exFog.color.value = fogColor;

				exFog.density.overrideState = true;
				exFog.density.value = fogDensity;
			}
			if (fogMode == CustomFog.Volumetric) {
				
				enviro.fogType.overrideState = true;
				enviro.fogType.value = FogType.Volumetric;

				VolumetricFog volFog;
				GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out volFog);
           
				volFog.albedo.overrideState = true;
				volFog.albedo.value =  new UnityEngine.Experimental.Rendering
					.ColorParameter(scatteringAlbedo);

				volFog.meanFreePath.overrideState = true;
				volFog.meanFreePath.value =  new MinFloatParameter(freePath, 1.0f);

				volFog.anisotropy.overrideState = true;
				volFog.anisotropy.value =  new ClampedFloatParameter(fogAnisotropy, -1.0f, 1.0f);

				volFog.globalLightProbeDimmer.overrideState = true;
				volFog.globalLightProbeDimmer.value =  new ClampedFloatParameter(LightProbeDimmer, 0.0f, 1.0f);

			}
		}
		if(!fogEnabled)
		{
			enviro.fogType.overrideState = true;
			enviro.fogType.value = FogType.None;
		}
	}

	public void Update_Sun(bool enabled,Light sunLight,Color sunColor,float indirectIntensity)
	{
		if (enabled) {
			if (!UnityEngine.RenderSettings.sun) {
				Light[] lights = GameObject.FindObjectsOfType<Light> ();

				foreach (Light l in lights) {
					if (l.type == LightType.Directional) {
						sunLight = l;

						if (sunColor != Color.clear)
							sunColor = sunLight.color;
						else
							sunColor = Color.white;

						//	sunLight.shadowNormalBias = 0.05f;  
						sunLight.color = sunColor;
						if (sunLight.bounceIntensity == 1f)
							sunLight.bounceIntensity = indirectIntensity;
					}
				}
			} else {
				sunLight = UnityEngine.RenderSettings.sun;

				if (sunColor != Color.clear)
					sunColor = sunLight.color;
				else
					sunColor = Color.white;

				//sunLight.shadowNormalBias = 0.05f;  
				sunLight.color = sunColor;
				if (sunLight.bounceIntensity == 1f)
					sunLight.bounceIntensity = indirectIntensity;
			}
		}
	}

	bool effectsIsOn = true;

	public void Toggle_Effects()
	{
		effectsIsOn = !effectsIsOn;

		// Post layers
		PostProcessLayer[] postLayers = GameObject.FindObjectsOfType<PostProcessLayer> ();
		for (int a = 0; a < postLayers.Length; a++)
			postLayers [a].enabled = effectsIsOn;

		VisualEnvironment enviro;
		GameObject.Find("Fog/Sky/HD Volume").GetComponent<Volume>().sharedProfile.TryGet(out enviro);


		enviro.active = effectsIsOn;
		// Depth of Field
		/**LightingBox.Effects.DepthOfField[] dofEffects = GameObject.FindObjectsOfType<LightingBox.Effects.DepthOfField> ();
		for (int a = 0; a < dofEffects.Length; a++)
			dofEffects [a].enabled = effectsIsOn;
*/
		// Global fog
	/*	LightingBox.Effects.GlobalFog[] gFogS = GameObject.FindObjectsOfType<LightingBox.Effects.GlobalFog> ();
		for (int a = 0; a < gFogS.Length; a++)
			gFogS [a].enabled = effectsIsOn;*/
	}
}
