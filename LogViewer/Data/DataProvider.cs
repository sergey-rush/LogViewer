using LogViewer.Base;
using System.Collections.Generic;
using System.Data;
using System;
using System.Configuration;
using System.Data.SQLite;
using LogViewer.Extensions;

namespace LogViewer.Data
{
    public static class DataProvider
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ToString();
        //private static int _counter;

        private static SQLiteConnection cn;
        static DataProvider()
        {
            cn = new SQLiteConnection(connectionString);
            cn.Open();
        }

        public static List<EventItem> GetEventItems()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, log_date, msg FROM event_items order by log_date; ", cn);
            var reader = cmd.ExecuteReader();
            return GetEventItemListFromReader(reader);
        }


        public static EventItem GetEventItemByThread(int thread)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, parent_id, thread, log_type, log_date, msg, event_id, mode, caller, request_state FROM event_items where thread = @thread AND parent_id is null; ", cn);
            cmd.Parameters.Add("@thread", DbType.Int32).Value = thread;
            var reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (reader.Read())
            {
                return GetEventItemFromReader(reader);
            }

            return null;
        }

        public static int CountEventItems()
        {
            SQLiteCommand cmd = new SQLiteCommand("select count(*) from event_items;", cn);
            object ret = cmd.ExecuteScalar(CommandBehavior.SingleResult);
            return Convert.ToInt32(ret.ToString());
        }

        public static int Delete()
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM event_items;vacuum;", cn);
            return cmd.ExecuteNonQuery();
        }

        //public static int InsertEventItem(EventItem eventItem)
        //{
        //}

        public static int InsertEventItem(EventItem eventItem)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO event_items (id, log_date, msg)VALUES(@id, @log_date, @msg);", cn);
            cmd.Parameters.Add("@id", DbType.String).Value = eventItem.Id;
            cmd.Parameters.AddWithValue("@log_date", eventItem.LogDate.ToDateTime().ToSqLiteDateTime());
            cmd.Parameters.Add("@msg", DbType.String).Value = eventItem.Msg;
            cmd.ExecuteNonQuery();
            return (int)cn.LastInsertRowId;
        }



        private static EventItem GetEventItemFromReader(IDataReader reader)
        {
            EventItem eventItem = new EventItem()
            {
                Id = reader.GetString(0),
                LogDate = reader.GetString(1),
                Msg = reader.GetString(2)
            };
            return eventItem;
        }

        private static List<EventItem> GetEventItemListFromReader(IDataReader reader)
        {
            List<EventItem> eventItems = new List<EventItem>();
            while (reader.Read())
                eventItems.Add(GetEventItemFromReader(reader));
            return eventItems;
        }
    }
}