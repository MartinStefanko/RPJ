using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireForce;
    [SerializeField]
    private AudioSource gunShotAudio;
    [SerializeField]
    public AudioSource reloadAudio;

    [SerializeField]
    private float fireRate = 1f;

    private float nextFire = 1f;
    public float magSize = 6;
    public float maxMagSize = 6;

    private bool reloading = false;

    [SerializeField]
    private GameObject reloadBar;

    ReloadProgressBar rb;
    private bool shouldReset = true;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if magazine is empty if so reload
        if (magSize == 0 || (Input.GetKeyDown(KeyCode.R) && magSize != maxMagSize))
        {
            

            reloading = true;
            reloadBar.SetActive(true);
            if (shouldReset)
            {
                if (!reloadAudio.isPlaying)
                    reloadAudio.Play();

                rb = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ReloadProgressBar>();
                rb.Reset();
            }
            shouldReset = false;
            Invoke("Reload", 3f);
        }

        if (!GameController.isPaused && !GameController.shopIsOpened && !GameController.isDead && DialogueNPC.dialogueOver)
        {
            // Check if LMB is being pressed and timer to avoid rapid shooting
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire && magSize > 0 && !reloading)
            {
                anim.SetTrigger("Shoot");
                Fire();
                gunShotAudio.Play();
                GameController.instance.UpdateAmmoTXT();
            }

        }
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;

        magSize--;

        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);

        UtilsClass.ShakeCamera(0.02f, 0.1f);


    }

    void Reload()
    {
        magSize = maxMagSize;
        GameController.instance.UpdateAmmoTXT();
        reloading = false;
        shouldReset = true;
        reloadBar.SetActive(false);
        CancelInvoke();

    }
    public void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}
