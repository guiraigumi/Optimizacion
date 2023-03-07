using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        public float speed = 10f; 

        void Update()
        {
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            velocity.z = speed;
            GetComponent<Rigidbody>().velocity = velocity;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        
        if (this.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        this.gameObject.SetActive(false);
        

    }

}







