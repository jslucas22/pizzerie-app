using Pizzerie.Business.Strategies.Abstractions;
using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.EmployeeCheckPad;

namespace Pizzerie.Business.Strategies;

public class EmployeeCheckPadCreateValidation : IValidationStrategy<EmployeeCheckPadCreateRequest>
{
    public ContentResponse Validate(EmployeeCheckPadCreateRequest? model)
    {
        if (model == null)
        {
            return new ContentResponse()
            {
                Success = false,
                Message = "vca-01: You need to input the data"
            };
        }

        if (string.IsNullOrEmpty(model.ClientName))
        {
            if (model.ClientName.Length < 3)
            {
                return new ContentResponse()
                {
                    Success = false,
                    Message = "vca-02: Input a client name"
                };
            }

            return new ContentResponse()
            {
                Success = false,
                Message = "vca-03: Input a valid client name"
            };
        }

        if (string.IsNullOrEmpty(model.PaymentMethod))
        {
            return new ContentResponse()
            {
                Success = false,
                Message = "vca-04: Invalid payment method"
            };
        }

        if (model.TableNumber <= 0)
        {
            return new ContentResponse
            {
                Success = false,
                Message = "vca-05: Invalid table number"
            };
        }

        if (model.Products == null)
        {
            return new ContentResponse()
            {
                Success = true,
                Message = "vca-06: Products can not be null"
            };
        }

        if (model.Products.Any(item => item.Price <= 0.00M))
        {
            return new ContentResponse()
            {
                Success = true,
                Message = "vca-07: You need to input the product price"
            };
        }

        if (model.Products.Any(item => item.Quantity <= 0))
        {
            return new ContentResponse()
            {
                Success = false,
                Message = "vca-08: You need to input the product quantity"
            };
        }

        return new ContentResponse()
        {
            Success = true,
            Message = "The input data is valid, proceeding to the insert"
        };
    }
}