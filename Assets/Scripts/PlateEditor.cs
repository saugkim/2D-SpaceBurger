using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class PlateEditor : MonoBehaviour
{

    // Use this for initialization
    public InputField input;
    public GameObject menuREF;
    public MenuRefrence menu;

    public List<int> stack;
    public int BurgerSize;
    public GameObject burgerTemplate;
    public string burgerName;
    void Start()
    {
        menu = menuREF.GetComponent<MenuRefrence>();
        input.text = "name";

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void resetBurger()
    {
        BurgerSize = 0;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

    public void sendBurger()
    {

        Hampurilanen burgeri = ScriptableObject.CreateInstance<Hampurilanen>();
        Debug.Log("Initiated burger");
        List<int> tempStack = stack;
        burgeri.Ingredients = tempStack;
        Debug.Log("added stack");
        burgerName = input.text;
        burgeri.name = burgerName;
        Debug.Log("named burger");
#if UNITY_EDITOR
        AssetDatabase.CreateAsset(burgeri, "assets/Scripts/Burgers/" + burgerName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif
        Debug.Log("Made burgerFile");
        resetBurger();


    }

    public void addLayer(int aines)
    {
        if (stack.Count == 0 && aines == 0)
        {
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if (stack.Count > 0 && aines != 5)
        {
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if (stack.Count > 0)
        {
            ShowBurger(aines);
            sendBurger();
        }

    }
    private void ShowBurger(int aines)
    {
        if (aines >= 0)
        {
            GameObject x = Instantiate(burgerTemplate, gameObject.transform.position + new Vector3(0, BurgerSize * 0.1f, 0), Quaternion.identity);
            x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[aines].Kuva;
            BurgerSize++;
            x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(BurgerSize) + 1;
            x.transform.parent = gameObject.transform;
        }

    }

}
