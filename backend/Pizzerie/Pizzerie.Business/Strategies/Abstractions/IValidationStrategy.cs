using Pizzerie.Domain.Models.Application;

namespace Pizzerie.Business.Strategies.Abstractions;

public interface IValidationStrategy<in T>
{
    ContentResponse Validate(T instance);
}