using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField]
    float destroyDelay = 0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

     void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Daaaam"); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Packages") && !hasPackage) 
        {
            Debug.Log("Package has been picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);      }
        if (other.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Pakeage recived to Customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }

}
