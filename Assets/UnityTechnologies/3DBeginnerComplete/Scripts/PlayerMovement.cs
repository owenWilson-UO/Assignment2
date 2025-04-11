using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    private bool hasKey = false;
    public AudioSource unlock;
    public AudioSource keyPickup;
    public AudioSource wallMove;

    public MoveWallDown wall1;
    public MoveWallDown wall2;
    public MoveWallDown wall3;
    public MoveWallDown wall4;

    public ParticleSystem smoke;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
        
        MoveAction.Enable();
    }

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            other.gameObject.SetActive(false);
            keyPickup.Play();
        }

        if (other.gameObject.CompareTag("Unlock") && hasKey)
        {
            other.gameObject.SetActive(false);
            unlock.time = 0.6f;
            unlock.Play();
            Invoke(nameof(StartWallMove), 0.5f);
        }
    }

    private void StartWallMove()
    {
        wall1.move = true;
        wall2.move = true;
        wall3.move = true;
        wall4.move = true;
        smoke.Play();
        wallMove.time = 1.3f;
        wallMove.Play();
        Invoke(nameof(StopAudio), 2f);
    }

    private void StopAudio()
    {
        wallMove.Stop();
    }
}