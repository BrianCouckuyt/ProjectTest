using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhittyServer.Web.Entities
{
    public class Player
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }


        private double highscore;

        public double Highscore
        {
            get { return highscore; }
            set { highscore = value; }
        }


        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string ingameName;

        public string IngameName
        {
            get { return ingameName; }
            set { ingameName = value; }
        }



        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }





    }
}
