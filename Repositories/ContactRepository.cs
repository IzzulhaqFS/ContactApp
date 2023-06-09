﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    public class ContactRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection connection;

        private async Task Init()
        {
            if (connection != null)
                return;

            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<Models.Contact>();
        }

        public ContactRepository(string dbPath) 
        {
            _dbPath = dbPath;
        }

        public async Task AddNewContact(Models.Contact contact)
        {
            int result = 0;
            try
            {
                await Init();

                if (contact == null)
                    throw new Exception("Invalid Contact");

                result = await connection.InsertAsync(contact);
                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, contact.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", contact.Name, ex.Message);
            }
        }

        public async Task<List<Models.Contact>> GetAllContact()
        {
            try
            {
                await Init();
                return await connection.Table<Models.Contact>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Models.Contact>();
        }

        public async Task UpdateContact(Models.Contact contact)
        {

        }
    }
}
