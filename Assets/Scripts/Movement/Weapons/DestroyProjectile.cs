using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {
    public float lifeTime;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, lifeTime);
	}
	
	void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Object Collided with: " + other.gameObject.ToString());

        if ((other.gameObject.tag != "Player") && (other.gameObject.tag != "SpellCollider"))
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
            }
            
            Debug.Log("Object collided with non Player");
            Destroy(this.gameObject);
        }
    }
}
