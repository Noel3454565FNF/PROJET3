using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightScript : MonoBehaviour
{
    private float time;
    private Light2D Light;
    [SerializeField] private float transitionDuration;
    [SerializeField] private float nbActualisations;

    private void Start()
    {
        Light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 10)
        {
            time = 0;
            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        if (Light.intensity < 0.1)
        {
            for (float time = 0; time < transitionDuration; time +=1)
            {
                yield return new WaitForSeconds(transitionDuration / nbActualisations);
                Light.intensity = 1 / transitionDuration * time;
            }
            Light.intensity = 1;
        }
        else if (Light.intensity > 0.9)
        {
            for (float time = transitionDuration; time > 0; time -= 1)
            {
                yield return new WaitForSeconds(transitionDuration / nbActualisations);
                Light.intensity = 1 / transitionDuration * time;
            }
            Light.intensity = 0;
        }
    }
}
