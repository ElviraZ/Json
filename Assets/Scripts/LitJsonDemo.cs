
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public  class  Hero
{
    public string name;
    public int power;
}
public  class Heros
{
    public Hero[] heros;
}
   public class LitJsonDemo : MonoBehaviour 
   {
    // Use this for initialization
    void Start () 
	{
        //  Func1();
        //   Func2();
        Fun3();
    }

    //一：使用JsonUtility
    void  Func1()
    {
        //创建
        //{heros｛“name”：“超人”，“power”：25｝，｛“name”：“蝙蝠侠”，“power”：7｝}
        Hero hero1 = new Hero();
        hero1.name = "超人";
        hero1.power = 25;

        Hero hero2 = new Hero();
        hero2.name = "蝙蝠侠";
        hero2.power = 7;
        Heros heros = new Heros();
        heros.heros = new Hero[] { hero1, hero2 };
        string str = JsonMapper.ToJson(heros);
        Debug.Log(str);
        //解析
     Heros  newheros=     JsonMapper.ToObject<Heros>(str);
        for (int i = 0; i < newheros.heros.Length; i++)
        {
            Debug.Log(newheros.heros[i].name);
            Debug.Log(newheros.heros[i].power);
        }
    }
    void  Func2()
    {

      
        //创建
       // ｛“name”：“超人”，“power”：25｝
        JsonData data = new JsonData();//json可以是[],也可以是{}
        data.SetJsonType(JsonType.Object);
        data["name"] = "超人";
        data["power"] = 90;
        data.ToJson();
       // Debug.Log(data.ToJson());



        //{heros｛“name”：“超人”，“power”：25｝，｛“name”：“蝙蝠侠”，“power”：7｝}
        JsonData newdata = new JsonData();//{}
        JsonData newdata1 = new JsonData();//{}
        JsonData newdata2 = new JsonData();//{}
        newdata1["name"] = "超人";
        newdata1["power"] = 90;
        newdata2["name"] = "蝙蝠侠";
        newdata2["power"] = 70;

        JsonData heros = new JsonData();//
        heros.SetJsonType(JsonType.Array);
        heros.Add(newdata1);
        heros.Add(newdata2);
        newdata["heros"] = heros;
        //Debug.Log(newdata.ToJson());
    }
    void Fun3 ()
    {
        string str = "{'heros':[{'name':'超人','power':90},{'name':'蝙蝠侠','power':70}]}";
   JsonData  herosjd    = JsonMapper.ToObject(str);
        JsonData heros = herosjd["heros"];//[]
        foreach (JsonData item in heros)
        {
            Debug.Log(item["name"].ToString());
            Debug.Log(item["power"].ToString());
        }
      
    }
}