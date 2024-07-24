using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBurst : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    public IEnumerator Burst(float brightness)
    {
        if (brightness == 0)
        {
            Destroy(gameObject);
        }
        Light2D lightBurst = GetComponent<Light2D>();
        lightBurst.intensity = brightness;
        yield return new WaitForSeconds(0.3f);

        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the new intensity using Mathf.Lerp
            float targetIntensity = Mathf.Lerp(brightness, 0, elapsedTime / fadeDuration);

            // Set the intensity
            lightBurst.intensity = targetIntensity;

            // Wait for the next frame
            yield return null;
        }
        lightBurst.intensity = 0;
        Destroy(gameObject);


    }
}
