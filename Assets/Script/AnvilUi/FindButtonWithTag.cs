using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindButtonWithTag : MonoBehaviour
{
    [SerializeField] GameObject children;

    public GameObject AcceptButton()
    {
        return children;
    }
}
