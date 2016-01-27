using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour
{
    public float startOffset;
    private static Vector3 playerFacing;
    Animator animation;

    public KeyCode MouseFire1;
    public KeyCode MouseFire2;
    public float Spell_1_speed;
    public KeyCode Spell_1_triggerKey;
    public GameObject Spell_1_projectileType;
    public float Spell_2_speed;
    public KeyCode Spell_2_triggerKey;
    public GameObject Spell_2_projectileType;
    public float Spell_3_speed;
    public KeyCode Spell_3_triggerKey;
    public GameObject Spell_3_projectileType;
    public float Spell_4_speed;
    public KeyCode Spell_4_triggerKey;
    public GameObject Spell_4_projectileType;
    public float Spell_5_speed;
    public KeyCode Spell_5_triggerKey;
    public GameObject Spell_5_projectileType;

    enum MagicProjectile
    {
        MagicMissile,
        FireBall,
        IceBall,
        FireWind,
        NewSpell
    };

    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Mouse Fire
        if (Input.GetKeyDown(MouseFire1))
        {
            // Shoot at mouse position
            Shoot(mousePosition, MagicProjectile.MagicMissile);
        }

        if (Input.GetKeyDown(MouseFire2))
        {
            // Shoot at mouse position
            Shoot(mousePosition, MagicProjectile.FireBall);
        }

        // Keyboard Fire
        if (Input.GetKeyDown(Spell_1_triggerKey))
        {
            // Shoot at mouse position
            Shoot(mousePosition, MagicProjectile.MagicMissile);
        }

        if (Input.GetKeyDown(Spell_2_triggerKey))
        {
            // Shoot at mouse position
            Shoot(mousePosition, MagicProjectile.FireBall);
        }

        if (Input.GetKeyDown(Spell_3_triggerKey))
        {
            // Shoot at mouse position
            Shoot(mousePosition, MagicProjectile.IceBall);
        }

        if (Input.GetKeyDown(Spell_4_triggerKey))
        {
            // Shoot at mouse position
            Shoot(mousePosition, MagicProjectile.FireWind);
        }

        if (Input.GetKeyDown(Spell_5_triggerKey))
        {
            // Shoot at mouse position
            Shoot(mousePosition, MagicProjectile.NewSpell);
        }
    }

    void Shoot(Vector3 targetPosition, MagicProjectile type)
    {
        // get players coordinates
        Vector3 playerPosition = (transform.position);  //Camera.main.WorldToScreenPoint
        playerPosition.z = 0.0f;
        targetPosition.z = 0.0f;

        // determine direction of shooting
        Vector3 projectileDirection = (targetPosition - playerPosition).normalized;
        projectileDirection.z = 0;

        // calculate offset for projectile from player
        var projectileOffset = (targetPosition - transform.position).normalized * (startOffset + transform.GetComponent<CircleCollider2D>().radius);
        if (projectileOffset.y < 0)
            projectileOffset.y -= startOffset;

        // Face player towards target
        animation.SetFloat("input_x", projectileOffset.normalized.x);
        animation.SetFloat("input_y", projectileOffset.normalized.y);

        // create projectile
        GameObject projectile;
        Vector3 projectileStartPosition = playerPosition + projectileOffset;

        switch (type)
        {
            case MagicProjectile.MagicMissile:
                projectile = (GameObject)Instantiate(Spell_1_projectileType, projectileStartPosition, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileDirection.x * Spell_1_speed, projectileDirection.y * Spell_1_speed);
                break;

            case MagicProjectile.FireBall:
                projectile = (GameObject)Instantiate(Spell_2_projectileType, projectileStartPosition, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileDirection.x * Spell_2_speed, projectileDirection.y * Spell_2_speed);
                break;

            case MagicProjectile.IceBall:
                projectile = (GameObject)Instantiate(Spell_3_projectileType, projectileStartPosition, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileDirection.x * Spell_3_speed, projectileDirection.y * Spell_3_speed);
                break;

            case MagicProjectile.FireWind:
                projectile = (GameObject)Instantiate(Spell_4_projectileType, projectileStartPosition, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileDirection.x * Spell_4_speed, projectileDirection.y * Spell_4_speed);
                break;

            case MagicProjectile.NewSpell:
                projectile = (GameObject)Instantiate(Spell_5_projectileType, projectileStartPosition, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileDirection.x * Spell_5_speed, projectileDirection.y * Spell_5_speed);
                break;

            default:
                break;
        }
    }
}