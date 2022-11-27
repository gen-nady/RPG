using UnityEngine;

[ExecuteInEditMode]
public class DayTime : MonoBehaviour
{
    [SerializeField] private Gradient directionalLightGradient;
    [SerializeField] private Gradient ambientLightGradient;
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
        dirLight.color = directionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

        dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z);
    }
}
