using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using LibraryDream.Extensions;

namespace LibraryDream.Controllers
{
    public class CustomBaseController<T> : Controller
    {
        private readonly IValidator<T> _validator;

        public CustomBaseController(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async Task<bool> ValidateModelAndAddModelErrorsAsync(T model)
        {
            var result = await _validator.ValidateAsync(model);
            if (result.IsValid) return true;
            result.AddToModelState(ModelState);
            return false;
        }
    }
}
