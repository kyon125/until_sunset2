using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    int count;
    bool ready;
    public GameObject UI, UI1;
    public Text t_load ,t_press;
    public static Loading loading;
    private void Awake()
    {
        loading = this;
        complete();
    }
    void Start()
    {
        Loadscene.loadcontroller.async = SceneManager.LoadSceneAsync(Loadscene.loadcontroller.loadName);
        Loadscene.loadcontroller.async.allowSceneActivation = false;
        
        ui_shine();
    }

    // Update is called once per frame
    void Update()
    {
        if (ready == false && Loadscene.loadcontroller.async.progress >= 0.9f)
        {
            StartCoroutine(waitTocomplete());
            ready = true;
        }
        timer += Time.deltaTime;
        showloading();
    }
    void showloading(float f = 0.3f)
    {
        if (timer >= f && count != 3)
        {
            t_load.text += ".";
            count++;
            timer = 0;
        }
        else if (timer >= f && count == 3)
        {
            t_load.text = "Loading";
            count = 0;
            timer = 0;
        }
    }
    void ui_shine()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(t_press.DOFade(0.2f, 1.5f));
        seq.Append(t_press.DOFade(1, 1.5f));
        seq.SetLoops(-1);
    }
    void complete()
    {
        StartCoroutine(waitTocomplete());
    }
    IEnumerator waitTocomplete()
    {       
        yield return new WaitForSeconds(2f);
        UI.SetActive(false);
        UI1.SetActive(true);
        yield return new WaitUntil(() => Input.anyKeyDown);        
        Loadscene.loadcontroller.async.allowSceneActivation = true;
        Soundcontroller.soundcontroller.playbgm();
    }
}
