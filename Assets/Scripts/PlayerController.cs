using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; 
    public float minX = -5f; 
    public float maxX = 5f;

    public GameObject bulletPrefab;
    public Transform gunPosition;
    public int ammoType;
    // Update is called once per frame
    void Update()
    {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = PoolManager_bullet.Instance.GetPooledObjects(ammoType, gunPosition.position, gunPosition.rotation);
            bullet.SetActive(true);
        }
    }
}


