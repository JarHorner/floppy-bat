using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perch : MonoBehaviour
{
    private bool scrolling = false;

    void Update()
    {
        if (GameController.instance.jumped && !scrolling)
        {
            StartCoroutine(DestroyPerch());
            scrolling = true;
        }
    }

    IEnumerator DestroyPerch()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
