using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class DayTime : MonoBehaviour
{
    [SerializeField] private Gradient directionalLightGradient;
    [SerializeField] private Gradient ambientLightGradient;
    [SerializeField] private List<Material> daySky;
    [SerializeField] private List<Material> nightSky;
    [SerializeField, Range(1,3600)] private float timeDayInSeconds;
    [SerializeField, Range(0,1)] private float timeProgress;
    [SerializeField] private Light dirLight;
    private bool isNight;
    private Vector3 defaultAngles;

    private void Start()
    {
        defaultAngles = dirLight.transform.localEulerAngles;
    }

    private void Update()
    {
        if(Application.isPlaying)
            timeProgress += Time.deltaTime / timeDayInSeconds;
        if (timeProgress > 1f)
            timeProgress = 0f;
        if (timeProgress > 0.80f && !isNight)
        {
            RenderSettings.skybox = nightSky[Random.Range(0, nightSky.Count)];
            isNight = true;
        }

        if (timeProgress > 0.20f && timeProgress < 0.8f && isNight)
        {
            RenderSettings.skybox = daySky[Random.Range(0, daySky.Count)];
            isNight = false;
        }
        dirLight.color = directionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

        dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z);
    }
}
