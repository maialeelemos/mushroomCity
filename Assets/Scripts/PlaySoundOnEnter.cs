using UnityEngine;
using System.Collections;

public class PlaySoundOnEnter : MonoBehaviour
{
    public AudioSource audioSource; 
    public string targetTag = "Player"; 
    public float fadeDuration = 1.0f; // Time it takes to fade in/out
    public float targetVolume = 0.5f; // Max volume during playback

    private Coroutine currentFade;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
                // Start fade-in
                if (currentFade != null) StopCoroutine(currentFade);
                currentFade = StartCoroutine(FadeAudio(audioSource, 0f, targetVolume));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                // Start fade-out
                if (currentFade != null) StopCoroutine(currentFade);
                currentFade = StartCoroutine(FadeAudio(audioSource, audioSource.volume, 0f, true));
            }
        }
    }

    private IEnumerator FadeAudio(AudioSource source, float startVol, float endVol, bool stopAfterFade = false)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            source.volume = Mathf.Lerp(startVol, endVol, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        source.volume = endVol;

        // Stop the audio after fading out
        if (stopAfterFade && endVol == 0f)
        {
            source.Stop();
        }
    }
}
