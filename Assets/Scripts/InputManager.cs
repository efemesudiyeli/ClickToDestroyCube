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
            //TODO Buraya if(!TryGetComponent) return; diyerek hata almanın önüne geçebilirsin
            //TODO Bulamıyorsa işlem yapmasın, yukarıdaki rayi de buradaki if'in içine eklersen && ile
            //TODO Kodunu yarıya indirmiş olursun
            hit.collider.gameObject.TryGetComponent<CubeScript>(out CubeScript cube);
            cube.Click();
        }
    }
}
