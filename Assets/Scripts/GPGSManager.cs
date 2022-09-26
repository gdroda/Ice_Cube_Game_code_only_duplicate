using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGSManager : MonoBehaviour
{
    private PlayGamesClientConfiguration clientConfiguration;
    public Text statusText;
    public Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        configureGPGS();
        signIntoGPGS(SignInInteractivity.CanPromptOnce, clientConfiguration);
    }

    internal void configureGPGS()
    {
        clientConfiguration = new PlayGamesClientConfiguration.Builder().Build();
    }

    internal void signIntoGPGS(SignInInteractivity interactivity, PlayGamesClientConfiguration configuration)
    {
        //configuration = clientConfiguration;
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(interactivity, code =>
        {
            statusText.text = "Authenticating...";
            if (code == SignInStatus.Success)
            {
                statusText.text = "Successfully Authenticated";
                descriptionText.text = "Hello " + Social.localUser.userName + "You have an ID of " + Social.localUser.id;
            }
            else
            {
                statusText.text = "Failed to Authenticate";
                descriptionText.text = "Reason: " + code;
            }
        });
    }

    public void BasicSignInButton()
    {
        signIntoGPGS(SignInInteractivity.CanPromptAlways, clientConfiguration);
    }

    public void SignOutButton()
    {
        PlayGamesPlatform.Instance.SignOut();
        statusText.text = "Signed Out.";
        descriptionText.text = "";
    }

}
