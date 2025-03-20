using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresentatorSide : Representator
{
    public List<SideRepresentation> sideRepresentations = new List<SideRepresentation>();
    public override IEnumerable<Representation> representations { get => sideRepresentations; }
}
