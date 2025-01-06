using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FireBaseController : MonoBehaviour
{
    public static FireBaseController Instance;
    private FireBase app;
    private DatabaseReference dbRef;

    private string dblink = "https://db-unity-3-default-rtdb.firebaseio.com/"
    private int playerID;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                // app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void InitFB()
    {
        app.SetEditorDatabaseUrl(dbLink);
        dbRef = FirebaseDatabase.DefaultInstance.RootReference.Child("gameroom");

        dbRef.ValueChanged += GameRoomValueChanged;
        RegisterForGame(); 
    }


    private void RegisterForGame()
    {
        dbRef.Child("player1").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("fail");
                return;
            }

            DataSnapshot snapshot = task.Result;

            if (snapshot.Value.ToString() == "-")
            {
                dbRef.Child("player1").SetValueAsync("+");
                playerID = 1;
            }
            else
            {
                dbRef.Child("player2").SetValueAsync("+");
                playerID = 2;
            }
        });
    }


    public void SendChoose(int choose)
    {
        string letter = choose == 0 ? "r" : choose == 1 ? "p" : "s";
        dbRef.Child("player" + playerID + "choose").SetValueAsync(letter);
    }

    private void GameRoomValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (e.DatabaseError != null)
        {
            Debug.LogError(e.DatabaseError.Message);
            return;
        }

        if (e.Snapshot.Child("player1").Value.ToString() != "-" &&
            e.Snapshot.Child("player2").Value.ToString() != "-")
        {
            string p1Choose = e.Snapshot.Child("player1Choose").Value.ToString();
            string p2Choose = e.Snapshot.Child("player2Choose").Value.ToString();

            if (!GameController.Instance.IsStarted)
                GameController.Instance.StartGame();
            else if (p1Choose != "-" && p2Choose != "-")
            {
                int winnerId = 0;

                if (p1Choose == "r")
                    winnerId = p2Choose == "s" ? 1 : 2;
                else if (p1Choose == "s")
                    winnerId = p2Choose == "p" ? 1 : 2;
                else
                    winnerId = p2Choose == "r" ? 1 : 2;

                GameController.Instance.SetResult(winnerId == playerID);
            }
        }
    }

}