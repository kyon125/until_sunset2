using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject GM;
    public static GameStatus gameStatus;
    public ArchiveStatus archivestatus;
    public plaeyrStatus plaeyrstatus;
    public Status status;
    public Hurtstatus hurtstatus;
    public MainQuest mainquest;
    public Gametime gametime;
    private void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
        if (GM == null)
        {
            GM = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
        gameStatus = this;
        status = new Status();
        archivestatus = new ArchiveStatus();
        hurtstatus = new Hurtstatus();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            GM.GetComponent<GameStatus>().status = GameStatus.Status.onStart;
        }
        if (plaeyrstatus.life <= 0 && status != GameStatus.Status.onGameover)
        {
            status = GameStatus.Status.onDead;
        }
        goDead();
    }
    void goDead()
    {
        if (status ==GameStatus.Status.onDead)
        {
            status = GameStatus.Status.onGameover;

            Soundcontroller.soundcontroller.stopbgm();
            SceneManager.LoadScene("Gameover");            
        }
    }
    public void lifeController(float f)
    {
        if (f > 0)
        {
            for (int i = 0; i < f; i++)
            {
                if (plaeyrstatus.life < plaeyrstatus.maxlife)
                    plaeyrstatus.life++;
            }
        }
        else if (f < 0)
        {
            for (int i = 0; i < Mathf.Abs(f); i++)
            {
                if (plaeyrstatus.life > 0)
                    plaeyrstatus.life--;
            }

        }        
        //statusShow.statusUI.showlife();
    }
    public void endurationController(int f)
    {
        if (f > 0)
        {
            for (int i = 0; i < f; i++)
            {
                if(plaeyrstatus.endurance < plaeyrstatus.maxendurance)
                plaeyrstatus.endurance++;
            }
        }
        else if (f < 0)
        {
            for (int i = 0; i <Mathf.Abs(f); i++)
            {
                if (plaeyrstatus.endurance > 0)
                    plaeyrstatus.endurance--;
            }
            
        }        
        //statusShow.statusUI.showlife();
    }
    public void energyController(int f)
    {
        if (f > 0)
        {
            for (int i = 0; i < f; i++)
            {
                if (plaeyrstatus.energy < plaeyrstatus.maxenergy)
                    plaeyrstatus.energy++;
            }
        }
        else if (f < 0)
        {
            for (int i = 0; i < Mathf.Abs(f); i++)
            {
                if (plaeyrstatus.energy > 0)
                    plaeyrstatus.energy--;
            }

        }
        //statusShow.statusUI.showlife();
    }
    public void intialplayer()
    {
        plaeyrstatus.life = 5;
        plaeyrstatus.endurance = 5;
        plaeyrstatus.energy = 0;
    }

    public enum Status
    {
        onPlaying,
        onMenu,
        onBaging,
        onComposition,
        onPloting,
        onSetting,
        onQuestchoose,
        onQuestlist,
        onDead,
        onGameover,
        onSaving,
        onLoading,
        onBowing,
        onRope,
        onStart
    }
    public enum MainQuest
    {
        Viliage1,
        Viliage2,
        well0,
        well1,
        well2,
        well3,
        well4,
        well5,
        well6,
        wellend,
        frost1,
        frost2,
        Viliage3,
    }
    public enum ArchiveStatus
    { 
        isNew,
        isLoad
    }
    public enum Hurtstatus
    {
        isnormal,
        ishurt        
    }
    public enum Gametime
    {
        morning = 0,
        evening = 1,
        night = 2
    }
    [System.Serializable]
    public class plaeyrStatus
    {
        public float life;
        public float maxlife;
        public int endurance;
        public int maxendurance;
        public int energy;
        public int maxenergy;
        public Vector3 pos;
    }
    
}
