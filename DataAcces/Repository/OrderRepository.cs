using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrderList();
        public Order GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);
        public void InsertOrder(Order order) => OrderDAO.Instance.AddNew(order);
        public void DeleteOrder(int orderID) => OrderDAO.Instance.Remove(orderID);
        public void UpdateOrder(Order order) => OrderDAO.Instance.Update(order);
        public List<Order> GetOrderByOrderdDate(DateTime dateTime1, DateTime dateTime2) => OrderDAO.Instance.FindListMiddleOrder(dateTime1, dateTime2);
    }
}
