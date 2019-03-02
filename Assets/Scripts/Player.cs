using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    static Player instance = null;

    public List<Gear> subMarinGear = new List<Gear>();
    public Gear armor = null;
    public Gear energy = null;
    public Gear storage = null;
    public Gear taser = null;
    public Gear propulseur = null;

    public Inventory inventory = new Inventory();

    float x = 0f;
    float y = 0f;

    public Camera cam;
    public GameObject extractor;
    public ProgressControlV3D effect;
    bool extract = false;
    bool triggerExtract = false;

    private RessourceObj currentMineral = null;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChange;

        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
        subMarinGear.Add((Gear)Manager.gearsFactory.objs[(int)GearsFactory.ID.ARMOR]);
        subMarinGear.Add((Gear)Manager.gearsFactory.objs[(int)GearsFactory.ID.BATTERY]);
        subMarinGear.Add((Gear)Manager.gearsFactory.objs[(int)GearsFactory.ID.STOCKAGE]);
        subMarinGear.Add((Gear)Manager.gearsFactory.objs[(int)GearsFactory.ID.TASER]);
        subMarinGear.Add((Gear)Manager.gearsFactory.objs[(int)GearsFactory.ID.PROPULSEUR]);

        inventory.Start();
    }

    public bool UpgradeGear(string gearName)
    {
        foreach (Gear gear in subMarinGear)
            if (gear.objectName == gearName && gear.CanBeUpgrade())
            {
                if (!inventory.ContainPreRequis(gear.GetGearUpgradePrerequis()))
                    return false;
                inventory.ConsumeRessource(gear.GetGearUpgradePrerequis());
                gear.Upgrade();
            }
        return true;
    }

    public void Update()
    {
        inventory.GetUI();
        transform.position += transform.right * Input.GetAxis("Horizontal") * 20 * Time.deltaTime;
        transform.position += transform.forward * Input.GetAxis("Vertical") * 20 * Time.deltaTime;

        x -= Input.GetAxis("Mouse Y") * 20 * Time.deltaTime;
        y += Input.GetAxis("Mouse X") * 20 * Time.deltaTime;

        transform.eulerAngles = new Vector3(x, y, 0.0f);

        ExtractRessources();
    }

    public void ExtractRessources()
    {
        RaycastHit hit;

        extract = false;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                RessourceObj obj = hit.collider.gameObject.GetComponent<RessourceObj>();

                if ((obj == null || obj != currentMineral) && currentMineral != null)
                    currentMineral.TakeDamage(false ,this);
                currentMineral = obj;
                if (currentMineral != null)
                    currentMineral.TakeDamage(true, this);
                extractor.transform.LookAt(hit.point);
                extract = true;
            }
            else if (currentMineral != null)
            {
                currentMineral.TakeDamage(false, this);
                currentMineral = null;
            }
        }
        else if (currentMineral != null)
            currentMineral.TakeDamage(false, this);
        triggerExtract = Input.GetMouseButtonDown(0) && extract;

        effect.extract = extract;
        effect.triggerExtract = triggerExtract;
    }

    private void OnSceneChange(Scene current, Scene next)
    {
        inventory.inventoryUI = null;
        if (next.name == "UpgradeScene")
            extractor.SetActive(false);
        else
            extractor.SetActive(true);
    }
}
