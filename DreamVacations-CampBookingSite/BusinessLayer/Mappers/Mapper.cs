using BusinessLayer.Models;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    class Mapper
    {
        public string random()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
        //Mapper Methods For Bookings
        public Bookings MapToModel(BookingsDTO book)
        {
            Bookings booking = new Bookings()
            {
                ReferenceNumber = random(),
                TotalNights = book.TotalNights,
                BillingAddress = book.BillingAddress,
                Contact = book.Contact,
                State = book.State,
                Country = book.Country,
                ZipCode = book.ZipCode,
                CheckInDate = book.CheckInDate,
                CheckOutDate = book.CheckOutDate,
                NoOfPeople = book.NoOfPeople,
                CampId = book.CampId

            };
            return booking;
        }
        public BookingsDTO MapToDTO(Bookings book)
        {
            BookingsDTO booking = new BookingsDTO()
            {
                ReferenceNumber = book.ReferenceNumber,
                TotalNights = book.TotalNights,
                BillingAddress = book.BillingAddress,
                Contact = book.Contact,
                State = book.State,
                Country = book.Country,
                ZipCode = book.ZipCode,
                CheckInDate = book.CheckInDate,
                CheckOutDate = book.CheckOutDate,
                NoOfPeople = book.NoOfPeople,
                CampId = book.CampId

            };
            return booking;
        }
        public List<BookingsDTO> MapToDTO(List<Bookings> book)
        {
            List<BookingsDTO> bookings = new List<BookingsDTO>();
            foreach (var item in book)
            {
                BookingsDTO booking = new BookingsDTO()
                {
                    ReferenceNumber = item.ReferenceNumber,
                    TotalNights = item.TotalNights,
                    BillingAddress = item.BillingAddress,
                    Contact = item.Contact,
                    State = item.State,
                    Country = item.Country,
                    ZipCode = item.ZipCode,
                    CheckInDate = item.CheckInDate,
                    CheckOutDate = item.CheckOutDate,
                    NoOfPeople = item.NoOfPeople,
                    CampId = item.CampId

                };
                bookings.Add(booking);
            }
            return bookings;
        }
        // Mapper Methods For Admins
        public Admins MapToModel(UsersDTO userdto)
        {
            Admins user = new Admins()
            {
                Username = userdto.Username,
                Password = userdto.Password,
                Id = userdto.Id
            };
            return user;
        }
        public UsersDTO MapToDTO(Admins user)
        {
            UsersDTO userdto = new UsersDTO()
            {
                Username = user.Username,
                Password = user.Password,
                Id = user.Id
            };
            return userdto;
        }
        // MApper Methods for Camps
        public Camps MapToModel(CampsDTO campdto)
        {
            Camps camp = new Camps()
            {
                Id = campdto.Id,
                Description = campdto.Description,
                Image = campdto.Image,
                Amount = campdto.Amount,
                Capacity = campdto.Capacity,
                Title = campdto.Title,
                AdminId = Guid.Parse("D6C70D1E-1B8A-EA11-B187-3448ED265608")


        };
             
            return camp;
        }
        public CampsDTO MapToDTO(Camps camp)
        {
            CampsDTO campdto = new CampsDTO()
            {
                Id = camp.Id,
                Description = camp.Description,
                Image = camp.Image,
                Amount = camp.Amount,
                Capacity = camp.Capacity,
                Title = camp.Title
            };

            return campdto;
        }
        public List<CampsDTO> MapToDTO(List<Camps> camps)
        {
            List<CampsDTO> campsdto = new List<CampsDTO>();
            foreach (var camp in camps)
            {
                CampsDTO campdto = new CampsDTO()
                {
                    Id = camp.Id,
                    Description = camp.Description,
                    Image = camp.Image,
                    Amount = camp.Amount,
                    Capacity = camp.Capacity,
                    Title = camp.Title,
                    AdminId= camp.AdminId,
                    Rating = camp.Rating
                };
            
                campsdto.Add(campdto);
            }
            return campsdto;
        }


    }
}
