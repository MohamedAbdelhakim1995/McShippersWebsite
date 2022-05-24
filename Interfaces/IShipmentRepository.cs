using McShippersWebsite.Models;
using System;
using System.Collections.Generic;

namespace McShippersWebsite.Interfaces
{
    public interface IShipmentRepository 
    {
        List<Shipment> GetAll();

        Shipment GetById(int id);

        int Insert(Shipment obj);

        int Update(int id, Shipment obj);

        int Delete(int id);
        List<Shipment> GetByDate(DateTime pickUpDate,DateTime deliveryDate);
    }
}
