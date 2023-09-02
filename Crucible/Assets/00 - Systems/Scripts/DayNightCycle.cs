using UnityEngine;

[ExecuteInEditMode]
public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    //private float timeRate;
    public Vector3 noon;

    [Header("sun")] 
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;
    
    //create the same variables for the moon
    [Header("moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;
            
    [Header("Other Lighting")] 
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;
    
    void Start()
    {
        //timeRate = 1 / fullDayLength;
        time = startTime;
    }

    void Update()
    {
        //increment time
       // time += timeRate * Time.deltaTime;
        if (time > 1.0f)
            time = 0.0f;
        
        //light rotation
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4f;
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4f;
        
        //light intensity
        var timeOfDay = Mathf.Clamp((time - 0.25f) * 2, 0,1);
        sun.intensity = sunIntensity.Evaluate(timeOfDay);
        moon.intensity = moonIntensity.Evaluate(getTimeOfNight());
        
        //change colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);
        
        //enable/disable the sun and moon based on their intensities
        sun.enabled = sun.intensity > 0.0f;
        moon.enabled = moon.intensity > 0.0f;
        
        //lighting and reflections intensity
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionsIntensityMultiplier.Evaluate(time);
        
    }

    //this is dumb
    private float getTimeOfNight()
    {
        if(time >= 0.75)
            return time - 0.75f;
        if(time <= 0.25)
            return time + 0.25f;
        return 0;
    }
}
