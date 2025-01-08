

using Domain.Factories;
using Domain.Models;
using Dtos;

namespace Buisness.Test.Buisness;

public class ContactBusiness
{
	[Fact]

	public void Ctrate_ShouldReturnContactRegistrationForm()
	{

		//arrange


		//act
		ContactRegistrationForm result = ContactFactory.Create();

		//assert
		Assert.IsType<ContactRegistrationForm>(result);
	}

	[Theory]
	[InlineData("","")]
	public void Ctrate_ShouldReturnContact_WhenContactRegistrationFormIsSupplied(string firstname,string lastname)
	{
		//arrange

		ContactRegistrationForm contactRegistrationForm = new() { FirstName = firstname, LastName = lastname };
		//act
		Contact result = ContactFactory.Create(contactRegistrationForm);

		//      //assert
		Assert.IsType<Contact>(result);
		Assert.Equal(contactRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(contactRegistrationForm.LastName, result.LastName);
  
    }

}
