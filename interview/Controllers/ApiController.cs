using interview.Services;
using interview.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace interview.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        MessageRepository messageRepository = new MessageRepository();

        [HttpGet("list/house")]
        public ContentResult listHouse() {
            JObject result = new JObject();
            try
            {
                JArray array = new JArray();
                List<House> hList = messageRepository.listHouse();
                foreach (House item in hList) {
                    JObject obj = new JObject();
                    obj.Add("id", item.id);
                    obj.Add("name", item.name);
                    array.Add(obj);
                }
                result.Add("status", 200);
                result.Add("data", array);
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
            catch (Exception ex) {
                result.Add("status", 500);
                result.Add("msg", "server error");
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
         
        }
        [HttpGet("list/msg")]
        public ContentResult listMessage(int houseId)
        {
            JObject result = new JObject();
            try
            {
                JArray array = new JArray();
                List<Message> mList =  messageRepository.listMessage(houseId);
                foreach (Message item in mList) {
                    JObject obj = new JObject();
                    obj.Add("id", item.id);
                    obj.Add("name", item.name);
                    obj.Add("msg", item.msg);
                    obj.Add("lastUpdateDateTime", item.lastUpdateDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    array.Add(obj);

                }
                result.Add("status", 200);
                result.Add("data", array);
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
            catch (Exception ex)
            {
                result.Add("status", 500);
                result.Add("msg", "server error");
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
        }

        [HttpPost("add")]
        public ContentResult addMessage(int houseId, string name, string msg)
        {
            JObject result = new JObject();
            try
            {
                messageRepository.addMessage(houseId, name, msg);
                result.Add("status", 200);
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
            catch (Exception ex)
            {
                result.Add("status", 500);
                result.Add("msg", "server error");
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
        }
        [HttpPost("edit")]
        public ContentResult editMessage(int msgId, string msg)
        {
            JObject result = new JObject();
            try
            {
                messageRepository.editMessage(msgId, msg);
                result.Add("status", 200);
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
            catch (Exception ex)
            {
                result.Add("status", 500);
                result.Add("msg", "server error");
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
        }
        [HttpDelete("delete")]
        public ContentResult deleteMessage(int msgId)
        {
            JObject result = new JObject();
            try
            {
                messageRepository.deleteMessage(msgId);
                result.Add("status", 200);
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
            catch (Exception ex)
            {
                result.Add("status", 500);
                result.Add("msg", "server error");
                return Content(result.ToString(), "application/json; charset=utf-8");
            }
        }

    }
}
