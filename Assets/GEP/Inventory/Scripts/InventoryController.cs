using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InventoryController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InventroyInputs _input;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<InventroyInputs>();
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenInvent();
    }
    private void OpenInvent()
    {
        gameObject.SetActive(_input.openInvent);
    }
}
