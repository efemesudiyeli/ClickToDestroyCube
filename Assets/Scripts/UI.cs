using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _clickLeftText;

    private void OnEnable()
    {
        CubeScript.OnClick += UpdateClickLeftText;
        CubeSpawner.OnSpawn += UpdateClickLeftText;
    }

    private void OnDisable()
    {
        CubeScript.OnClick -= UpdateClickLeftText;
        CubeSpawner.OnSpawn -= UpdateClickLeftText;
    }

    private void UpdateClickLeftText()
    {
        _clickLeftText.text = CubeScript._clickAmountToDestroy.ToString();
    }
}
