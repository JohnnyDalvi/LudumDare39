using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(UIEditorController))]
public class UIEditor : EditorWindow
{

    public static Color color1 = Color.grey;
    public static Color color2 = Color.grey;
    public static Color color3 = Color.grey;
    public static Color color4 = Color.grey;
    public static Color color5 = Color.grey;
    public static Color color6 = Color.grey;
    public static Color color7 = Color.grey;
    public static Color color8 = Color.grey;
    public static Color color9 = Color.grey;
    public static Color color10 = Color.grey;
    public static Color color11 = Color.grey;
    public static Color color12 = Color.grey;

    public static float Outline1 = 2;
    public static float Outline2 = 2;
    public static float Outline3 = 2;
    public static float Outline4 = 2;
    public static float Outline5 = 2;
    public static float Outline6 = 2;

    public static string tag1 = "UI Tag1";
    public static string tag2 = "UI Tag2";
    public static string tag3 = "UI Tag3";
    int indexer;


    [MenuItem("Window/UI Editor")]
    static void OpenUIEditor()
    {
        UIEditor myWindow = EditorWindow.GetWindow<UIEditor>(false, "UI Editor");
        myWindow.minSize = new Vector2(900, 150);
    }

    void OnEnable()
    {
        color1 = RetrieveColor(1);
        color2 = RetrieveColor(2);
        color3 = RetrieveColor(3);
        color4 = RetrieveColor(4);
        color5 = RetrieveColor(5);
        color6 = RetrieveColor(6);
        color7 = RetrieveColor(7);
        color8 = RetrieveColor(8);
        color9 = RetrieveColor(9);
        color10 = RetrieveColor(10);
        color11 = RetrieveColor(11);
        color12 = RetrieveColor(12);
        Outline1 = PlayerPrefs.GetFloat("Outline1");
        Outline2 = PlayerPrefs.GetFloat("Outline2");
        Outline3 = PlayerPrefs.GetFloat("Outline3");
        Outline4 = PlayerPrefs.GetFloat("Outline4");
        Outline5 = PlayerPrefs.GetFloat("Outline5");
        Outline6 = PlayerPrefs.GetFloat("Outline6");

        tag1 = PlayerPrefs.GetString("Tag1");
        tag2 = PlayerPrefs.GetString("Tag2");
        tag3 = PlayerPrefs.GetString("Tag3");

    }

    void OnDisable()
    {
        SaveColor(color1, 1);
        SaveColor(color2, 2);
        SaveColor(color3, 3);
        SaveColor(color4, 4);
        SaveColor(color5, 5);
        SaveColor(color6, 6);
        SaveColor(color7, 7);
        SaveColor(color8, 8);
        SaveColor(color9, 9);
        SaveColor(color10, 10);
        SaveColor(color11, 11);
        SaveColor(color12, 12);
        PlayerPrefs.SetFloat("Outline1", Outline1);
        PlayerPrefs.SetFloat("Outline2", Outline2);
        PlayerPrefs.SetFloat("Outline3", Outline3);
        PlayerPrefs.SetFloat("Outline4", Outline4);
        PlayerPrefs.SetFloat("Outline5", Outline5);
        PlayerPrefs.SetFloat("Outline6", Outline6);

        PlayerPrefs.SetString("Tag1", tag1);
        PlayerPrefs.SetString("Tag2", tag2);
        PlayerPrefs.SetString("Tag3", tag3);

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        color1 = EditorGUILayout.ColorField("Button Color", color1, GUILayout.Height(20));
        color2 = EditorGUILayout.ColorField("Outline Color", color2, GUILayout.Height(20));
        Outline1 = EditorGUILayout.FloatField("Outline Size", Outline1, GUILayout.Height(20));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        color3 = EditorGUILayout.ColorField("Button Text Color", color3, GUILayout.Height(20));
        color4 = EditorGUILayout.ColorField("Outline Color", color4, GUILayout.Height(20));
        Outline2 = EditorGUILayout.FloatField("Outline Size", Outline2, GUILayout.Height(20));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        color7 = EditorGUILayout.ColorField("Other Text Color", color7, GUILayout.Height(20));
        color8 = EditorGUILayout.ColorField("Outline Color", color8, GUILayout.Height(20));
        Outline4 = EditorGUILayout.FloatField("Outline Size", Outline4, GUILayout.Height(20));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        color5 = EditorGUILayout.ColorField("Tag1 Color", color5, GUILayout.Height(20));
        tag1 = EditorGUILayout.TagField("Tag#1 :" + tag1, tag1, GUILayout.Height(20));
        color6 = EditorGUILayout.ColorField("Outline Color", color6, GUILayout.Height(20));
        Outline3 = EditorGUILayout.FloatField("Outline Size", Outline3, GUILayout.Height(20));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        color9 = EditorGUILayout.ColorField("Tag2 Color", color9, GUILayout.Height(20));
        tag2 = EditorGUILayout.TagField("Tag#2 :" + tag2, tag2, GUILayout.Height(20));
        color10 = EditorGUILayout.ColorField("Outline Color", color10, GUILayout.Height(20));
        Outline5 = EditorGUILayout.FloatField("Outline Size", Outline5, GUILayout.Height(20));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        color11 = EditorGUILayout.ColorField("Tag3 Color", color11, GUILayout.Height(20));
        tag3 = EditorGUILayout.TagField("Tag#3 :" + tag3, tag3, GUILayout.Height(20));
        color12 = EditorGUILayout.ColorField("Outline Color", color12, GUILayout.Height(20));
        Outline6 = EditorGUILayout.FloatField("Outline Size", Outline6, GUILayout.Height(20));
        GUILayout.EndHorizontal();

        Repaint();
        if (GUILayout.Button("Change Color", GUILayout.Height(30)))
        {
            ChangeUI();
        }
    }

    void ChangeUI()
    {
        ButtonManager();
        PanelManager(tag1, Outline3, color5, color6);
        PanelManager(tag2, Outline5, color9, color10);
        PanelManager(tag3, Outline6, color11, color12);
        TextManager();

        SceneView.RepaintAll();
        EditorSceneManager.MarkAllScenesDirty();
    }

    #region UImanagers

    void PanelManager(string tag, float Outl, Color colorx, Color colory)
    {
        indexer = 0;
        var panels = GameObject.FindGameObjectsWithTag(tag);
        if (panels.Length > 0)
        {
            foreach (GameObject gObject in panels)
            {
                EditorUtility.SetDirty(gObject);
                Outline outline;
                Image myIm = gObject.GetComponent<Image>();

                if (myIm == null)
                {
                    Text myTx = gObject.GetComponent<Text>();
                    Undo.RecordObject(myTx, "TXT" + tag + indexer);
                    EditorUtility.SetDirty(myTx);
                    myTx.color = colorx;
                    outline = myTx.GetComponent<Outline>();
                }
                else
                {

                    Undo.RecordObject(myIm, "Image" + tag + indexer);
                    EditorUtility.SetDirty(myIm);
                    myIm.color = colorx;
                    outline = myIm.GetComponent<Outline>();
                }


                if (outline)
                {
                    Undo.RecordObject(outline, "Outline" + tag + indexer);
                    EditorUtility.SetDirty(outline);
                    outline.effectColor = colory;
                    outline.effectDistance = new Vector2(Outl, -Outl);
                }
                indexer++;
            }
            indexer = 0;
        }
    }

    void ButtonManager()
    {
        var buttons = FindObjectsOfType<Button>();
        Undo.RecordObjects(buttons, "Button");
        indexer = 0;

        ColorBlock cb = ColorBlock.defaultColorBlock;
        cb.normalColor = color1;
        cb.highlightedColor = new Color(color1.r + 0.2f, color1.g + 0.2f, color1.b + 0.2f);
        cb.pressedColor = new Color(color1.r - 0.3f, color1.g - 0.3f, color1.b - 0.3f);
        cb.disabledColor = new Color(color1.r - 0.3f, color1.g - 0.3f, color1.b - 0.3f, 0.3f);

        foreach (Button button in buttons)
        {
            if (!(button.tag == tag1 || button.tag == tag2 || button.tag == tag3))
            {
                EditorUtility.SetDirty(button.gameObject);
                button.colors = cb;
                Outline bOutline = button.GetComponent<Outline>();
                if (bOutline)
                {
                    Undo.RecordObject(bOutline, "bOutline" + indexer);
                    EditorUtility.SetDirty(bOutline);
                    bOutline.effectColor = color2;
                    bOutline.effectDistance = new Vector2(Outline1, -Outline1);
                }
            }
            GameObject text = button.transform.GetChild(0).gameObject;

            if (text != null && (!(text.tag == tag1 || text.tag == tag2 || text.tag == tag3)))
            {

                Text txt = text.GetComponent<Text>();
                Undo.RecordObject(txt, "Text" + indexer);
                indexer++;
                EditorUtility.SetDirty(txt);
                txt.color = color3;
                Outline tOutline = text.GetComponent<Outline>();
                if (tOutline)
                {
                    Undo.RecordObject(tOutline, "tOutline" + indexer);
                    EditorUtility.SetDirty(tOutline);
                    tOutline.effectColor = color4;
                    tOutline.effectDistance = new Vector2(Outline2, -Outline2);
                }
            }
        }
        indexer = 0;
    }

    void TextManager()
    {
        indexer = 0;
        var texts = FindObjectsOfType<Text>();
        Undo.RecordObjects(texts, "Texts");
        foreach (Text text in texts)
        {
            if (!(text.tag == tag1 || text.tag == tag2 || text.tag == tag3))
            {
                EditorUtility.SetDirty(text.gameObject);
                if (!text.transform.parent.GetComponent<Button>())
                {
                    text.color = color7;
                    Outline tOutline = text.GetComponent<Outline>();
                    indexer++;
                    if (tOutline)
                    {
                        Undo.RecordObject(tOutline, "ttOutline" + indexer);
                        EditorUtility.SetDirty(tOutline);
                        tOutline.effectColor = color8;
                        tOutline.effectDistance = new Vector2(Outline4, -Outline4);
                    }
                }
            }
        }
        indexer = 0;
    }

    #endregion

    #region ColorManager

    void SaveColor(Color col, int index)
    {
        string redStr = "col" + index + "R";
        string greenStr = "col" + index + "G";
        string blueStr = "col" + index + "B";
        string alphaStr = "col" + index + "A";
        float red = col.r;
        float green = col.g;
        float blue = col.b;
        float alpha = col.a;

        SaveChannel(redStr, red);
        SaveChannel(greenStr, green);
        SaveChannel(blueStr, blue);
        SaveChannel(alphaStr, alpha);
    }

    void SaveChannel(string Key, float value)
    {
        EditorPrefs.SetFloat(Key, value);
    }

    Color RetrieveColor(int index)
    {
        string redStr = "col" + index + "R";
        string greenStr = "col" + index + "G";
        string blueStr = "col" + index + "B";
        string alphaStr = "col" + index + "A";
        float red = RetrieveChannel(redStr);
        float green = RetrieveChannel(greenStr);
        float blue = RetrieveChannel(blueStr);
        float alpha = RetrieveChannel(alphaStr);
        Color myColor = new Color(red, green, blue, alpha);
        return myColor;
    }

    float RetrieveChannel(string Key)
    {
        return EditorPrefs.GetFloat(Key);
    }

    #endregion

}