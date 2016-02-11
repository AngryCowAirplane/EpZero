using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	// Use this for initialization
    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("fader").GetComponent<ScreenFader> ();

        if (other.tag == "Player")
        {
            yield return StartCoroutine(sf.FadeToBlack());
            other.gameObject.transform.position = warpTarget.position;
            Camera.main.transform.position = warpTarget.position;
            yield return StartCoroutine(sf.FadeToClear());
        }
    }
}
