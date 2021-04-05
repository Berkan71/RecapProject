using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapProjectDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RecapProjectDBContext context = new RecapProjectDBContext())
            {
                //var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                //             join c in context.Cars
                //             on r.CarId equals c.Id
                //             join cu in context.Customers
                //             on r.CustomerId equals cu.CustomerId
                //             join u in context.Users
                //             on cu.UserId equals u.Id
                //             join brd in context.Brands on c.BrandId equals brd.BrandId
                //             join clr in context.Colors on c.ColorId equals clr.ColorId
                //             select new RentalDetailDto
                //             {
                //                 RentalId = r.RentalId,
                //                 CarName = c.CarName,
                //                 BrandName = brd.BrandName,
                //                 CompanyName = cu.CompanyName,
                //                 RentDate = r.RentDate,
                //                 ReturnDate = r.ReturnDate,
                //                 UserName = u.FirstName + " " + u.LastName
                //             };
                //return result.ToList();

                
                    var result =
                        from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                        join customer in context.Customers
                            on rental.CustomerId equals customer.CustomerId
                        join user in context.Users
                             on customer.UserId equals user.Id
                        join car in context.Cars
                             on rental.CarId equals car.Id
                        join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                        join color in context.Colors
                             on car.ColorId equals color.ColorId
                        select new RentalDetailDto
                        {
                            RentDate = rental.RentDate,
                            ReturnDate = rental.ReturnDate,
                            RentalId = rental.RentalId,
                            BrandName = brand.BrandName,
                            CarDesctiption = car.Description,
                            ColorName = color.ColorName,
                            CompanyName = customer.CompanyName,
                            DailyPrice = car.DailyPrice,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            ModelYear = car.ModelYear
                        };

                    return result.ToList();
            
            }
        }
    }
}
