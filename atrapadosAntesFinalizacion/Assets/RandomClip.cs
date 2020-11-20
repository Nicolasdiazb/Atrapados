using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomClip : MonoBehaviour
{
    public List<AudioClip> clips;
    int currClipPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayClip());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PlayClip()
    {
        yield return new WaitForSecondsRealtime(Random.Range(7f, 20f));
        StartCoroutine(PlayClip());
    }
}
