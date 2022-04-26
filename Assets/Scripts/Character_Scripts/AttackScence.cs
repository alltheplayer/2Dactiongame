using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScence : MonoBehaviour
{
    private static AttackScence instance;




    public static AttackScence GetInstance()
    {
        if(instance == null)
        {
            Debug.Log("获取震动实例失败");
            return null;
        }

        return  instance;
    }

    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this.gameObject);
        }
    }


    public bool isShake;

    public void CameraShake(float duration,float strength)
    {
        if(!isShake)
        {
            StartCoroutine(Shake(duration, strength));
        }
    }

     
    public void HitPause(int duration)
    {
        StartCoroutine(Pause(duration));
    }


    IEnumerator Pause(int duration)
    {
       
        float pauseTime = duration / 60f;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1;
    }

    IEnumerator Shake(float duration,float strength)
    {
       
        isShake = true;
        Transform camera = Camera.main.transform;
        Vector3 startPosition=camera.position;

        while(duration>0.01)
        {
            camera.position = Random.insideUnitSphere * strength + startPosition;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.position=startPosition;
        isShake=false;       
    }

  
}
