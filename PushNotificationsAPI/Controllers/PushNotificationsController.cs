using Microsoft.AspNetCore.Mvc;
using PushNotificationsAPI.Services;
using System;

namespace FirebasePushNotifications.Controllers
{
    public class PushNotificationsController : ControllerBase
    {
        [HttpPost]
        [Route("/send-message")]
        public String SendMessage([FromQuery] String topic, [FromQuery] String title, [FromQuery] String message)
        {
            //var topic = "all";
            //var title = "Teste";
            //var message = "Teste";

            var firebase = new PushNotifications();
            var response = firebase.SendMessage(topic, title, message);
            return response;
        }

        [HttpPost]
        [Route("/send-message/specific-device")]
        public String SendToSpecificDeviceMessage([FromQuery] String token, [FromQuery] String title, [FromQuery] String message)
        {
            var firebase = new PushNotifications();
            var response = firebase.SendToSpecificDeviceMessage(token, title, message);
            return response;
        }
    }
}
