using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Countdown : MonoBehaviour
{

    [SerializeField] int duration;
    [SerializeField] bool test = false;
    bool isCounting;
    

    public UnityEvent OnCountFinished = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();


    private void Start() 
    {
        StartCoroutine(CountCoroutine()); 
    }


    //  Countdown saat awal start 
    public void StartCount()
    {
    
        if (isCounting == true)
        {
            StopAllCoroutines();
        }
        //  Cara pemanggilan coroutine
        StartCoroutine(CountCoroutine());
    }


    //  Contoh dari Coroutine
    private IEnumerator CountCoroutine()
    {
        isCounting = true;
        for (int i = duration; i >= 0 ; i--)
        {
            OnCount.Invoke(i);
            yield return new WaitForSecondsRealtime(1);
        }
        isCounting = false;
        OnCountFinished.Invoke();
    }



    // //  Countdown saat awal start menggunakan DOTween tidak memanggil ulang
    // public void StartCount()
    // {

    //     if (isCounting == true)
    //     {
    //         return;
    //     }
    //     else
    //     {
    //         isCounting = true;
    //     }

    //     seq = DOTween.Sequence(); //TODO bug
        
    //     OnCount.Invoke(duration);

    //     for (int i = duration - 1; i >= 0; i--)
    //     {
    //         var count = i;
    //         seq.Append(transform
    //             .DOMove(this.transform.position, 1)
    //             .SetUpdate(true)
    //             .OnComplete(() => OnCount.Invoke(count)));

    //     }

    //     seq.Append(transform
    //         .DOMove(this.transform.position, 1))
    //         .SetUpdate(true)
    //         .OnComplete(() => 
    //         {
    //             isCounting = false;
    //             OnCountFinished.Invoke();
    //         });
    // }
}
