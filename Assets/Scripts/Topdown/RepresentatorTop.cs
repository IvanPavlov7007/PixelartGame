using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresentatorTop : Representator
{
    public List<TopRepresentation> topRepresentations;
    public override IEnumerable<Representation> representations => topRepresentations;
}
