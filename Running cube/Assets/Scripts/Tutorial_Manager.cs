using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Manager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject introductionPanel;
    //[SerializeField] private GameObject movementPanel;
    [SerializeField] private Canvas tutorialCanvas;

    private Image image;
    private Animator animator;

    private bool once = true;
    private float tutorialDelay = 1.5f;

    // Update is called once per frame

    private void Start()
    {
        image = backgroundPanel.GetComponent<Image>();
        animator = backgroundPanel.GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(animator.GetCurrentAnimatorStateInfo(1).normalizedTime);
        if (IsAnimationFinished(tutorialDelay) && AnimationName("Tutorial_1"))
        {
            animator.SetBool("fade", false);
            backgroundPanel.transform.Find("Introduction").gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
        
        if (IsAnimationFinished(tutorialDelay + 1f) && AnimationName("Tutorial_2")) 
        {
            animator.SetBool("fade", false);
            animator.SetBool("tutorial2", false);
            image.enabled = false;
            Time.timeScale = 1f;
        }

        if (IsAnimationFinished(tutorialDelay + 1f) && AnimationName("Tutorial_3_Jump"))  
        {
            animator.SetBool("fade", false);
            animator.SetBool("tutorial3", false);
            image.enabled = false;
            Time.timeScale = 1f;
        }

        if (IsAnimationFinished(tutorialDelay + 1f) && AnimationName("Tutorial_4"))
        {
            animator.SetBool("fade", false);
            animator.SetBool("tutorial3", false);
            image.enabled = false;
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Tutorial_1" && once)
        {
            tutorialCanvas.gameObject.SetActive(true);
            animator.SetBool("tutorial1", true);
            Time.timeScale = 0f;
            once = false;
        }

        if (collider.name == "Tutorial_2" && !once)
        {
            animator.SetBool("fade", true);
            animator.SetBool("tutorial2", true);
            //onceTutorial2 = false;
            image.enabled = true;
            Time.timeScale = 0f;
            once = true;
        }

        if (collider.name == "Tutorial_3" && once)
        {
            image.enabled = true;
            animator.SetBool("fade", true);
            animator.SetBool("tutorial3", true);
            once = false;
            Time.timeScale = 0f;
        }

        if (collider.name == "Tutorial_4" && !once)
        {
            image.enabled = true;
            animator.SetBool("fade", true);
            animator.SetBool("tutorial4", true);
            Time.timeScale = 0f;
        }
    }

    public bool IsAnimationFinished(float delay)
    {
        return animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= delay;
    }

    public bool AnimationName(string name)
    {
        return animator.GetCurrentAnimatorStateInfo(1).IsName(name);
    }
}
