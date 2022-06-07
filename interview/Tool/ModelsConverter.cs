using interview.Models;
using System.Data;
namespace interview.Tool
{
    public class ModelsConverter
    {
        public List<House> convetToHouse(DataTable dt)
        {
            List<House> data = new List<House>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                House item = new House();
                item.id = Convert.ToInt32(dt.Rows[i]["id"]);
                item.name = string.Format("{0}", dt.Rows[i]["name"]);

                data.Add(item);

            }
            return data;
        }

        public List<Message> convetToMessage(DataTable dt)
        {
            List<Message> data = new List<Message>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Message item = new Message();
                item.id = Convert.ToInt32(dt.Rows[i]["id"]);
                item.name = string.Format("{0}", dt.Rows[i]["name"]);
                item.msg = string.Format("{0}", dt.Rows[i]["msg"]);
                item.houseId = Convert.ToInt32(dt.Rows[i]["house_id"]);
                string createDateTime = string.Format("{0}", dt.Rows[i]["create_date_time"]); ;
                item.createDateTime = Convert.ToDateTime(createDateTime);
                string lastUpdateDateTime = string.Format("{0}", dt.Rows[i]["last_update_date_time"]); ;
                item.lastUpdateDateTime = Convert.ToDateTime(lastUpdateDateTime);
                data.Add(item);
            }
            return data;
        }
    }
}
