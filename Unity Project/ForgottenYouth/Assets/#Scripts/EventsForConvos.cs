using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventsForConvos : MonoBehaviour {

    public RaycastHit hit;

    public ParticleSystem photoParticle;

    public ParticleSystem razorParticle;

    public ParticleSystem walletParticle;

    public ParticleSystem perfumeParticle;

    public ParticleSystem vaseParticle;

    public bool hasGottenNearHouse = false;

    public bool hasPhoto = false;

    public bool hasRazor = false;

    public bool hasWallet = false;

    public bool hasPerfume = false;

    public bool hasVase = false;

    public bool hasCollapse = false;

    public Transform cam;

    public LayerMask photo;

    public LayerMask razor;

    public LayerMask wallet;

    public LayerMask perfume;

    public LayerMask vase;

    public AudioClip seeHouseStandAudio;

    public AudioClip photoAudio;

    public AudioClip razorAudio;

    public AudioClip walletAudio;

    public AudioClip perfumeAudio;

    public AudioClip vaseAudio;

    public AudioClip houseCollapseAudio;

    private AudioSource audioPlayer;

    public Rect screenPos;

    private float timer = 10;

    public GameObject house;

    public GameObject collapsedHouse;

    public Vector3 houseOriginalPosition;

    void Start()
    {

        razorParticle.Stop();
        walletParticle.Stop();
        perfumeParticle.Stop();
        vaseParticle.Stop();


        screenPos = new Rect(Screen.width/2 - 100, Screen.height / 2 - 11.5f, 200, 23);

        audioPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hasPhoto)
                Photo();
            else if (!hasRazor)
                Razor();
            else if (!hasWallet)
                Wallet();
            else if (!hasPerfume)
                Perfume();
            else if (!hasVase)
                Vase();
            else
            {

            }
        }

        if(timer <= 0)
        {
            Application.LoadLevel(3);
        }

        if(hasCollapse == true)
        {
            timer -= Time.deltaTime;
        }

        if (Time.timeScale == 0)
        {
            audioPlayer.Pause();
        }
        
        if (Time.timeScale == 1)
        {
            audioPlayer.UnPause();
        }

    }

    public void Photo()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 10, photo))
        {
            print(hit.collider.gameObject.name);

            hasPhoto = true;
            razorParticle.Play();
            photoParticle.Pause();
            photoParticle.transform.position = new Vector3(0,-100,0);

            audioPlayer.clip = photoAudio;

            audioPlayer.Play();
        }
    }

    public void Razor()
    {

        if (Physics.Raycast(cam.position, cam.forward, out hit, 10, razor))
        {
            print(hit.collider.gameObject.name);

            hasRazor = true;
            walletParticle.Play();
            razorParticle.Pause();
            razorParticle.transform.position = new Vector3(0, -100, 0);
            audioPlayer.clip = razorAudio;
            audioPlayer.Play();
        }

    }

    public void Wallet()
    {

        if (Physics.Raycast(cam.position, cam.forward, out hit, 10, wallet))
        {
            print(hit.collider.gameObject.name);

            hasWallet = true;
            perfumeParticle.Play();
            walletParticle.Pause();
            walletParticle.transform.position = new Vector3(0, -100, 0);
            audioPlayer.clip = walletAudio;
            audioPlayer.Play();
        }

    }

    public void Perfume()
    {

        if (Physics.Raycast(cam.position, cam.forward, out hit, 10, perfume))
        {
            print(hit.collider.gameObject.name);

            hasPerfume = true;
            vaseParticle.Play();
            perfumeParticle.Pause();
            perfumeParticle.transform.position = new Vector3(0, -100, 0);
            audioPlayer.clip = perfumeAudio;
            audioPlayer.Play();
        }

    }

    public void Vase()
    {

        if (Physics.Raycast(cam.position, cam.forward, out hit, 10, vase))
        {
            print(hit.collider.gameObject.name);

            hasVase = true;
            vaseParticle.Pause();
            vaseParticle.transform.position = new Vector3(0, -100, 0);

            audioPlayer.clip = vaseAudio;

            audioPlayer.Play();
        }

    }

    public void OnTriggerEnter(Collider other)
    {

        if(!hasGottenNearHouse)
        {
            hasGottenNearHouse = true;
            audioPlayer.clip = seeHouseStandAudio;
            audioPlayer.Play();
            
        }

        if (hasVase && !hasCollapse)
        {
            houseOriginalPosition = new Vector3(house.transform.position.x - 6, house.transform.position.y + 8, house.transform.position.z + 13);
            
            hasCollapse = true;
            house.transform.position = new Vector3(0, -1100, 0);
            collapsedHouse.transform.position = houseOriginalPosition;
            audioPlayer.clip = houseCollapseAudio;
            audioPlayer.Play();
        }

    }

    public void OnGUI()
    {

        if (Physics.Raycast(cam.position, cam.forward, out hit, 10, photo) && !hasPhoto)
        {

            GUI.Box(screenPos, "Press E to Interact");
            
        }
        else if (Physics.Raycast(cam.position, cam.forward, out hit, 10, razor) && !hasRazor && hasPhoto)
        {

            GUI.Box(screenPos, "Press E to Interact");

        }
        else if (Physics.Raycast(cam.position, cam.forward, out hit, 10, wallet) && !hasWallet && hasPhoto && hasRazor)
        {

            GUI.Box(screenPos, "Press E to Interact");

        }
        else if (Physics.Raycast(cam.position, cam.forward, out hit, 10, perfume) && !hasPerfume && hasPhoto && hasRazor && hasWallet)
        {

            GUI.Box(screenPos, "Press E to Interact");

        }
        else if (Physics.Raycast(cam.position, cam.forward, out hit, 10, vase) && !hasVase && hasPhoto && hasRazor && hasWallet && hasPerfume)
        {

            GUI.Box(screenPos, "Press E to Interact");

        }

    }
}
