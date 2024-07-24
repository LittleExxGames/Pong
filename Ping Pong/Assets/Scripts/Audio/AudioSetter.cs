using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetter : MonoBehaviour
{
    public bool doAL = false;

    // Update is called once per frame
    private void Update()
    {
        if (doAL)
        {
            AudioLoss();
        }
    }

    public void AudioLoss()
    {
        StartCoroutine(Slowdown());
    }

    private IEnumerator Slowdown()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 2.5f)
        {
            elapsedTime += Time.deltaTime;
            GetComponent<AudioSource>().pitch = Mathf.Lerp(1, 0.01f, elapsedTime / 2.5f);
            if (elapsedTime >= 2.5)
            {
                GetComponent<AudioSource>().Stop();
            }
            yield return new WaitForSecondsRealtime(0f);
        }
    }
}