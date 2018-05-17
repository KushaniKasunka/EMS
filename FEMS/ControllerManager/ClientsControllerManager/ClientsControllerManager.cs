
using FEMS.Database;
using FEMS.Services.ClientsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEMS.ControllerManager.ClientsControllerManager
{
    public class ClientsControllerManager
    {
        private ClientsServices ClientsServices;
        public ClientsControllerManager()
        {
            ClientsServices = new ClientsServices();
        }

        //select*
        public List<client> getAllClients()
        {
            try
            {
                return ClientsServices.getAllClientsDB();
            }
            catch (Exception)
            {
                throw;
            }

        }

        //select
        public client getClient(int id)
        {
            try
            {
                return ClientsServices.getClientDB(id);
            }
           catch(Exception)
            {
                throw;
            }
        }

        //insert
        public int saveClient(client client)
        {
            try
            {
                client.client_status = 1;
                return ClientsServices.saveClientDB(client);
            }
            catch(Exception)
            {
                throw;
            }
        }

        //update
        public int updateClient(int id, client client)
        {
            try
            {
                return ClientsServices.updateClientDB(id, client);

            }
           catch(Exception)
            {
                throw;
            }
        }

        //delete
        public int deleteClient(int id, client client)
        {
            try
            {
                client.client_status = 0;
                return ClientsServices.deleteClientDB(id, client);
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}