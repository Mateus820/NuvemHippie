using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	[SerializeField] private Sound[] sounds;

	void Awake() {
		if(instance == null){
			print("AudioManager");
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if(instance != this)
			Destroy(gameObject);

		SetSounds();
	}

	void SetSounds(){
		for (int i = 0; i < sounds.Length; i++)
		{
			sounds[i].source = gameObject.AddComponent<AudioSource>();
			sounds[i].source.clip = sounds[i].sound;
			sounds[i].source.volume = sounds[i].volume;
			sounds[i].source.playOnAwake = sounds[i].playOnAwake;
			sounds[i].source.loop = sounds[i].loop;
			if(sounds[i].playOnAwake) sounds[i].source.Play();
		}
	}

	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound: " + name + "doesn't exist!");
			return;
		}
		s.source.Play();
       
	}

	public void Pause(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound: " + name + "doesn't exist!");
			return;
		}
		s.source.Pause();
	}

	public void Stop(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound: " + name + "doesn't exist!");
			return;
		}
		s.source.Stop();
	}

	public void StopAll(){
		for(int i = 0; i < sounds.Length; i++){
			sounds[i].source.Stop();
		}
	}
}

[Serializable]
public class Sound
{
	public string name;
	public AudioClip sound;
	[Range(0f, 1f)] public float volume;
	public bool playOnAwake;
	public bool loop;
	[HideInInspector] public AudioSource source;
}
