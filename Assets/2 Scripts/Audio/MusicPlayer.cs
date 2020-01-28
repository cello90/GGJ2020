using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	public AudioClip introClip;
	public AudioClip loopClip;
	public AudioSequence sequence { get; private set; }

    public void Boot() {
        if (GetComponent<Game>().playMusic) {
            sequence = gameObject.AddComponent<AudioSequence>();
            sequence.Play(introClip, loopClip);
            AudioSequenceData data = sequence.GetData(loopClip);
            data.source.loop = true;
        }
    }
}
