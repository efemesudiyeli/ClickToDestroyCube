using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
//TODO Scriptin ismi direkt Cube olabilir, script koymayalım olduğunca isimlere
public class CubeScript : MonoBehaviour
{
    //TODO Bu da direkt CubeSO olabilr, aradaki alt tireye gerek yok bence
    [SerializeField] Cube_SO _cubeScriptableObjectData;
    public static int _clickAmountToDestroy;
    //TODO Event isimlendirmelerini ben eklememişim code convention'a ama söylemiş olayım, bunların da ismine event koyabiliriz belki
    //TODO Kötü bir isimlendirme değil, sadece söylemiş olayım, öyle devam ederiz
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
            //TODO Gayet güzel çözmüşsün çıkabilecek bug'ı burada
            gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.DOScale(0, _cubeScriptableObjectData.cubeDestroyAnimationTime).OnComplete(() =>
            {
                Destroy(gameObject);
                OnDestroyed?.Invoke();
            });
        }
        else
        {
            //TODO Tweenlerde boyutlarının değişmemesini istiyorsan her tweenden önce bir sıfırlayabilirsin değiştirdiklerini
            //TODO Veya bu tweeni Tween tween = diyerek kaydedip sonra tweeni geri alabiliyorsun tween.Rewind() diyerek. Veya Kill diyerek öldürebiliyorsan
            //TODO Gibi gibi
            
            
            Tween tween =  transform.DOShakeScale(0.5f, 0.2f);
            _clickAmountToDestroy -= 1;
        }

        OnClick?.Invoke();
    }


}
