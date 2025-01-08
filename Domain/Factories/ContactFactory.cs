


using Domain.Models;
using Dtos;

namespace Domain.Factories;

public class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }

    public static Contact Create(ContactRegistrationForm form)
    {
        return new Contact()
        {

            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber=form.PhoneNumber,
            StreetAddress=form.StreetAddress,
            PostalCode=form.PostalCode,
            City=form.City,

};
    }
}
