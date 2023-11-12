using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] Cube_SO _cubeScriptableObjectData;
    public static int _clickAmountToDestroy;
    public static event Action OnDestroyed;
    public static event Action OnClick;

    private void Awake()
    {
        _clickAmountToDestroy = _cubeScriptableObjectData.cubeClickAmountToDestroy;
    }

    public void Click()
    {
        if (_clickAmountToDestroy <= 1)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.DOScale(0, _cubeScriptableObjectData.cubeDestroyAnimationTime).OnComplete(() =>
            {
                Destroy(gameObject);
                OnDestroyed?.Invoke();
            });
        }
        else
        {
            transform.DOShakeScale(0.5f, 0.2f);
            _clickAmountToDestroy -= 1;
        }

        OnClick?.Invoke();
    }


}
