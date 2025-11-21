using UnityEngine;

public class ImageAnimation : MonoBehaviour
{
    private Material material;
    public GameObject GameObject;
    void Start()
    {
        //获得image的材质
        material = GetComponent<UnityEngine.UI.Image>().material;
        material.SetFloat("_Dissolve", 1);
    }

    // Update is called once per frame
    void Update()
    {
        //设置image的材质的_Dissolve参数为GameObject的x的Scale的x的值
        if(material.GetFloat("_Dissolve")!=0)
            material.SetFloat("_Dissolve", GameObject.transform.localScale.x);
    }
}
