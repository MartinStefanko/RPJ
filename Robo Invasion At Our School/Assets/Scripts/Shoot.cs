using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private AudioSource reloadAudio;

    [SerializeField]
    private float fireRate = 1f;

    private float nextFire = 1f;
    public float magSize = 6;
    public float maxMagSize = 6;

    private bool reloading = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if magazine is empty if so reload
        if (magSize == 0 || (Input.GetKeyDown(KeyCode.R) && magSize != maxMagSize))
        {
            if (!reloadAudio.isPlaying)
                reloadAudio.Play();

            reloading = true;
            Invoke("Reload", 2.5f);
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

        CancelInvoke();

    }
    public void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}
