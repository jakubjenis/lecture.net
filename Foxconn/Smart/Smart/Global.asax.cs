using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation;
using FluentValidation.Mvc;
using Smart.Models;

namespace Smart
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var fluentValidationModelValidatorProvider = new FluentValidationModelValidatorProvider(new ValidatorFactory());
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            fluentValidationModelValidatorProvider.AddImplicitRequiredValidator = false;
            ModelValidatorProviders.Providers.Add(fluentValidationModelValidatorProvider);
            ModelValidatorProviders.Providers.Remove(ModelValidatorProviders.Providers.First(o => o is DataAnnotationsModelValidatorProvider));  

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }

    public class ValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            if (validatorType == typeof(IValidator<Person>))
            {
                return new PersonValidator();
            }
            return null;
        }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(o => o.Ssn).Length(10, 12);
        }
    }
}
