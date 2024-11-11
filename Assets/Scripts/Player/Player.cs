using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data {  get; private set; }

    [field : Header("Animations")]
    [field : SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Anim { get; private set; }
    public CharacterController CharacterController { get; private set; }

    private void Awake()
    {
        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
    }

}
