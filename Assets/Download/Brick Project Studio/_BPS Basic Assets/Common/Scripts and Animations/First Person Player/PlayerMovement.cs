using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class PlayerMovement : MonoBehaviour
    {

        public CharacterController controller;

        public float speed = 5f;
        public float gravity = -15f;

        Vector3 velocity;

        bool isGrounded;
        private AudioSource audioSource;
        private bool IsMoving;
 
        void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetAxis("Vertical") != 0) IsMoving = true; // better use != 0 here for both directions
            else IsMoving = false;
 
            if (IsMoving && !audioSource.isPlaying) audioSource.Play(); // if player is moving and audiosource is not playing play it
            if (!IsMoving) audioSource.Stop(); // if player is not moving and audiosource is playing stop it
        
            
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        }
    }
}