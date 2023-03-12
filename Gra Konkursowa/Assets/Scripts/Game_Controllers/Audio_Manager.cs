using System;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.AudioGroup;
        }
    }

    public void PlayOrStopAudio(string name, bool playing = true, float pitch = 0)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "Not found!");
            return;
        }

        if (playing)
        {
            if (pitch == 0) s.source.Play();
            else
            {
                s.source.pitch = pitch;
                s.source.Play();
            }
        }
        else s.source.Stop();
    }

    public void ResetAllAudio()
    {
        foreach (Sound s in sounds) s.source.Stop();
    }
}

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0.0f, 1.0f)]
    public float volume;

    [Range(0.1f, 3.0f)]
    public float pitch;

    public bool loop;

    public AudioMixerGroup AudioGroup;

    [HideInInspector]
    public AudioSource source;
}
