using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yggdrasil.Models
{
    public class Courier : User
    {
        private List<Order> _deliveryHistory;

        private double _rating;
        private int _noOfRatings;

        public Courier()
        {
            _deliveryHistory = new List<Order>();

            _rating = 0.0;
            _noOfRatings = 0;
        }

        public double Rating
        {
            get
            {
                return _rating;
            }
        }

        public int NoOfRatings
        {
            get
            {
                return _noOfRatings;
            }
        }
    }
}
