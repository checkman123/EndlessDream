using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShot; 

    private float shotTime;

    void Update()
    {
        //For rotate the weapon
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //mouse postion, weap direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;


        if (Input.GetMouseButton(0)) {
            if(Time.time >= shotTime) {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                shotTime = Time.time + timeBetweenShot; //how much time need to pass to shoot another one

            }
        }

    }
}
