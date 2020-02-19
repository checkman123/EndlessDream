using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed; //how fast
    public float lifeTime; //how long before destroy

    public GameObject explosion;

    public int damage;

    private void Start() {
        
        Invoke("DestroyProjectile", lifeTime); //Destroy(gameObject, lifeTime);  Similar

    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);   //vector2.up is forward
    }

    void DestroyProjectile() {
        Instantiate(explosion, transform.position, Quaternion.identity); //what are (spawning, position, rotation)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy") {
            collision.GetComponent<Enemy>().takeDamage(damage);
            DestroyProjectile();
        }
    }


}
