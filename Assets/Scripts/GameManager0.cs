using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager0 : MonoBehaviour
{

    //register
    public TMP_InputField RegisterEmail;
    public TMP_InputField RegisterPassword;
    public TMP_Text RegisterError;

    //login
    public TMP_InputField loginEmail;
    public TMP_InputField loginpassword;
    public TMP_Text loginError;

    public async void Register()
    {


        var email = RegisterEmail.text;
        var password = RegisterPassword.text;
        var url = "users/register";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        HTTPRequestHelper helper = new HTTPRequestHelper();
        var result = await helper.PostAPI(url, form);
        Debug.Log(">>>>>>>>>" + result);
        if (!result)
        {
            //chuyển qua màn hình login
           
            SceneManager.LoadScene(Constants.SCENE01_INDEX);


        }
        else
        {
            //hiện thông báo lỗi
            RegisterError.text = "Đăng kí không thành công";
        }
    }

    public async void Login()
    {
        var email = loginEmail.text;
        var password = loginpassword.text;




        var url = "auth/login";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        HTTPRequestHelper helper = new HTTPRequestHelper();
        var result = await helper.PostAPI(url, form);
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>" + result);
        if (result)
        {
            //hiện thông báo lỗi
            RegisterError.text = "Đăng nhập không thành công";
        }
        else
        {
           
            //chuyển vào scene
            SceneManager.LoadScene(Constants.SCENE01_INDEX);
        }
    }
}
