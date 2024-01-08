using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventroyInputs : MonoBehaviour
{
    public bool openInvent = false;

    public void Inevnt(InputValue value)
    {
        InventInput();
    }

    public void InventInput()
    {
        openInvent = !openInvent;
    }
}
