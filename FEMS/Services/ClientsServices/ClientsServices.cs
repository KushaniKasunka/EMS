using FEMS.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FEMS.Services.ClientsServices
{
    public class ClientsServices
    {
        private EMSEntities db;
        public ClientsServices()
        {
            db = new EMSEntities();
        }

        //select*method
        public List<client> getAllClientsDB()
        {
            try
            {
                return db.clients.Where(c => c.client_status == 1).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //select method
        public client getClientDB(int id)
        {
            try
            {
                return db.clients.Where(c => c.client_id == id && c.client_status == 1).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //insert method
        public int saveClientDB(client client)
        {
            int flag = 0;
            try
            {
                var result = db.clients.Where(c => c.client_nic.Equals(client.client_nic)).FirstOrDefault();
                if (result == null)
                {
                    db.clients.Add(client);
                    db.SaveChanges();
                    flag = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //update method
        public int updateClientDB(int id, client client)
        {
            int flag = 0;
            try
            {
                var result = db.clients.Where(c => c.client_id == id).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        //delete method
        public int deleteClientDB(int id, client client)
        {
            int flag = 0;
            try
            {
                var result = db.clients.Where(c => c.client_id == id && c.client_status == 1).FirstOrDefault();

                if (result != null)
                {
                    db.Entry(result).State = EntityState.Detached;
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                    flag = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }
    }

    }