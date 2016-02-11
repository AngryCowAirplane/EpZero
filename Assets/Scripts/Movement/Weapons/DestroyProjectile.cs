using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {
    public float lifeTime;
    public GameObject hitEffect;
    public GameObject points;
    public int damage;
    public float dmgMultiplier;
    private GameObject owner;

	// Use this for initialization
	void Start () {
        // Destroy this object after a certain lifetime
        Destroy(this.gameObject, lifeTime);
	}

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }

    public GameObject getOwner()
    {
        return owner;
    }
	
	void OnCollisionEnter2D(Collision2D other)
    {
        // Create a collision Effect
        GameObject hit = (GameObject)Instantiate(hitEffect, this.gameObject.transform.position, Quaternion.identity);
        Destroy(hit, 0.22f);

        if ((other.gameObject.tag != "Player") && (other.gameObject.tag != "SpellCollider"))
        {
            if (other.gameObject.tag == "Enemy")
            {
                float multiplier = dmgMultiplier * owner.GetComponent<PlayerClass>().GetLevel();

                // If player is enemy then take away 10 hitpoints
                other.gameObject.GetComponent<CharClass>().SetHitPoints(-(damage + ((int)(multiplier * damage))));

                // Create a hitpoint text above enemies head, and set it to new hitpoints
                GameObject pointsDisplay = (GameObject)Instantiate(points, other.gameObject.transform.position, Quaternion.identity);
                Destroy(pointsDisplay, 1);
                pointsDisplay.GetComponent<TextMesh>().text = other.gameObject.GetComponent<CharClass>().GetHitPoints().ToString();

                // Destroy other object if its hitpoints are gone
                if (other.gameObject.GetComponent<CharClass>().GetHitPoints() < 1)
                {
                    Destroy(other.gameObject);
                    // Add experience to player
                    owner.GetComponent<PlayerClass>().SetExperience(10);
                }
            }
            
            // Destroy this colliding object
            Destroy(this.gameObject);
        }
    }
}
