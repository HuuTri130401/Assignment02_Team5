using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class OrderDAO
    {
        //Using Singleton Pattern
        private static OrderDAO? instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrderList()
        {
            var members = new List<Order>();
            try
            {
                using var context = new Assignment02PrnContext();
                members = context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;

        }

        public Order? GetOrderByID(int OrderID)
        {
            Order? orders = null;
            try
            {
                using var context = new Assignment02PrnContext();
                orders = context.Orders.SingleOrDefault(c => c.OrderId == OrderID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        //-----------------------------------------------------------------
        //Add a new member
        public void AddNew(Order Order)
        {
            try
            {
                Order orders = GetOrderByID(Order.OrderId);
                if (orders == null)
                {
                    using var context = new Assignment02PrnContext();
                    context.Orders.Add(Order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //-----------------------------------------------------------------
        //Add a new member
        public void Update(Order Order)
        {
            try
            {
                Order orders = GetOrderByID(Order.OrderId);
                if (orders != null)
                {
                    using var context = new Assignment02PrnContext();
                    context.Orders.Update(Order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------------------------------------------------
        //Add a new member
        public void Remove(int OrderId)
        {
            try
            {
                Order orders = GetOrderByID(OrderId);
                if (orders != null)
                {
                    using var context = new Assignment02PrnContext();
                    context.Orders.Remove(orders);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Order> FindListMiddleOrder(DateTime a, DateTime b)
        {
            var order = new List<Order>();
            var fil = new List<Order>();
            try
            {
                using var context = new Assignment02PrnContext();
                order = context.Orders.ToList();
                for (int i = 0; i < order.Count(); i++)
                {
                    if ((order[i].OrderDate >= a && order[i].OrderDate <= b))
                    {
                        fil.Add(order[i]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return fil;
        }

    }//end class OrderDAO
}//end namespace DataAccess
