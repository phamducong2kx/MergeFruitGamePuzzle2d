using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public bool checkSoundMute = false;
    public bool checkMusicMute = false;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public AudioSource mergeSource;
    public AudioSource clickSource;
    public AudioSource dropSource;
    public AudioSource beoDatMayTroi;
    public void PlayMergeSound()
    {
        //tao ra tu pool
        var x = PoolManager.Instance.Spawn(mergeSource.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        var component = x.GetComponent<AudioSource>();
        StartCoroutine(TimeCorotine(component, 1f));
    }
    public void PlayClickSound()
    {
        var x = PoolManager.Instance.Spawn(clickSource.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        var component = x.GetComponent<AudioSource>();
        StartCoroutine(TimeCorotine(component, 1f));
    }
    public void PlayDropSound()
    {
        var x = PoolManager.Instance.Spawn(dropSource.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        var component = x.GetComponent<AudioSource>();
        StartCoroutine(TimeCorotine(component, 1f));
    }
    public void PlayNhacNen()
    {
        var x = PoolManager.Instance.Spawn(beoDatMayTroi.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        var component = x.GetComponent<AudioSource>();
        component.Play();
        //  StartCoroutine(TimeCorotine(component, 1f));
    }

    IEnumerator TimeCorotine(AudioSource x, float delay)
    {
        x.Play();
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Despawn(x.gameObject);
    }

    //tắt bật hiueej ứng âm thanh
    public void SoundOff()
    {
        mergeSource.mute = false;
        clickSource.mute = false;
        dropSource.mute = false;
        //checkSoundMute = false;


    }
    public void SoundOn()
    {

        mergeSource.mute = false;
        clickSource.mute = false;
        dropSource.mute = false;
        //   checkSoundMute = false;
    }

    //tắt bật nhạc nền
    public void MusicMute()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
