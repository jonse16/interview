using interview.Tool;
using interview.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
namespace interview.Services
{
    public class MessageRepository
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=root;database=interview;charset=utf8;SslMode=none;Allow User Variables=True");
        ModelsConverter mc = new ModelsConverter();

        public string nowString() {

            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public List<House> listHouse()
        {
            string sql = "SELECT * FROM house";
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return new List<House>();
            }
            else
            {
                return mc.convetToHouse(dt);
            }
        }

        public List<Message> listMessage(int houseId)
        {
            string sql = "SELECT * FROM message where house_id = {0}";
            List<Object> param = new List<object>();
            param.Add(houseId);
            sql = string.Format(sql, param.ToArray());
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return new List<Message>();
            }
            else
            {
                return mc.convetToMessage(dt);
            }
        }

        public void addMessage(int houseId, string name, string msg)
        {
            string now = nowString();
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO message(name, msg, house_id, create_date_time, last_update_date_time) ");
            sb.Append("VALUES('{0}', '{1}', {2}, '{3}', '{3}')");
            List<Object> param = new List<object>();         
            param.Add(name);
            param.Add(msg);
            param.Add(houseId);
            param.Add(now);
            string sql = string.Format(sb.ToString(), param.ToArray());
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.Fill(dt);
        }

        public void editMessage(int msgId, string msg)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE  message set msg = '{1}', last_update_date_time = '{2}'  WHERE id = {0}");
            List<Object> param = new List<object>();
            param.Add(msgId);
            param.Add(msg);
            param.Add(nowString());
            string sql = string.Format(sb.ToString(), param.ToArray());
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.Fill(dt);
        }

        public void deleteMessage(int msgId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM message WHERE id = {0}");
            List<Object> param = new List<object>();
            param.Add(msgId);
            string sql = string.Format(sb.ToString(), param.ToArray());
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.Fill(dt);
        }
    }
}
