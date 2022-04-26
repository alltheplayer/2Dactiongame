using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScence : MonoBehaviour
{
    private static AttackScence instance;
    public AnimationCurve showCurse;
    public AnimationCurve hideCurse;
    public float animationspeed;




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

    public void Showpanel(GameObject gameObject)
    {
        StartCoroutine(ShowPanel(gameObject));
    }

    public void hidepanel(GameObject gameObject)
    {
        StartCoroutine(hidePanel(gameObject));
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

    IEnumerator ShowPanel(GameObject gameobject)
    {
        float timer = 0;
        while(timer<=1)
        {   
            RectTransform rect=gameobject.GetComponent<RectTransform>();
            rect.localScale=Vector3.one*showCurse.Evaluate(timer);
            timer += Time.deltaTime * animationspeed;
            yield return null;  
        }
    }

    IEnumerator hidePanel(GameObject gameobject)
    {
        float timer = 0;
        while (timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one * hideCurse.Evaluate(timer);
            timer += Time.deltaTime * animationspeed;
            yield return null;
        }
    }


}
