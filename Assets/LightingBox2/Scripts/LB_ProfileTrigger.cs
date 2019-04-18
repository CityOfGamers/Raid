// How to sitch using script(other script)?
// 	public void ChangeProfile(LB_LightingProfile profile)
// Watch the videos in tutorials playlist for more info   about lighting box usage
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_ProfileTrigger : MonoBehaviour {

	[Header("Note : You must close lighting box window when you are using Triggers based switch")]
	public string playerTag = "MainCamera";
	public LB_LightingProfile profile;
	LB_LightingProfile orginalProfile;

	Light sunLight;
	Camera mainCamera;
	LB_LightingBoxHelper helper;

	// Use this for initialization
	void Start ()
	{
		helper = GameObject.FindObjectOfType<LB_LightingBoxHelper> ();
		orginalProfile = helper.mainLightingProfile;

		if (!mainCamera) {
			if (GameObject.Find (profile.mainCameraName))
				mainCamera = GameObject.Find (profile.mainCameraName).GetComponent<Camera> ();
			else
				mainCamera = GameObject.FindObjectOfType<Camera> ();
		}


	}
	
	public void ChangeProfile(LB_LightingProfile profile)
	{
		Update_Sun (profile);
		UpdatePostEffects (profile);
		UpdateSettings (profile);
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == playerTag)
		{
			UpdatePostEffects (profile);
			UpdateSettings (profile);
			Update_Sun (profile);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == playerTag)
		{
			UpdatePostEffects (orginalProfile);
			UpdateSettings (orginalProfile);
			Update_Sun (orginalProfile);
		}
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

	}

	void UpdateSettings(LB_LightingProfile profile)
	{
		// Sun Light Update
		if (sunLight) {
			sunLight.color = profile.sunColor;
			sunLight.intensity = profile.sunIntensity;
			sunLight.bounceIntensity = profile.indirectIntensity;
		} else {
			Update_Sun (profile);
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


		// Global Fog
		helper.Update_GlobalFog(profile.Fog_Enabled,profile.fogMode,profile.fogColorMode,profile.fogColor,profile.fogDistance,profile.fogHeight,profile.fogStart,profile.fogEnd,profile.fogDensity
			,profile.scatteringAlbedo,profile.freePath,profile.fogAnisotropy,profile.LightProbeDimmer);
		
	}

	void Update_Sun(LB_LightingProfile profile)
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

}
