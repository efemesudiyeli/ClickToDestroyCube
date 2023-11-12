using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            hit.collider.gameObject.TryGetComponent<CubeScript>(out CubeScript cube);
            cube.Click();
        }
    }
}
