using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Look at using dots for many AudioSources
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private List<AudioSource> pool = new();
    
    private void Awake()
    {
        instance = this;
    }

    public void PlaySoundEffect(AudioClip clip, Vector3 position, float volume = 1f, float pitch = 1f)
    {
        GameObject go;
        if (pool.Count > 0)
        {
            go = pool[pool.Count - 1].gameObject;
            pool.RemoveAt(pool.Count - 1);
        }
        else
        {
            go = new GameObject("SoundEffect");
            go.transform.parent = transform;
            go.transform.position = position; 
        }
        var audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
        StartCoroutine(RecycleAfterPlay(audioSource));
    }
    
    private IEnumerator RecycleAfterPlay(AudioSource audioSource)
    {
        while (audioSource.isPlaying)
            yield return null;
        pool.Add(audioSource);
    }
}
