
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public  class Person
{
    public string name;
    public int age;
}
[Serializable]
public class Persons
{
    public Person[] persons;
  
}
public class JsonUtilityDemo : MonoBehaviour 
   {

    // Use this for initialization
    void Start()
    {

        //Json  两种操作方式：LitJson，  JsonUtility

        //一：使用JsonUtility
        //创建
        //｛“name”：“李逍遥”，“age”：25｝
        Person p1 = new Person();
        p1.name = "李逍遥";
        p1.age = 25;
        //转成json字符串
        string jsonStr = JsonUtility.ToJson(p1);
     //   Debug.Log(jsonStr);


        //{｛“name”：“李逍遥”，“age”：25｝，｛“name”：“王小虎”，“age”：7｝}
        Person p2 = new Person();
        p2.name = "王小虎";
        p2.age = 7;
        Person[] ps = new Person[]{p1, p2};
        Persons persons = new Persons();
        persons.persons = ps;
        jsonStr = JsonUtility.ToJson(persons);
        //    Debug.Log(jsonStr);

        //解析
        Persons newPersons = JsonUtility.FromJson<Persons>(jsonStr);
        for (int i = 0; i < newPersons.persons.Length; i++)
        {
            Debug.Log(newPersons.persons[i].name);
            Debug.Log(newPersons.persons[i].age);
        }
      //  Debug.Log(newPersons.persons[0]);
    }

}
