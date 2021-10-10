using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRender;


    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
  

    void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log("you hit the wall");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage )
        {
            Debug.Log("pack picked up ");
            hasPackage = true;
            spriteRender.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("delivered");
            hasPackage = false;
            spriteRender.color = noPackageColor;
        }
    }

}
