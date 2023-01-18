using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool shakeconrol = false;


  public IEnumerator CameraShakes(float duration,float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;

        }

        transform.localPosition = originalPos;

    }

    public void CameraShakesCall()
    {
        if (shakeconrol == false)
        {
            StartCoroutine(CameraShakes(0.1f, 5f));
            shakeconrol = true;
        }
        
    }
}
