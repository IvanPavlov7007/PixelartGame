using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterMovement
{
    float speed { get; set; }

    Vector3 direction { get; set; }
}
