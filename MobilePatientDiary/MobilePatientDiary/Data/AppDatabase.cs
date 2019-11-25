using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobilePatientDiary.Models;
using SQLite;

namespace MobilePatientDiary.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public AppDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PressureItem>().Wait();
            _database.CreateTableAsync<GlucoseItem>().Wait();
            _database.CreateTableAsync<NotificationItem>().Wait();
            _database.CreateTableAsync<VisitItem>().Wait();
        }

        public Task<List<PressureItem>> GetPresureItemsAsync()
        {
            return _database.Table<PressureItem>().ToListAsync();
        }

        public Task<PressureItem> GetPressureItemAsync(int id)
        {
            return _database.Table<PressureItem>()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> SavePressureItemAsync(PressureItem item)
        {
            if (item.Id != -1)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeletePressureItemAsync(PressureItem item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<List<GlucoseItem>> GetGlucoseItemsAsync()
        {
            return _database.Table<GlucoseItem>().ToListAsync();
        }

        public Task<GlucoseItem> GetGlucoseItemAsync(int id)
        {
            return _database.Table<GlucoseItem>()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> SaveGlucoseItemAsync(GlucoseItem item)
        {
            if (item.Id != -1)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteGlucoseItemAsync(GlucoseItem item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<List<NotificationItem>> GetNotificationItemsAsync()
        {
            return _database.Table<NotificationItem>().ToListAsync();
        }

        public Task<NotificationItem> GetNotificationItemAsync(int id)
        {
            return _database.Table<NotificationItem>()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> SaveNotificationItemAsync(NotificationItem item)
        {
            if (item.Id != -1)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteNotificationItemAsync(NotificationItem item)
        {
            return _database.DeleteAsync(item);
        }
        
        public Task<List<VisitItem>> GetVisitItemsAsync()
        {
            return _database.Table<VisitItem>().ToListAsync();
        }

        public Task<VisitItem> GetVisitItemAsync(int id)
        {
            return _database.Table<VisitItem>()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> SaveVisitItemAsync(VisitItem item)
        {
            if (item.Id != -1)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteVisitItemAsync(VisitItem item)
        {
            return _database.DeleteAsync(item);
        }
    }
}
