using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;

namespace PushNotificationsAPI.Services
{
    public class PushNotifications
    {
        public PushNotifications()
        {
            if(FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(<PATH> +"/private_key.json"),
                });
            }
        }

        public String SendMessage(String topic, String title, String body)
        {
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "myData", "1337" },
                },
                Topic = topic,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                }
            };

            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            return "Successfully sent message: " + response;
        }

        public String SendToSpecificDeviceMessage(String token, String title, String body)
        {
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "myData", "1337" },
                },
                Token = token,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                }
            };

            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            return "Successfully sent message: " + response;
        }

        public void SendMulticastMessage(String body)
        {
            var message = new MulticastMessage()
            {
                Data = new Dictionary<string, string>()
                {
                    { "myData", "1337" },
                },
                Tokens = {},
                Notification = new Notification()
                {
                    Title = "Title Test",
                    Body = body
                }
            };
        }
    }
}
