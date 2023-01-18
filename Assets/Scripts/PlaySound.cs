using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip sound;
    bool keepPlaying = true;
     
    void Start () {
        StartCoroutine(SoundOut());
    }
     
    IEnumerator SoundOut()
    {
        while (keepPlaying){
            GetComponent<AudioSource>().PlayOneShot(sound);  
            Debug.Log("birds");
            yield return new WaitForSeconds(5);
        }
    }
}