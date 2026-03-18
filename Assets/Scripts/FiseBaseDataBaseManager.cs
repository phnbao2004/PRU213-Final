using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseDatabaseManager : MonoBehaviour
{
    private DatabaseReference reference;

    private void Awake()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void Start()
    {
        TilemapDetail tilemapDetail = new TilemapDetail(1, 1, TilemapState.Ground);
        // Ghi dữ liệu lên Firebase
        WriteDatabase("123", tilemapDetail.ToString());
        // Đọc dữ liệu từ Firebase
        ReadDatabase("123");
    }

    // Ghi dữ liệu lên Firebase
    public void WriteDatabase(string id, string message)
    {
        reference.Child("User").Child(id).SetValueAsync(message).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Ghi du lieu that bai: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Ghi du lieu thanh cong");
            }
        });
    }

    // Đọc dữ liệu từ Firebase
    public void ReadDatabase()
    {
        reference.Child("messages").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Read failed");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot child in snapshot.Children)
                {
                    Debug.Log(child.Key + " : " + child.Value);
                }
            }
        });
    }

    public void ReadDatabase(string id)
    {
        reference.Child("User").Child(id).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(" Doc du lieu thanh cong: " + snapshot.Value.ToString());
            }
            else
            {
                Debug.Log(" Doc du lieu that bai " + task.Exception);
            }
        });
    }
}