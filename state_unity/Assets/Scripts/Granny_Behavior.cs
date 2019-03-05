using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FishState { CAUGHT, FLOATING, LOST, EATEN };
public class Granny_Behavior : MonoBehaviour
{

    // Use this for initialization
    public static FishState fish_st = FishState.CAUGHT;

    public GameObject salmon, roundfish, willfish;
    public bool firstRoundFishMove = false;
    private Vector3 initialSalmonPos;
    private Vector3 finalFirstRoundSalmonPos;
    public float startFirstRoundMouthTime;
    // Total distance between the markers.
    private float journeyFirstRoundLength;

    public Transform cm;


    public ParticleSystem grannyBreath;
    public ParticleSystem fireworks;

    public AudioSource grannyHunt;
    public AudioSource grannyCallUser;
    public AudioSource grannyBubbleSound;
    public AudioSource celebration;
    public AudioSource chewing;



    Animator aniamtor;
    readonly int lookHash = Animator.StringToHash("lookat");
    readonly int endloonkHash = Animator.StringToHash("look_end");
    readonly int gofishHash = Animator.StringToHash("fish_trigger");
    readonly int wave = Animator.StringToHash("sayHi_trigger");
    readonly int clap_t = Animator.StringToHash("clap_trigger");
    readonly int  eat_t = Animator.StringToHash("eat_fish_trigger");
    readonly int nudge_again = Animator.StringToHash("nudge_fish_trigger");
    float interim_time;
    bool isforward = false, checkfish = false;
    int givefishCount = 0;
    void Start()
    {
        aniamtor = GetComponent<Animator>();
        interim_time = 4f;
        grannyHunt.Stop();
        grannyBreath.Stop();
        grannyCallUser.Stop();
        grannyBubbleSound.Stop();
        fireworks.Stop();
        salmon.SetActive(false);
        roundfish.SetActive(false);
        willfish.SetActive(false);
        initialSalmonPos = salmon.transform.position;
        finalFirstRoundSalmonPos = new Vector3((float)0.174, (float)-0.237, (float)-3.75);
        journeyFirstRoundLength = Vector3.Distance(initialSalmonPos, finalFirstRoundSalmonPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (isforward)
        {
            transform.position = Vector3.Lerp(transform.position, cm.position, Time.deltaTime*0.25f);
            if (transform.position == cm.position)
                isforward = false;
        }

        if(checkfish)
        {
            Debug.Log("is fish eaten");
            //checkstate of fish
        }

        // make the first round fish move
        if (firstRoundFishMove)
        {
            firstRoundMove();
        }

    }

    private void firstRoundMove()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startFirstRoundMouthTime) * 1;
        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyFirstRoundLength;

        // Set our position as a fraction of the distance between the markers.
        salmon.transform.position = Vector3.Lerp(initialSalmonPos, finalFirstRoundSalmonPos, Time.deltaTime*0.25f);
        Debug.Log(salmon.transform.position);

        if (salmon.transform.position == finalFirstRoundSalmonPos)
        {
            firstRoundFishMove = false;
        }
    }

    public void LookAt()
    {
        aniamtor.SetBool(lookHash, true);
    }
    public void IdleDown2_branch()
    {
        //this branch is waiting on the user to eat the fist -story part1
        StartCoroutine("Nudge_Fish");
        checkfish = true;
    }

    IEnumerator Nudge_Fish()
    {
        Debug.Log("waiting for fish to be eaten");
        yield return new WaitForSeconds(4f);
        aniamtor.SetTrigger(nudge_again);
        //move_fish (crashinto player)
    }

    IEnumerator FishIsLost()
    {
        yield return new WaitForSeconds(interim_time + 2f);
        Debug.Log("fish is lost");
        fish_st = FishState.LOST;
        StartCoroutine("GoFish");
    }

    public void LookAway()
    {
        aniamtor.SetTrigger(endloonkHash);
        grannyCallUser.Play();
        aniamtor.SetBool(lookHash, false);
    }

    IEnumerator Clap()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Clap");
        fish_st = FishState.EATEN;
        aniamtor.SetTrigger(clap_t);
    }

    IEnumerator GoFish()
    {
        yield return new WaitForSeconds(1f);
        aniamtor.SetTrigger(gofishHash);
        grannyHunt.Play();
        fish_st = FishState.CAUGHT;
    }
    IEnumerator Wave()
    {
        yield return new WaitForSeconds(3f);
        aniamtor.SetTrigger(wave);
        grannyCallUser.Play();
        StartCoroutine("GoFish");
    }

    public void SwimOver()
    {
        isforward = true;
        Debug.Log("forward");
        grannyBreath.Play();
        grannyBubbleSound.Play();
        StartCoroutine("Wave");
    }

    public void EatenAndCelebration()
    {
        celebration.Play();
        fireworks.Play();
    }

    
}
