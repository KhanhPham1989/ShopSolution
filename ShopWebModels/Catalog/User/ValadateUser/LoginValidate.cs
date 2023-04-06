using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.User.ValadateUser
{
    public class LoginValidate : AbstractValidator<LoginRequest>
    {
        public LoginValidate()
        {
            RuleFor(x => x.UserLogin).NotEmpty().WithName("Input User Name").WithMessage(x => string.Format($" must be input."))
                .Length(5, int.MaxValue).WithMessage(x => $"At less 5 char to 100 char");
            RuleFor(x => x.PassWord).NotNull().WithName("PassWord").WithMessage(x => $"PassWord must be input.");
        }
    }

    public class RegisterValidate : AbstractValidator<RegisterRequest>
    {
        public RegisterValidate()
        {
            RuleFor(x => x.UserLogin).Length(5, int.MaxValue).GreaterThan("5");//.WithMessage($"{0} must be between {1} - {2} char");

            RuleFor(x => x.Email).NotEmpty().WithMessage(x => $"{x.Email} required");
            //.Matches("^[a-z][a-z0-9_]{5,32}@[a-z0-9]{2,}([a-z0-9]{2,4}){1,2}$")
            //.WithMessage(x => $"{x.Email} must be define exaple abc@email.com.");

            RuleFor(x => x.DOB).NotEmpty().WithName("Your Birthday").WithMessage($"Birthday must define dd-mm-yyyy")
                .GreaterThan(DateTime.Now.AddYears(-90)).WithMessage($"Your Age must less than 100")
                .LessThan(DateTime.Now.AddYears(-18))
                .WithMessage(x => $"Your Age must be among 20 - 80 years old .");

            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Not empty");

            // RuleFor(x => x.PassWordConfirm).Length(5, 256)
            // .Equal(x => x.PassWord).WithMessage(x => $"{0} must the same with {x.PassWord}");
            RuleFor(x => x).Custom((role, mess) =>
            {
                if (!role.PassWord.Equals(role.PassWordConfirm))
                {
                    mess.AddFailure("Confirm is not match");
                }
            });
        }
    }
}