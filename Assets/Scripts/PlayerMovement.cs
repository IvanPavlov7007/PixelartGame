using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO should I get rid of that???
public class PlayerMovement : MonoBehaviour
{
    public CharacterMovement characterMovement;

    // Singletone pattern
    private static PlayerMovement instance;
    public static PlayerMovement Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if(characterMovement == null)
            characterMovement= GetComponent<CharacterMovement>();
    }

    void Update()
    {
        characterMovement.direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
    }
}
