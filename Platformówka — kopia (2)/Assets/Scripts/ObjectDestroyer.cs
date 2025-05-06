using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ground, new Vector3(32.1f, -6.129f, 0f), transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Instantiate(ground, new Vector3(30.1f, -6.129f, 0f), transform.rotation);
        }

        Destroy(collision.gameObject, 0f);
    }
}
