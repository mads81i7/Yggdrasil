﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonUserRepository : IUserRepository
    {
        string JsonFileName = @"Data\JsonUserRepository.json";

        public List<User> GetAllUsers()
        {
            return JsonFileReader.ReadJsonUser(JsonFileName);
        }

        public void AddUser(User user)
        {
            List<User> users = GetAllUsers().ToList();
            List<int> userIDs = new List<int>();

            foreach (User userAlt in users)
                userIDs.Add(userAlt.ID);

            if (userIDs.Count != 0)
            {
                int i = userIDs.Max();
                user.ID = i + 1;
            }
            else
                user.ID = 1;

            users.Add(user);
            JsonFileWriter.WriteToJsonUser(users, JsonFileName);
        }

        public void RemoveUser(User user)
        {
            List<User> users = GetAllUsers().ToList();

            users.Remove(user);
            JsonFileWriter.WriteToJsonUser(users, JsonFileName);
        }

        public void EditUser(int id, User user)
        {
            List<User> users = GetAllUsers().ToList();
            users[id-1] = user;

            JsonFileWriter.WriteToJsonUser(users, JsonFileName);
        }

        public User GetUser(int id)
        {
            foreach (User user in GetAllUsers())
            {
                if (user.ID == id)
                    return user;
            }
            return new User();
        }
    }
}