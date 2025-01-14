﻿using FluentValidation;
using Grand.Business.Core.Interfaces.Marketing.Contacts;
using Grand.Infrastructure;
using Grand.Infrastructure.Validators;
using Grand.Web.Admin.Models.Messages;

namespace Grand.Web.Admin.Validators.Messages
{
    public class ContactFormDeleteValidator : BaseGrandValidator<ContactFormDeleteModel>
    {
        public ContactFormDeleteValidator(IEnumerable<IValidatorConsumer<ContactFormDeleteModel>> validators,
            IContactUsService contactUsService, IWorkContext workContext)
            : base(validators)
        {
            RuleFor(x => x).CustomAsync(async (x, context, _) =>
            {
                var contact = await contactUsService.GetContactUsById(x.Id);
                if (contact == null)
                    context.AddFailure("Not found with the specified id");

                if (workContext.CurrentVendor != null)
                {
                    if (contact!.VendorId != workContext.CurrentVendor.Id)
                        context.AddFailure("This is not your contact us form");
                }
            });
        }
    }
}